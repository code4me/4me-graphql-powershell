using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a problem.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "Problem")]
    [OutputType(typeof(Problem))]
    public class SetProblemCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

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
        /// Used to specify when the current assignee needs to have completed the root cause analysis of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? AnalysisTargetAt { get; set; }

        /// <summary>
        /// The category of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProblemCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of configuration items of this problem.
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
        /// Used to select the extent to which the service is impacted when an incident occurs that is caused by the problem. Defaults to none.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProblemImpact? Impact { get; set; }

        /// <summary>
        /// Identifier of the knowledge article which instructions should be followed to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? KnowledgeArticleId { get; set; }

        /// <summary>
        /// Whether the underlying cause of the problem has been found and a temporary workaround has been proposed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool KnownError { get; set; } = false;

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the problem through root cause analysis, the proposal of a structural solution and ultimately its closure. Defaults to the current authenticated person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// Identifier of the person to whom the problem is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Detailed description of the symptoms that are caused by the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Estimate of the relative size of this item on the product backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogEstimate { get; set; }

        /// <summary>
        /// Identifier of the product backlog this item is placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProductBacklogId { get; set; }

        /// <summary>
        /// The (one based) position of this item on the backlog.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ProductBacklogPosition { get; set; }

        /// <summary>
        /// Identifier of the project to link the problem to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Identifiers of requests of this problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] RequestIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifier of the service in which instance(s) the problem resides.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// Identifiers of service instances of this problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceInstanceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The current status of the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProblemStatus? Status { get; set; }

        /// <summary>
        /// A short description of the symptoms that the problem causes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that has been asked for a solution to the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request to help with the solution of the problem has been registered at the supplier organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// Identifier of the team to which the problem is to be assigned. Defaults to the support team of the service if no team or member is present.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether the problem has been marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Urgent { get; set; } = false;

        /// <summary>
        /// The date and time at which the status of the problem is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// Used to describe the temporary workaround that should be applied to resolve incidents caused by this problem until a structural solution has been implemented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Workaround { get; set; }

        /// <summary>
        /// Identifier of the workflow that will implement the proposed permanent solution for the problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowId { get; set; }

        /// <summary>
        /// An array of Problem properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemField[] Properties { get; set; } = Array.Empty<ProblemField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ProblemUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
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
            if (MyInvocation.BoundParameters.ContainsKey("AnalysisTargetAt"))
            {
                input.AnalysisTargetAt = AnalysisTargetAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
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
            if (MyInvocation.BoundParameters.ContainsKey("Impact"))
            {
                input.Impact = Impact;
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeArticleId"))
            {
                input.KnowledgeArticleId = KnowledgeArticleId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnownError"))
            {
                input.KnownError = KnownError;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MemberId"))
            {
                input.MemberId = MemberId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
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
            if (MyInvocation.BoundParameters.ContainsKey("RequestIds"))
            {
                input.RequestIds = RequestIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceIds"))
            {
                input.ServiceInstanceIds = ServiceInstanceIds.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("TeamId"))
            {
                input.TeamId = TeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeSpent"))
            {
                input.TimeSpent = TimeSpent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeSpentEffortClassId"))
            {
                input.TimeSpentEffortClassId = TimeSpentEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Urgent"))
            {
                input.Urgent = Urgent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WaitingUntil"))
            {
                input.WaitingUntil = WaitingUntil;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Workaround"))
            {
                input.Workaround = Workaround;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowId"))
            {
                input.WorkflowId = WorkflowId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ProblemUpdatePayload result = client.Sdk4meClient.Mutation(input, new ProblemQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetProblemError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Problem);
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
