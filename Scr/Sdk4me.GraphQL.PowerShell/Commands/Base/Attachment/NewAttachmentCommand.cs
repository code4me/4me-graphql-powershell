using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Create a new attachment object for 4me.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Attachment")]
    [OutputType(typeof(AttachmentInput))]
    public class NewAttachmentCommand : PSCmdlet
    {
        /// <summary>
        /// The key obtained from the attachment upload response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Whether the attachment is an inline image.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public bool Inline { get; set; } = false;

        /// <summary>
        /// The size of the attachment in bytes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [AllowNull]
        public long? Size { get; set; }

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
                AttachmentInput attachmentInput = new()
                {
                    Key = Key,
                    Size = Size,
                    Inline = Inline
                };
                WriteObject(attachmentInput);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "NewAttachmentError", ErrorCategory.NotSpecified, this);
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
