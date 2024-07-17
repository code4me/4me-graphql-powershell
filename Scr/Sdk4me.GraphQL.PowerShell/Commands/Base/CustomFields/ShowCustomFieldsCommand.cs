using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Add or update an item in a <see cref="CustomFieldCollection"/>.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "CustomFields")]
    [OutputType(typeof(PSObject))]
    public class ShowCustomFieldsCommand : PSCmdlet
    {
        /// <summary>
        /// The custom field collection.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public CustomFieldCollection CustomFieldCollection { get; set; } = new();

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
                List<PSObject> psObjects = new();
                foreach (CustomField customField in CustomFieldCollection)
                {
                    PSObject item = new();
                    item.Properties.Add(new PSNoteProperty("ID", customField.ID));
                    item.Properties.Add(new PSNoteProperty("Value", customField.Value?.ToString()));
                    psObjects.Add(item);
                }
                WriteObject(psObjects, true);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "ShowCustomFieldsError", ErrorCategory.NotSpecified, this);
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
