using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new custom field collection.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CustomFieldCollection")]
    [OutputType(typeof(CustomFieldCollection))]
    public class NewCustomFieldCollectionCommand : PSCmdlet
    {
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
                WriteObject(new CustomFieldCollection());
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "NewCustomFieldCollectionError", ErrorCategory.NotSpecified, this);
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
