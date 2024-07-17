using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new timesheet setting.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TimesheetSetting")]
    [OutputType(typeof(TimesheetSetting))]
    public class NewTimesheetSettingCommand : PSCmdlet
    {
        /// <summary>
        /// The name of the timesheet settings.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked need to register their time in hours and minutes, or as a percentage of a workday.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimesheetSettingUnit Unit { get; set; }

        /// <summary>
        /// Whether people of the related organizations need to be able to register time entries for the time allocations that are linked to their organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AllocationTimeTracking { get; set; } = false;

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single day than the amount of time specified in the Workday field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AllowWorkdayOvertime { get; set; } = false;

        /// <summary>
        /// Whether the people of the organizations to which the timesheet settings are linked are allowed to register more time for a single week than the amount of time specified in the Workweek field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AllowWorkweekOvertime { get; set; } = false;

        /// <summary>
        /// Whether the Time spent field needs to be available in requests, problems and tasks for specialists of the related organizations to specify how long they have worked on their assignments.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AssignmentTimeTracking { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the timesheet settings may no longer be related to any more organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifiers of effort classes of the timesheet setting.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] EffortClassIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether an email notification should be sent to each person who registered fewer hours for the past week than the workweek hours.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool NotifyOnIncomplete { get; set; } = false;

        /// <summary>
        /// Identifiers of organizations of the timesheet setting.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OrganizationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The minimum amount percentage of a workday that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This percentage of a workday is also the increment by which they can increase this minimum percentage of a workday.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingPercentageIncrement? PercentageIncrement { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProblemEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProjectTaskEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestEffortClassId { get; set; }

        /// <summary>
        /// Whether the Note field needs to become required, when someone in an organization linked to the timesheet settings registers time on a request, problem or task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool RequireNote { get; set; } = false;

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a workflow task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TaskEffortClassId { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone in an organization linked to the timesheet settings registers time on a time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationEffortClassId { get; set; }

        /// <summary>
        /// The minimum amount of time that the people of the organizations to which the timesheet settings are linked can select when they register a time entry. This amount of time is also the increment by which they can increase this minimum amount of time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public TimesheetSettingTimeIncrement? TimeIncrement { get; set; }

        /// <summary>
        /// The duration of a workday in minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Workday { get; set; }

        /// <summary>
        /// The duration of a workweek in minutes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Workweek { get; set; }

        /// <summary>
        /// An array of timesheet setting properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimesheetSettingField[] Properties { get; set; } = Array.Empty<TimesheetSettingField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            TimesheetSettingCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Unit"))
            {
                input.Unit = Unit;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AllocationTimeTracking"))
            {
                input.AllocationTimeTracking = AllocationTimeTracking;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AllowWorkdayOvertime"))
            {
                input.AllowWorkdayOvertime = AllowWorkdayOvertime;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AllowWorkweekOvertime"))
            {
                input.AllowWorkweekOvertime = AllowWorkweekOvertime;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssignmentTimeTracking"))
            {
                input.AssignmentTimeTracking = AssignmentTimeTracking;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassIds"))
            {
                input.EffortClassIds = EffortClassIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NotifyOnIncomplete"))
            {
                input.NotifyOnIncomplete = NotifyOnIncomplete;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationIds"))
            {
                input.OrganizationIds = OrganizationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PercentageIncrement"))
            {
                input.PercentageIncrement = PercentageIncrement;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProblemEffortClassId"))
            {
                input.ProblemEffortClassId = ProblemEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProjectTaskEffortClassId"))
            {
                input.ProjectTaskEffortClassId = ProjectTaskEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestEffortClassId"))
            {
                input.RequestEffortClassId = RequestEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequireNote"))
            {
                input.RequireNote = RequireNote;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TaskEffortClassId"))
            {
                input.TaskEffortClassId = TaskEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeAllocationEffortClassId"))
            {
                input.TimeAllocationEffortClassId = TimeAllocationEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeIncrement"))
            {
                input.TimeIncrement = TimeIncrement;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Workday"))
            {
                input.Workday = Workday;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Workweek"))
            {
                input.Workweek = Workweek;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TimesheetSettingCreatePayload result = client.Sdk4meClient.Mutation(input, new TimesheetSettingQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTimesheetSettingError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.TimesheetSetting);
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
