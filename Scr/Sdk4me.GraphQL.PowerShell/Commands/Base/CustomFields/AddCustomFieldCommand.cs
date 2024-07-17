using Newtonsoft.Json.Linq;
using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Add or update an item in a <see cref="CustomFieldCollection"/>.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "CustomField")]
    [OutputType(typeof(CustomFieldCollection))]
    public class AddCustomFieldCommand : PSCmdlet
    {
        /// <summary>
        /// The custom field collection.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [AllowEmptyCollection]
        public CustomFieldCollection CustomFieldCollection { get; set; } = new();

        /// <summary>
        /// The identifier of the custom field to add or update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// The new value of the custom field.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [AllowNull]
        public object? Value { get; set; }

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
                if (Value is PSObject @object)
                    CustomFieldCollection.AddOrUpdate(ID, JToken.FromObject(@object.BaseObject));
                else
                    CustomFieldCollection.AddOrUpdate(ID, Value == null ? null : JToken.FromObject(Value));
                WriteObject(CustomFieldCollection);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "AddCustomFieldError", ErrorCategory.NotSpecified, this);
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
