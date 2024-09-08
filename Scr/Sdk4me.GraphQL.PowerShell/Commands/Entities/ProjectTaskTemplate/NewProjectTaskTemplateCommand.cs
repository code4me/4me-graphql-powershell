using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new project task template.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ProjectTaskTemplate")]
    [OutputType(typeof(ProjectTaskTemplate))]
    public class NewProjectTaskTemplateCommand : PSCmdlet
    {
        /// <summary>
        /// The category that needs to be selected in the Category field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskCategory Category { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that should be entered in the Planned duration field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long PlannedDuration { get; set; } = 0;

        /// <summary>
        /// A short description that needs to be copied to the Subject field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the Agile board column the project task will be placed in.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardColumnId { get; set; }

        /// <summary>
        /// Identifier of the Agile board the project task will be placed on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// Whether the project manager is to be selected in the Assignees field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToProjectManager { get; set; } = false;

        /// <summary>
        /// Whether a new project task that is being created based on the template is to be assigned to the person who is selected in the Requested for field of the request for which the project was registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequester { get; set; } = false;

        /// <summary>
        /// Whether a new project task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the business unit to which the organization belongs that is linked to the person who is selected in the Requested for field of the request for which the project was registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequesterBusinessUnitManager { get; set; } = false;

        /// <summary>
        /// Whether a new project task that is being created based on the template is to be assigned to the manager of the project&apos;s requester.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequesterManager { get; set; } = false;

        /// <summary>
        /// Whether a new project task that is being created based on the template is to be assigned to the person who is selected in the Service owner field of the service that is linked to the project that the new project task is a part of.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToServiceOwner { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the Copy note to project box of project tasks that were created based on the template needs to be checked by default. (The Copy notes to project checkbox is called &quot;Copy notes to project by default&quot; when the project task template is in Edit mode.)
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool CopyNotesToProject { get; set; } = false;

        /// <summary>
        /// Whether the project task template may not be used to help register new project tasks.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a project task created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Instructions field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// Assignments of the project task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectTaskTemplateAssignmentInput[] NewAssignments { get; set; } = Array.Empty<ProjectTaskTemplateAssignmentInput>();

        /// <summary>
        /// The information that needs to be copied to the Note field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifier of the PDF design that needs to be copied to the PDF design field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the team is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the project manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortProjectManager { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the requester is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequester { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the requester&apos;s business unit manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterBusinessUnitManager { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the requester&apos;s manager is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterManager { get; set; }

        /// <summary>
        /// Used to specify the number of minutes that the service owner is expected to spend working on a project task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortServiceOwner { get; set; }

        /// <summary>
        /// The number that needs to be specified in the Required approvals field of a new approval project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Identifier of the skill pool that should be selected in the Skill pool field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SkillPoolId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that should be selected in the Supplier field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the Team that should be selected in the Team field of a new project task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// When set to true, the completion target of project tasks created based on the template are calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool WorkHoursAre24x7 { get; set; } = false;

        /// <summary>
        /// An array of project task template properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateField[] Properties { get; set; } = Array.Empty<ProjectTaskTemplateField>();

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
            ProjectTaskTemplateCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedDuration"))
            {
                input.PlannedDuration = PlannedDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardColumnId"))
            {
                input.AgileBoardColumnId = AgileBoardColumnId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardId"))
            {
                input.AgileBoardId = AgileBoardId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToProjectManager"))
            {
                input.AssignToProjectManager = AssignToProjectManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToRequester"))
            {
                input.AssignToRequester = AssignToRequester;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToRequesterBusinessUnitManager"))
            {
                input.AssignToRequesterBusinessUnitManager = AssignToRequesterBusinessUnitManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToRequesterManager"))
            {
                input.AssignToRequesterManager = AssignToRequesterManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignToServiceOwner"))
            {
                input.AssignToServiceOwner = AssignToServiceOwner;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CopyNotesToProject"))
            {
                input.CopyNotesToProject = CopyNotesToProject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
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
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffort"))
            {
                input.PlannedEffort = PlannedEffort;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortProjectManager"))
            {
                input.PlannedEffortProjectManager = PlannedEffortProjectManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortRequester"))
            {
                input.PlannedEffortRequester = PlannedEffortRequester;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortRequesterBusinessUnitManager"))
            {
                input.PlannedEffortRequesterBusinessUnitManager = PlannedEffortRequesterBusinessUnitManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortRequesterManager"))
            {
                input.PlannedEffortRequesterManager = PlannedEffortRequesterManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortServiceOwner"))
            {
                input.PlannedEffortServiceOwner = PlannedEffortServiceOwner;
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
            if (MyInvocation.BoundParameters.ContainsKey("SupplierId"))
            {
                input.SupplierId = SupplierId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamId"))
            {
                input.TeamId = TeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursAre24x7"))
            {
                input.WorkHoursAre24x7 = WorkHoursAre24x7;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ProjectTaskTemplateCreatePayload result = client.Sdk4meClient.Mutation(input, new ProjectTaskTemplateQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewProjectTaskTemplateError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ProjectTaskTemplate);
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
