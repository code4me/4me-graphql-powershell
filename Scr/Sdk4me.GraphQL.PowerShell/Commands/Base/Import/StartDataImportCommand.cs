using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// CmdLet to initiate the data import process to the 4me system.
    /// This CmdLet supports importing data from specified file paths or streams.
    /// The type of import and the data source can be specified as parameters.
    /// The CmdLet returns an object representing the import operation, which can be used to monitor the status and ensure the data is successfully imported.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "DataImport")]
    [OutputType(typeof(string))]
    public class StartDataImportCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the type of data to import.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the file path of the data to import.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The client used for interacting with the 4me API. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
                string? token = client.Sdk4meClient.Bulk.StartImport(Type, Path).GetAwaiter().GetResult();
                PowerShellTraceListener.UnregisterCmdlet();
                WriteObject(token);
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
