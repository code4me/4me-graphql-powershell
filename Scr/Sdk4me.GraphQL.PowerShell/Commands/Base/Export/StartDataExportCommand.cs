using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// CmdLet to export data from the 4me system.
    /// This CmdLet supports exporting data in different formats, such as CSV and Excel.
    /// The format can be specified as a parameter.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "DataExport")]
    [OutputType(typeof(string))]
    public class StartDataExportCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the export format.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DataExportFormat Format { get; set; } = DataExportFormat.CSV;

        /// <summary>
        /// Gets or sets the line separator for CSV exports.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ExportLineSeparator LineSeparator { get; set; } = ExportLineSeparator.LineFeed;

        /// <summary>
        /// Gets or sets the types of data to export.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string[] Types { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Gets or sets the start date for the export.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime? From { get; set; }

        /// <summary>
        /// The client is used to upload the file. If not provided, the default client is used.
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
                string? token = null;
                if (Format == DataExportFormat.CSV)
                {
                    if (From.HasValue)
                    {
                        token = client.Sdk4meClient.Bulk.StartCsvExport(From.Value, LineSeparator, Types).GetAwaiter().GetResult();
                    }
                    else
                    {
                        token = client.Sdk4meClient.Bulk.StartCsvExport(LineSeparator, Types).GetAwaiter().GetResult();
                    }
                }
                else
                {
                    if (From.HasValue)
                    {
                        token = client.Sdk4meClient.Bulk.StartExcelExport(From.Value, Types).GetAwaiter().GetResult();
                    }
                    else
                    {
                        token = client.Sdk4meClient.Bulk.StartExcelExport(Types).GetAwaiter().GetResult();
                    }
                }
                PowerShellTraceListener.UnregisterCmdlet();
                WriteObject(token);
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
