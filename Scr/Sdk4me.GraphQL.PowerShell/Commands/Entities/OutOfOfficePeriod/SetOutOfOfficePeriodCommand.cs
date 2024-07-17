using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating an out of office period.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "OutOfOfficePeriod")]
    [OutputType(typeof(OutOfOfficePeriod))]
    public class SetOutOfOfficePeriodCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the person who is selected as the approval delegate for the out of office period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ApprovalDelegateId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Used to generate time entries for the out of office period. This field is required if the timesheet settings linked to the person&apos;s organization has one or more effort classes.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// End time of the out of office period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Identifier of the person who is out of office.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PersonId { get; set; }

        /// <summary>
        /// The reason of the out of office period. Required when the description category of the time allocation is required.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Reason { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Start time of the out of office period.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// Used to generate time entries for the out of office period. Only the time allocations without service and customer that are linked to the person&apos;s organization can be selected. This field is required if at least one time allocation exists that meets those conditions.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeAllocationId { get; set; }

        /// <summary>
        /// An array of Out of office period properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OutOfOfficePeriodField[] Properties { get; set; } = Array.Empty<OutOfOfficePeriodField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            OutOfOfficePeriodUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ApprovalDelegateId"))
            {
                input.ApprovalDelegateId = ApprovalDelegateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndAt"))
            {
                input.EndAt = EndAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PersonId"))
            {
                input.PersonId = PersonId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reason"))
            {
                input.Reason = Reason;
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
            if (MyInvocation.BoundParameters.ContainsKey("TimeAllocationId"))
            {
                input.TimeAllocationId = TimeAllocationId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            OutOfOfficePeriodUpdatePayload result = client.Sdk4meClient.Mutation(input, new OutOfOfficePeriodQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetOutOfOfficePeriodError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.OutOfOfficePeriod);
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
