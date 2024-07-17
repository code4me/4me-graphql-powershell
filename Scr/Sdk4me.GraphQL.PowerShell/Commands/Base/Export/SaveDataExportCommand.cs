using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// CmdLet to wait for the data export process to complete, download the file, and save it to a specified path.
    /// This CmdLet polls the export status at specified intervals, downloads the file once the export is complete, and saves it to the provided file path.
    /// The export token, polling interval, and file path are specified as parameters.
    /// </summary>
    [Cmdlet(VerbsData.Save, "DataExport")]
    [OutputType(typeof(void))]
    public class SaveDataExportCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the export token.
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
        /// Gets or sets the path where the exported file will be saved.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the maximum time in seconds to wait for the export to complete.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// The client used for interacting with the 4me API. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
                client.Sdk4meClient.Bulk.AwaitDownloadAndSave(Token, PollingInterval, Path, TimeSpan.FromSeconds(Timeout)).GetAwaiter().GetResult();
                PowerShellTraceListener.UnregisterCmdlet();
            }
            catch (Sdk4meException ex)
            {
                ex.ThrowAsTerminatingError(this, "DataExportError", ErrorCategory.InvalidOperation);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "DataExportError", ErrorCategory.NotSpecified, this);
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
