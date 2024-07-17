using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Upload an attachment to 4me for later reference.
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "Attachment")]
    [OutputType(typeof(AttachmentUploadResponse))]
    public class SendAttachmentCommand : PSCmdlet
    {
        /// <summary>
        /// The path to the file to upload.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The content type of to the file to upload.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string ContentType { get; set; } = string.Empty;

        /// <summary>
        /// The client is used to upload the file. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
        /// Upload the attachment.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                PowerShellTraceListener.RegisterCmdlet(this);
                Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
                AttachmentUploadResponse result = client.Sdk4meClient.UploadAttachment(Path, ContentType).GetAwaiter().GetResult();
                PowerShellTraceListener.UnregisterCmdlet();
                WriteObject(result);
            }
            catch (Sdk4meException ex)
            {
                ex.ThrowAsTerminatingError(this, "SendAttachmentError", ErrorCategory.InvalidOperation, this);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "SendAttachmentError", ErrorCategory.NotSpecified, this);
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
