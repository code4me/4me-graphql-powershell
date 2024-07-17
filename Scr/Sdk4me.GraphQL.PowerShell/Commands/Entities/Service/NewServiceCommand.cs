using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new service.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Service")]
    [OutputType(typeof(Service))]
    public class NewServiceCommand : PSCmdlet
    {
        /// <summary>
        /// The name of the service. The service name may be followed by the name of its core application placed between brackets.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the organization who provides the service.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ProviderId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the person who is responsible for ensuring that the availability targets specified in the active SLAs for the service are met.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AvailabilityManagerId { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for ensuring that the service is not affected by incidents that are caused by capacity shortages.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CapacityManagerId { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the changes of the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ChangeManagerId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for creating and maintaining the continuity plans for the service&apos;s instances that have an active SLA with a continuity target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ContinuityManagerId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// A high-level description of the service&apos;s core functionality.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] DescriptionAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Whether the service may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the team that will, by default, be selected in the First line team field of a new service instance when it is being registered for the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FirstLineTeamId { get; set; }

        /// <summary>
        /// A comma-separated list of words that can be used to find the service via search.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Keywords { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for the quality of the knowledge articles for the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? KnowledgeManagerId { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the problems that directly affect the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProblemManagerId { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the releases of the service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ReleaseManagerId { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for ensuring that the service level targets specified in the SLAs for the service are met.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceOwnerId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the team that will, by default, be selected in the Support team field of a service instance when one is registered for the service. Similarly, this team will be selected in the Team field of a problem when the service is related to it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportTeamId { get; set; }

        /// <summary>
        /// Identifier of the survey used to measure customer rating of this service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SurveyId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// An array of service properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceField[] Properties { get; set; } = Array.Empty<ServiceField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ServiceCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProviderId"))
            {
                input.ProviderId = ProviderId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AvailabilityManagerId"))
            {
                input.AvailabilityManagerId = AvailabilityManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CapacityManagerId"))
            {
                input.CapacityManagerId = CapacityManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChangeManagerId"))
            {
                input.ChangeManagerId = ChangeManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ContinuityManagerId"))
            {
                input.ContinuityManagerId = ContinuityManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("FirstLineTeamId"))
            {
                input.FirstLineTeamId = FirstLineTeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Keywords"))
            {
                input.Keywords = Keywords;
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeManagerId"))
            {
                input.KnowledgeManagerId = KnowledgeManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProblemManagerId"))
            {
                input.ProblemManagerId = ProblemManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ReleaseManagerId"))
            {
                input.ReleaseManagerId = ReleaseManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceOwnerId"))
            {
                input.ServiceOwnerId = ServiceOwnerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportTeamId"))
            {
                input.SupportTeamId = SupportTeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SurveyId"))
            {
                input.SurveyId = SurveyId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ServiceCreatePayload result = client.Sdk4meClient.Mutation(input, new ServiceQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewServiceError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Service);
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
