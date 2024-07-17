using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new user interface extension.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "UiExtension")]
    [OutputType(typeof(UiExtension))]
    public class NewUiExtensionCommand : PSCmdlet
    {
        /// <summary>
        /// The type of record in which the UI extension can be selected.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionCategory Category { get; set; }

        /// <summary>
        /// The name of the UI extension.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Set to true to promote the Prepared Version to the Active Version. If the was an Active Version, it will be Archived.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Activate { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Sets the CSS stylesheet of the Prepared Version if updated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Css { get; set; }

        /// <summary>
        /// Description of the UI extension.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] DescriptionAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Whether the UI extension is inactive.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Sets the Form Definition of the Prepared Version if updated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public JToken? FormDefinition { get; set; }

        /// <summary>
        /// Sets the HTML code of the Prepared Version if updated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Html { get; set; }

        /// <summary>
        /// Sets the Javascript code of the Prepared Version if updated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Javascript { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The text that is to be displayed as the section header above the UI extension when the UI extension is presented within a form.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Title { get; set; }

        /// <summary>
        /// An array of user interface extension properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionField[] Properties { get; set; } = Array.Empty<UiExtensionField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            UiExtensionCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Activate"))
            {
                input.Activate = Activate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Css"))
            {
                input.Css = Css;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DescriptionAttachments"))
            {
                input.DescriptionAttachments = DescriptionAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FormDefinition"))
            {
                input.FormDefinition = FormDefinition;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Html"))
            {
                input.Html = Html;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Javascript"))
            {
                input.Javascript = Javascript;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Title"))
            {
                input.Title = Title;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            UiExtensionCreatePayload result = client.Sdk4meClient.Mutation(input, new UiExtensionQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewUiExtensionError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.UiExtension);
        }

        /// <summary>
        /// Completes the processing of the command. This method is called once after all records have been processed.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
