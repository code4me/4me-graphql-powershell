using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new time entry.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TimeEntry")]
    [OutputType(typeof(TimeEntry))]
    public class NewTimeEntryCommand : PSCmdlet
    {
        /// <summary>
        /// The number of minutes that was spent on the selected time allocation. The number of minutes is allowed to be negative only when the correction field is set to true.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long TimeSpent { get; set; } = 0;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the time entry should be considered a correction for a time entry that was registered for a date that has already been locked.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Correction { get; set; } = false;

        /// <summary>
        /// Identifier of the organization for which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CustomerId { get; set; }

        /// <summary>
        /// The date on which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? Date { get; set; }
#else
        public DateTime? Date { get; set; }
#endif

        /// <summary>
        /// Automatically checked after the time entry has been deleted. The data of a deleted time entry that is older than 3 months can no longer be retrieved.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// A short description of the time spent. This field is available and required only when the Description required box is checked in the selected time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// Identifier of the effort class that best reflects the type of effort for which time spent is being registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// Identifier of the note the time entry is linked to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? NoteId { get; set; }

        /// <summary>
        /// Identifier of the organization to which the person was linked when the time entry was created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Identifier of the person who spent the time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PersonId { get; set; }

        /// <summary>
        /// Identifier of the service for which the time was spent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The start time of the work.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartedAt { get; set; }

        /// <summary>
        /// Identifier of the team the person of the time entry was a member of while the work was performed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TeamId { get; set; }

        /// <summary>
        /// Identifier of the time allocation on which the time was spent. Only the time allocations that are linked to the person’s organization can be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationId { get; set; }

        /// <summary>
        /// An array of time entry properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryField[] Properties { get; set; } = Array.Empty<TimeEntryField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            TimeEntryCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("TimeSpent"))
            {
                input.TimeSpent = TimeSpent;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Correction"))
            {
                input.Correction = Correction;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerId"))
            {
                input.CustomerId = CustomerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Date"))
            {
                input.Date = Date;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Deleted"))
            {
                input.Deleted = Deleted;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoteId"))
            {
                input.NoteId = NoteId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationId"))
            {
                input.OrganizationId = OrganizationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PersonId"))
            {
                input.PersonId = PersonId;
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
            if (MyInvocation.BoundParameters.ContainsKey("StartedAt"))
            {
                input.StartedAt = StartedAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamId"))
            {
                input.TeamId = TeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeAllocationId"))
            {
                input.TimeAllocationId = TimeAllocationId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TimeEntryCreatePayload result = client.Sdk4meClient.Mutation(input, new TimeEntryQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTimeEntryError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.TimeEntry);
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
