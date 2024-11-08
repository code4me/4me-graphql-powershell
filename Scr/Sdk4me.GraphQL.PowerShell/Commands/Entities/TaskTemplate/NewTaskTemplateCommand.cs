﻿using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new task template.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TaskTemplate")]
    [OutputType(typeof(TaskTemplate))]
    public class NewTaskTemplateCommand : PSCmdlet
    {
        /// <summary>
        /// The category that needs to be selected in the Category field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskCategory Category { get; set; }

        /// <summary>
        /// The number of minutes that should be entered in the Planned duration field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long PlannedDuration { get; set; } = 0;

        /// <summary>
        /// A short description that needs to be copied to the Subject field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Requested for field of the request for which the workflow is being generated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequester { get; set; } = false;

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the business unit to which the organization belongs that is linked to the person who is selected in the Requested for field of the request for which the workflow is being generated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequesterBusinessUnitManager { get; set; } = false;

        /// <summary>
        /// Whether the manager of the requester of the first related request is to be selected in the Approver field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToRequesterManager { get; set; } = false;

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Service owner field of the service that is linked to the workflow that the new task is a part of.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToServiceOwner { get; set; } = false;

        /// <summary>
        /// Whether a new task that is being created based on the template is to be assigned to the person who is selected in the Manager field of the workflow to which the task belongs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignToWorkflowManager { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the configuration items of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ConfigurationItemIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether the Copy note to workflow box of tasks that were created based on the template needs to be checked by default. (The Copy notes to workflow checkbox is called &quot;Copy notes to workflow by default&quot; when the task template is in Edit mode.)
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool CopyNotesToWorkflow { get; set; } = false;

        /// <summary>
        /// Whether the task template may not be used to help register new tasks.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a task created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// The impact level that needs to be selected in the Impact field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public TaskImpact? Impact { get; set; }

        /// <summary>
        /// The information that needs to be copied to the Instructions field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Instructions { get; set; }

        /// <summary>
        /// Identifier of the person who should be selected in the Member field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MemberId { get; set; }

        /// <summary>
        /// Approvals of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public TaskTemplateApprovalInput[] NewApprovals { get; set; } = Array.Empty<TaskTemplateApprovalInput>();

        /// <summary>
        /// The information that needs to be copied to the Note field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifier of the PDF design that needs to be copied to the PDF design field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PdfDesignId { get; set; }

        /// <summary>
        /// The number of minutes the member is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffort { get; set; }

        /// <summary>
        /// The number of minutes the person, who is selected in the Requested for field of the first related request, is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequester { get; set; }

        /// <summary>
        /// The number of minutes the business unit manager of the requester of the first related request is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterBusinessUnitManager { get; set; }

        /// <summary>
        /// The number of minutes the manager of the requester of the first related request is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortRequesterManager { get; set; }

        /// <summary>
        /// The number of minutes the owner of the service of the related to the workflow is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortServiceOwner { get; set; }

        /// <summary>
        /// The number of minutes the workflow manager is expected to spend working on a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PlannedEffortWorkflowManager { get; set; }

        /// <summary>
        /// Default: false - Whether the provider indicates not to be accountable for the affected SLAs linked to the requests that are linked to the workflow of a task that was created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool ProviderNotAccountable { get; set; } = false;

        /// <summary>
        /// Identifier of the service instance that should be selected in the Request service instance field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestServiceInstanceId { get; set; }

        /// <summary>
        /// Identifier of the request template that should be selected in the Request template field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestTemplateId { get; set; }

        /// <summary>
        /// The number that needs to be specified in the Required approvals field of a new approval task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RequiredApprovals { get; set; }

        /// <summary>
        /// Identifiers of the service instances of the task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceInstanceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the supplier organization that should be selected in the Supplier field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team that should be selected in the Team field of a new task when it is being created based on the template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether a new task that is created based on the template is to be marked as urgent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Urgent { get; set; } = false;

        /// <summary>
        /// Whether the completion target of tasks created based on the template are calculated using a 24x7 calendar rather than normal business hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool WorkHoursAre24x7 { get; set; } = false;

        /// <summary>
        /// An array of task template properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskTemplateField[] Properties { get; set; } = Array.Empty<TaskTemplateField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
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
            TaskTemplateCreateInput  input = new();
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
            if (MyInvocation.BoundParameters.ContainsKey("AssignToWorkflowManager"))
            {
                input.AssignToWorkflowManager = AssignToWorkflowManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemIds"))
            {
                input.ConfigurationItemIds = ConfigurationItemIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("CopyNotesToWorkflow"))
            {
                input.CopyNotesToWorkflow = CopyNotesToWorkflow;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Impact"))
            {
                input.Impact = Impact;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Instructions"))
            {
                input.Instructions = Instructions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MemberId"))
            {
                input.MemberId = MemberId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewApprovals"))
            {
                input.NewApprovals = NewApprovals.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("PlannedEffortWorkflowManager"))
            {
                input.PlannedEffortWorkflowManager = PlannedEffortWorkflowManager;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProviderNotAccountable"))
            {
                input.ProviderNotAccountable = ProviderNotAccountable;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestServiceInstanceId"))
            {
                input.RequestServiceInstanceId = RequestServiceInstanceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestTemplateId"))
            {
                input.RequestTemplateId = RequestTemplateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequiredApprovals"))
            {
                input.RequiredApprovals = RequiredApprovals;
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
            if (MyInvocation.BoundParameters.ContainsKey("Urgent"))
            {
                input.Urgent = Urgent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursAre24x7"))
            {
                input.WorkHoursAre24x7 = WorkHoursAre24x7;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TaskTemplateCreatePayload result = client.Sdk4meClient.Mutation(input, new TaskTemplateQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTaskTemplateError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.TaskTemplate);
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
