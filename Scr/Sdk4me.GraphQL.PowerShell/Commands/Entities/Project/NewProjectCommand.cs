using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new project.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Project")]
    [OutputType(typeof(Project))]
    public class NewProjectCommand : PSCmdlet
    {
        /// <summary>
        /// Identifier of the organization for which the project is to be implemented.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// The reason why the project should be considered for implementation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectJustification Justification { get; set; }

        /// <summary>
        /// Identifier of the person who is responsible for coordinating the implementation of the project.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ManagerId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service for which the project will be implemented.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// A short description of the objective of the project.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Whether the project has been approved and no longer needs to be considered for funding by portfolio management.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool BudgetAllocated { get; set; } = false;

        /// <summary>
        /// The category of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Category { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The appropriate completion reason for the project when it has been completed. It is automatically set to &quot;Complete&quot; when all tasks related to the project have reached the status &quot;Completed&quot;, &quot;Approved&quot; or &quot;Canceled&quot;.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectCompletionReason? CompletionReason { get; set; }

        /// <summary>
        /// The estimated cost of the effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? CostOfEffort { get; set; }

        /// <summary>
        /// The estimated cost of all purchases (for equipment, consulting effort, licenses, etc.) needed to implement the project. Recurring costs that will be incurred following the implementation of the project are to be included for the entire ROI calculation period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? CostOfPurchases { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The estimated number of hours of effort that will be needed from internal employees and/or long-term contractors to implement the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Effort { get; set; }

        /// <summary>
        /// Phases of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectPhaseInput[] NewPhases { get; set; } = Array.Empty<ProjectPhaseInput>();

        /// <summary>
        /// High-level description of the project. It is also used to add any information that could prove useful for anyone involved in the project, including the people whose approval is needed and the people who are helping to implement it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifiers of the problems of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ProblemIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Used to indicate which program the project is a part of.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Program { get; set; }

        /// <summary>
        /// Identifiers of the requests of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] RequestIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The risk level of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RiskLevel { get; set; }

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
        /// Automatically set based on the status of the project&apos;s tasks.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProjectStatus? Status { get; set; }

        /// <summary>
        /// The time zone that applies to the selected work hours.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The estimated financial value that the implementation of the project will deliver for the entire ROI calculation period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? Value { get; set; }

        /// <summary>
        /// Identifiers of the workflows of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] WorkflowIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifier of the calendar that defines the work hours that are to be used to calculate the anticipated assignment and completion target for the tasks of the project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// An array of project properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectField[] Properties { get; set; } = Array.Empty<ProjectField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ProjectCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("CustomerId"))
            {
                input.CustomerId = CustomerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Justification"))
            {
                input.Justification = Justification;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("BudgetAllocated"))
            {
                input.BudgetAllocated = BudgetAllocated;
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
            if (MyInvocation.BoundParameters.ContainsKey("CostOfEffort"))
            {
                input.CostOfEffort = CostOfEffort;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CostOfPurchases"))
            {
                input.CostOfPurchases = CostOfPurchases;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Effort"))
            {
                input.Effort = Effort;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewPhases"))
            {
                input.NewPhases = NewPhases.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProblemIds"))
            {
                input.ProblemIds = ProblemIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Program"))
            {
                input.Program = Program;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestIds"))
            {
                input.RequestIds = RequestIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("RiskLevel"))
            {
                input.RiskLevel = RiskLevel;
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
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Value"))
            {
                input.Value = Value;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowIds"))
            {
                input.WorkflowIds = WorkflowIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursId"))
            {
                input.WorkHoursId = WorkHoursId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ProjectCreatePayload result = client.Sdk4meClient.Mutation(input, new ProjectQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewProjectError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Project);
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
