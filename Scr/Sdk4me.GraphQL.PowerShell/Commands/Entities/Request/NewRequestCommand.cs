using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new request.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Request")]
    [OutputType(typeof(Request))]
    public class NewRequestCommand : PSCmdlet
    {
        /// <summary>
        /// Default: false - When the Satisfaction field of the request is set to &apos;Dissatisfied&apos;, a person who has the Service Desk Manager role, can check the Addressed box to indicate that the requester has been conciliated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Addressed { get; set; } = false;

        /// <summary>
        /// ID of the column this item is placed in.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardColumnId { get; set; }

        /// <summary>
        /// The (one based) position of this item in its column.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? AgileBoardColumnPosition { get; set; }

        /// <summary>
        /// ID of the board this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// The Category field is used to select the category of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The appropriate completion reason for the request when it has been completed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// Identifiers of the configuration items to relate to the request. When this field is used to update an existing request, all configuration items that were linked to this request will be replaced by the supplied configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ConfigurationItemIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The date and time that has been agreed on for the completion of the request. The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA&apos;s resolution target. By default, the person selected in the Requested by field receives a notification based on the &apos;Desired Completion Set for Request&apos; email template whenever the value in the Desired completion field is set, updated or removed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? DesiredCompletionAt { get; set; }

        /// <summary>
        /// Used to specify the actual date and time at which the service became available again.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? DowntimeEndAt { get; set; }

        /// <summary>
        /// Used to specify the actual date and time at which the service outage started.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? DowntimeStartAt { get; set; }

        /// <summary>
        /// ID of the request group that is used to group the requests that have been submitted for the resolution of exactly the same incident, for the implementation of exactly the same change, for the provision of exactly the same information, etc.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? GroupedIntoId { get; set; }

        /// <summary>
        /// Used to select the extent to which the service instance is impacted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestImpact? Impact { get; set; }

        /// <summary>
        /// Used to provide information that is visible only for people who have the Auditor, Specialist or Account Administrator role of the account for which the internal note is intended. The X-4me-Account header sent determines the account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? InternalNote { get; set; }

        /// <summary>
        /// The attachments used in the internalNote field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] InternalNoteAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Latest knowledge article applied to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [Obsolete("Use `knowledgeArticleIds` instead.")]
        public string? KnowledgeArticleId { get; set; }

        /// <summary>
        /// Knowledge articles applied to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] KnowledgeArticleIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Used to indicate the status in the major incident management process.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestMajorIncidentStatus? MajorIncidentStatus { get; set; }

        /// <summary>
        /// ID of the person to whom the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Tags to be added to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public TagInput[] NewTags { get; set; } = Array.Empty<TagInput>();

        /// <summary>
        /// New or updated watches.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public WatchInput[] NewWatches { get; set; } = Array.Empty<WatchInput>();

        /// <summary>
        /// Any additional information that could prove useful for resolving the request and/or to provide a summary of the actions that have been taken since the last entry.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// The attachments used in the note field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] NoteAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// ID of problem to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProblemId { get; set; }

        /// <summary>
        /// Estimate of the relative size of this item on the product backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogEstimate { get; set; }

        /// <summary>
        /// Identifier of the product backlog this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProductBacklogId { get; set; }

        /// <summary>
        /// The (one based) position of this item on the backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogPosition { get; set; }

        /// <summary>
        /// ID of project to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Default: false - Whether the provider currently indicates not to be accountable.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool ProviderNotAccountable { get; set; } = false;

        /// <summary>
        /// ID of the person who submitted the request. Defaults to the Requested for field if its value was explicitely provided, otherwise it defaults to the current authenticated person
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestedById { get; set; }

        /// <summary>
        /// ID of the person for whom the request was submitted. The person selected in the Requested by field is automatically selected in this field, but another person can be selected if the request is submitted for another person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestedForId { get; set; }

        /// <summary>
        /// Default: false - A request can be marked as reviewed by the problem manager of the service of the service instance that is linked to the request. Marking a request as reviewed excludes it from the &apos;Requests for Problem Identification&apos; view.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Reviewed { get; set; } = false;

        /// <summary>
        /// ID of the service instance in which the cause of the incident resides, for which the change is requested, or about which information is needed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Default: assigned - Used to select the current status of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RequestStatus? Status { get; set; }

        /// <summary>
        /// A short description of the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// ID of the supplier organization that has been asked to assist with the request. The supplier organization is automatically selected in this field after a service instance has been selected that is provided by an external service provider organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request has been registered at the supplier organization. If the supplier provided a link to the request, enter the entire URL in this field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// Used to specify the support domain account ID in which the request is to be registered. This parameter needs to be specified when the current user&apos;s Person record is registered in a directory account. The ID of a 4me account can be found in the &apos;Account Overview&apos; section of the Settings console.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportDomain { get; set; }

        /// <summary>
        /// ID of the team to which the request is to be assigned. By default, the first line team of the service instance that is related to the request will be selected. If a first line team has not been specified for the service instance, the support team of the service instance will be selected instead.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// ID of the request template to apply to the request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// Setting to true marks request as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 46, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Urgent { get; set; } = false;

        /// <summary>
        /// The date and time at which the status of the request is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// ID of workflow to link request to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 48, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowId { get; set; }

        /// <summary>
        /// An array of request properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 49, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestField[] Properties { get; set; } = Array.Empty<RequestField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 50, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            RequestCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Addressed"))
            {
                input.Addressed = Addressed;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardColumnId"))
            {
                input.AgileBoardColumnId = AgileBoardColumnId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardColumnPosition"))
            {
                input.AgileBoardColumnPosition = AgileBoardColumnPosition;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardId"))
            {
                input.AgileBoardId = AgileBoardId;
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
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemIds"))
            {
                input.ConfigurationItemIds = ConfigurationItemIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("DesiredCompletionAt"))
            {
                input.DesiredCompletionAt = DesiredCompletionAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DowntimeEndAt"))
            {
                input.DowntimeEndAt = DowntimeEndAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DowntimeStartAt"))
            {
                input.DowntimeStartAt = DowntimeStartAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("GroupedIntoId"))
            {
                input.GroupedIntoId = GroupedIntoId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Impact"))
            {
                input.Impact = Impact;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InternalNote"))
            {
                input.InternalNote = InternalNote;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InternalNoteAttachments"))
            {
                input.InternalNoteAttachments = InternalNoteAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeArticleId"))
            {
                #pragma warning disable CS0618
                input.KnowledgeArticleId = KnowledgeArticleId;
                WriteWarning("KnowledgeArticleId is deprecated: Use `knowledgeArticleIds` instead.");
                #pragma warning restore CS0618
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeArticleIds"))
            {
                input.KnowledgeArticleIds = KnowledgeArticleIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("MajorIncidentStatus"))
            {
                input.MajorIncidentStatus = MajorIncidentStatus;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MemberId"))
            {
                input.MemberId = MemberId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewTags"))
            {
                input.NewTags = NewTags.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewWatches"))
            {
                input.NewWatches = NewWatches.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoteAttachments"))
            {
                input.NoteAttachments = NoteAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProblemId"))
            {
                input.ProblemId = ProblemId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductBacklogEstimate"))
            {
                input.ProductBacklogEstimate = ProductBacklogEstimate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductBacklogId"))
            {
                input.ProductBacklogId = ProductBacklogId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductBacklogPosition"))
            {
                input.ProductBacklogPosition = ProductBacklogPosition;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProjectId"))
            {
                input.ProjectId = ProjectId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProviderNotAccountable"))
            {
                input.ProviderNotAccountable = ProviderNotAccountable;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestedById"))
            {
                input.RequestedById = RequestedById;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestedForId"))
            {
                input.RequestedForId = RequestedForId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reviewed"))
            {
                input.Reviewed = Reviewed;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceId"))
            {
                input.ServiceInstanceId = ServiceInstanceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupplierId"))
            {
                input.SupplierId = SupplierId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupplierRequestID"))
            {
                input.SupplierRequestID = SupplierRequestID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportDomain"))
            {
                input.SupportDomain = SupportDomain;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamId"))
            {
                input.TeamId = TeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TemplateId"))
            {
                input.TemplateId = TemplateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeSpent"))
            {
                input.TimeSpent = TimeSpent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeSpentEffortClassId"))
            {
                input.TimeSpentEffortClassId = TimeSpentEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Urgent"))
            {
                input.Urgent = Urgent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WaitingUntil"))
            {
                input.WaitingUntil = WaitingUntil;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowId"))
            {
                input.WorkflowId = WorkflowId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            RequestCreatePayload result = client.Sdk4meClient.Mutation(input, new RequestQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewRequestError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Request);
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
