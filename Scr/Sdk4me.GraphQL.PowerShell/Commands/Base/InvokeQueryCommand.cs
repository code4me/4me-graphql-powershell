using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a query.
    /// </summary>
    public class InvokeQueryCommand<TEntity, TQuery> : PSCmdlet
        where TEntity : Node
        where TQuery : IQuery
    {
        private readonly bool isSingleValueResponse = false;

        internal InvokeQueryCommand()
        {
        }

        internal InvokeQueryCommand(bool isSingleValueResponse)
        {
            this.isSingleValueResponse = isSingleValueResponse;
        }

        /// <summary>
        /// The query to be executed.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TQuery? Query { get; set; }

        /// <summary>
        /// The client is used to execute the query. If no client is specified, the first created client will be used by default.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Sdk4mePowerShellClient? Client { get; set; }

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Executes query against the 4me GraphQL API.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                PowerShellTraceListener.RegisterCmdlet(this);
                Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
                TQuery query = Query ?? throw new ArgumentNullException(nameof(Query));

                if (isSingleValueResponse)
                {
                    TEntity result = client.Sdk4meClient.Get<TEntity>(query).GetAwaiter().GetResult().First();
                    PowerShellTraceListener.UnregisterCmdlet();
                    WriteObject(result);
                }
                else
                {
                    DataList<TEntity> result = client.Sdk4meClient.Get<TEntity>(query).GetAwaiter().GetResult();
                    PowerShellTraceListener.UnregisterCmdlet();
                    WriteObject(result, true);

                }
            }
            catch (Sdk4meException ex)
            {
                PowerShellTraceListener.UnregisterCmdlet();
                ex.ThrowAsTerminatingError(this, $"Invoke{typeof(TEntity).Name}Error", ErrorCategory.InvalidOperation, this);
            }
            catch (Exception ex)
            {
                PowerShellTraceListener.UnregisterCmdlet();
                ex.ThrowAsTerminatingError(this, $"Invoke{typeof(TEntity).Name}Error", ErrorCategory.NotSpecified, this);
            }
        }

        /// <summary>
        /// Completes the processing of the command.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
