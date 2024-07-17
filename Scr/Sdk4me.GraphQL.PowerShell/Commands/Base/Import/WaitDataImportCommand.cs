using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// CmdLet to wait for the data import process to complete by periodically checking the import status.
    /// This CmdLet polls the import status at specified intervals until the import process is complete.
    /// The import token and polling interval are specified as parameters.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "DataImport")]
    [OutputType(typeof(BulkImportResponse))]
    public class WaitDataImportCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the import token.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the polling interval in seconds.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public int PollingInterval { get; set; } = 30;

        /// <summary>
        /// Gets or sets the maximum time in seconds to wait for the import to complete.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// The client used for interacting with the 4me API. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Sdk4mePowerShellClient? Client { get; set; }

        /// <summary>
        /// Initial setup operations before processing the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Executes the connection process based on the specified parameters.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                PowerShellTraceListener.RegisterCmdlet(this);
                Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
                BulkImportResponse response = client.Sdk4meClient.Bulk.AwaitImport(Token, PollingInterval, TimeSpan.FromSeconds(Timeout)).GetAwaiter().GetResult();
                PowerShellTraceListener.UnregisterCmdlet();
                WriteObject(response);
            }
            catch (Sdk4meException ex)
            {
                ex.ThrowAsTerminatingError(this, "DataImportError", ErrorCategory.InvalidOperation);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "DataImportError", ErrorCategory.NotSpecified, this);
            }
        }

        /// <summary>
        /// Final cleanup operations after processing the command.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
