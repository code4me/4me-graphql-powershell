using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a project task.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "ProjectTask")]
    [OutputType(typeof(ProjectTask))]
    public class SetProjectTaskCommand : PSCmdlet
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
        /// Automatically set to the current date and time when the project task is assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? AssignedAt { get; set; }

        /// <summary>
        /// Identifiers of assignments to remove from the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] AssignmentsToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The category of the project task. Activity tasks are used to assign project-related work to people. Approval tasks are used to collect approvals for projects. Milestones are used to mark specific points along a project&apos;s implementation plan.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskCategory? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

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
        /// The date and time at which the milestone needs to have been reached.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// Used to provide instructions for the person(s) to whom the project task will be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// Assignments of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskAssignmentInput[] NewAssignments { get; set; } = Array.Empty<ProjectTaskAssignmentInput>();

        /// <summary>
        /// Used to provide information for the person to whom the project task is assigned. It is also used to provide a summary of the actions that have been taken to date and the results of these actions.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifier of the PDF design to link to the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// Identifier of the phase of the project to which the project task belongs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PhaseId { get; set; }

        /// <summary>
        /// The number of minutes it is expected to take for the project task to be completed following its assignment, or following its fixed start date and time if the Start no earlier than field is filled out.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedDuration { get; set; }

        /// <summary>
        /// The number of minutes the team is expected to spend working on the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// Identifiers of the predecessors of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] PredecessorIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The number of assignees who need to have provided their approval before the status of the project task gets updated to &quot;Approved&quot;.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Skill pool that represents the specific expertise needed to complete the task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SkillPoolId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Only used when work on the project task may not start before a specific date and time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The current status of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskStatus? Status { get; set; }

        /// <summary>
        /// A short description of the objective of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// Identifiers of the successors of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SuccessorIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The supplier organization that has been asked to assist with the completion of the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// The identifier under which the request to help with the execution of the project task has been registered at the supplier organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierRequestID { get; set; }

        /// <summary>
        /// The team to which the project task is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// The project task template that was used to register the project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// The time that you have spent working on the request since you started to work on it or, if you already entered some time for this request, since you last added your time spent in it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? TimeSpent { get; set; }

        /// <summary>
        /// The effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeSpentEffortClassId { get; set; }

        /// <summary>
        /// Whether the project task is urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Urgent { get; set; } = false;

        /// <summary>
        /// The date and time at which the status of the project task is to be updated from waiting_for to assigned. This field is available only when the Status field is set to waiting_for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? WaitingUntil { get; set; }

        /// <summary>
        /// When set to true, the completion target of the project task is calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool WorkHoursAre24x7 { get; set; } = false;

        /// <summary>
        /// An array of Project task properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskField[] Properties { get; set; } = Array.Empty<ProjectTaskField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ProjectTaskUpdateInput  input = new();
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
            if (MyInvocation.BoundParameters.ContainsKey("AssignedAt"))
            {
                input.AssignedAt = AssignedAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignmentsToDelete"))
            {
                input.AssignmentsToDelete = AssignmentsToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Deadline"))
            {
                input.Deadline = Deadline;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Instructions"))
            {
                input.Instructions = Instructions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewAssignments"))
            {
                input.NewAssignments = NewAssignments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PdfDesignId"))
            {
                input.PdfDesignId = PdfDesignId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PhaseId"))
            {
                input.PhaseId = PhaseId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedDuration"))
            {
                input.PlannedDuration = PlannedDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffort"))
            {
                input.PlannedEffort = PlannedEffort;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PredecessorIds"))
            {
                input.PredecessorIds = PredecessorIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequiredApprovals"))
            {
                input.RequiredApprovals = RequiredApprovals;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPoolId"))
            {
                input.SkillPoolId = SkillPoolId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("StartAt"))
            {
                input.StartAt = StartAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SuccessorIds"))
            {
                input.SuccessorIds = SuccessorIds.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursAre24x7"))
            {
                input.WorkHoursAre24x7 = WorkHoursAre24x7;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ProjectTaskUpdatePayload result = client.Sdk4meClient.Mutation(input, new ProjectTaskQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetProjectTaskError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ProjectTask);
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
