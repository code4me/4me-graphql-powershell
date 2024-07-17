using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new request template.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "RequestTemplate")]
    [OutputType(typeof(RequestTemplate))]
    public class NewRequestTemplateCommand : PSCmdlet
    {
        /// <summary>
        /// A short description that needs to be copied to the Subject field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// After selecting the request template in Self Service, the user needs to be able to select a configuration item in the Asset field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssetSelection { get; set; } = false;

        /// <summary>
        /// Whether the person who is registering a new request based on the template is selected in its Member field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToSelf { get; set; } = false;

        /// <summary>
        /// The category that needs to be selected in the Category field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The completion reason that needs to be selected in the Completion reason field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// Identifier of the CI that needs to be copied to the Configuration item field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ConfigurationItemId { get; set; }

        /// <summary>
        /// Whether the subject of the request template needs to become the subject of a request when the template is applied, provided that the Subject field of this request is empty.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool CopySubjectToRequests { get; set; } = false;

        /// <summary>
        /// Used to enter the number of minutes within which requests that are based on the request template are to be resolved.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? DesiredCompletion { get; set; }

        /// <summary>
        /// Whether the request template may not be used to help register new requests.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a request that is based on the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// Whether the request template is shown to end users in Self Service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool EndUsers { get; set; } = false;

        /// <summary>
        /// The impact level that needs to be selected in the Impact field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestImpact? Impact { get; set; }

        /// <summary>
        /// Instructions for the support staff who will work on requests that are based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// A comma-separated list of words that can be used to find the request template using search.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Keywords { get; set; }

        /// <summary>
        /// Identifier of the person who should be selected in the Member field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Note field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// The information that needs to be displayed after the template has been applied to a new or existing request. This field typically contains step-by-step instructions about how to complete the registration of a request that is based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RegistrationHints { get; set; }

        /// <summary>
        /// Identifiers of reservation offerings related to the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ReservationOfferingIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifier of the service for which the request template is made available.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Whether the request template is shown to Specialists.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Specialists { get; set; } = false;

        /// <summary>
        /// Used to select the status value that needs to be selected in the Status field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestStatus? Status { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that should be selected in the Supplier field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the calendar that is to be used to calculate the desired completion for requests that are based on the request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursId { get; set; }

        /// <summary>
        /// Identifier of the team that should be selected in the Team field of a new request when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The time zone that applies to the selected support hours.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether a new request that is created based on the template is to be marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Urgent { get; set; } = false;

        /// <summary>
        /// Identifier of the Workflow Manager linked to the request template. Required when a Workflow Template is defined, and the Service does not define a Workflow Manager.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// Identifier of the Workflow Template related to the request template. Required when the Status is set to _Workflow Pending_.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// An array of request template properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateField[] Properties { get; set; } = Array.Empty<RequestTemplateField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            RequestTemplateCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssetSelection"))
            {
                input.AssetSelection = AssetSelection;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToSelf"))
            {
                input.AssignToSelf = AssignToSelf;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CompletionReason"))
            {
                input.CompletionReason = CompletionReason;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemId"))
            {
                input.ConfigurationItemId = ConfigurationItemId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CopySubjectToRequests"))
            {
                input.CopySubjectToRequests = CopySubjectToRequests;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DesiredCompletion"))
            {
                input.DesiredCompletion = DesiredCompletion;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndUsers"))
            {
                input.EndUsers = EndUsers;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Impact"))
            {
                input.Impact = Impact;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Instructions"))
            {
                input.Instructions = Instructions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Keywords"))
            {
                input.Keywords = Keywords;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MemberId"))
            {
                input.MemberId = MemberId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RegistrationHints"))
            {
                input.RegistrationHints = RegistrationHints;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ReservationOfferingIds"))
            {
                input.ReservationOfferingIds = ReservationOfferingIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Specialists"))
            {
                input.Specialists = Specialists;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupplierId"))
            {
                input.SupplierId = SupplierId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursId"))
            {
                input.SupportHoursId = SupportHoursId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamId"))
            {
                input.TeamId = TeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Urgent"))
            {
                input.Urgent = Urgent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowManagerId"))
            {
                input.WorkflowManagerId = WorkflowManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowTemplateId"))
            {
                input.WorkflowTemplateId = WorkflowTemplateId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            RequestTemplateCreatePayload result = client.Sdk4meClient.Mutation(input, new RequestTemplateQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewRequestTemplateError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.RequestTemplate);
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
