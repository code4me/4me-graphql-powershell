using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new time allocation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TimeAllocation")]
    [OutputType(typeof(TimeAllocation))]
    public class NewTimeAllocationCommand : PSCmdlet
    {
        /// <summary>
        /// Whether a person who spent on the time allocation needs to select a customer organization, and if this is the case, whether this person may only select from the customer organizations linked to the time allocation or is allowed to select any customer organization.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationCustomerCategory CustomerCategory { get; set; }

        /// <summary>
        /// Whether the Description field should be available, and if so, whether it should be required, in the time entries to which the time allocation is related.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationDescriptionCategory DescriptionCategory { get; set; }

        /// <summary>
        /// The name of the time allocation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Whether a Person who spent on the time allocation needs to select a service, and if this is the case, whether this person may only select from the services linked to the time allocation or is allowed to select any service.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationServiceCategory ServiceCategory { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the customer organizations of the time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] CustomerIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether the time allocation may no longer be related to any more organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on this time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EffortClassId { get; set; }

        /// <summary>
        /// Which group to include the time allocation in.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Group { get; set; }

        /// <summary>
        /// Identifiers of the organizations of the time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OrganizationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of the services of the time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// An array of time allocation properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationField[] Properties { get; set; } = Array.Empty<TimeAllocationField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            TimeAllocationCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("CustomerCategory"))
            {
                input.CustomerCategory = CustomerCategory;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DescriptionCategory"))
            {
                input.DescriptionCategory = DescriptionCategory;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceCategory"))
            {
                input.ServiceCategory = ServiceCategory;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerIds"))
            {
                input.CustomerIds = CustomerIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassId"))
            {
                input.EffortClassId = EffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Group"))
            {
                input.Group = Group;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationIds"))
            {
                input.OrganizationIds = OrganizationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceIds"))
            {
                input.ServiceIds = ServiceIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TimeAllocationCreatePayload result = client.Sdk4meClient.Mutation(input, new TimeAllocationQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTimeAllocationError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.TimeAllocation);
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
