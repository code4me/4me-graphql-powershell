using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a reservation offering.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "ReservationOffering")]
    [OutputType(typeof(ReservationOffering))]
    public class SetReservationOfferingCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Whether it is allowed to create recurrent reservations for this offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AllowRepeat { get; set; } = false;

        /// <summary>
        /// Calendar that defines the hours in which reservations may start and end.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CalendarId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the configuration items that may be reserved using this offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ConfigurationItemIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether the reservation offering may not be used to register requests for reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The filters of the reservation offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] Filters { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The initial status of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ReservationStatus? InitialStatus { get; set; }

        /// <summary>
        /// The maximum duration between the creation time of a request for reservation and the requested start of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? MaxAdvanceDuration { get; set; }

        /// <summary>
        /// The maximum duration of the reservation within the hours of the calendar.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? MaxDuration { get; set; }

        /// <summary>
        /// The minimum duration between the creation time of a request for reservation and the requested start of the reservation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? MinAdvanceDuration { get; set; }

        /// <summary>
        /// The minimum duration of the reservation within the hours of the calendar.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? MinDuration { get; set; }

        /// <summary>
        /// Whether or not the reservation may span over multiple calendar days.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool MultiDay { get; set; } = false;

        /// <summary>
        /// A short description of the reservation offering
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The duration required to prepare the asset before the reservation starts.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PreparationDuration { get; set; }

        /// <summary>
        /// Reservations of this reservation offering are private and can not be viewed by other end users.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool PrivateReservations { get; set; } = false;

        /// <summary>
        /// Identifier of the service instance for which the reservations may be requested.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The increments with which the reservation may be prolonged.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? StepDuration { get; set; }

        /// <summary>
        /// The time zone that applies to the selected calendar.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// An array of Reservation offering properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOfferingField[] Properties { get; set; } = Array.Empty<ReservationOfferingField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ReservationOfferingUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AllowRepeat"))
            {
                input.AllowRepeat = AllowRepeat;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CalendarId"))
            {
                input.CalendarId = CalendarId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemIds"))
            {
                input.ConfigurationItemIds = ConfigurationItemIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                input.Filters = Filters.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("InitialStatus"))
            {
                input.InitialStatus = InitialStatus;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MaxAdvanceDuration"))
            {
                input.MaxAdvanceDuration = MaxAdvanceDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MaxDuration"))
            {
                input.MaxDuration = MaxDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MinAdvanceDuration"))
            {
                input.MinAdvanceDuration = MinAdvanceDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MinDuration"))
            {
                input.MinDuration = MinDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MultiDay"))
            {
                input.MultiDay = MultiDay;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PreparationDuration"))
            {
                input.PreparationDuration = PreparationDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PrivateReservations"))
            {
                input.PrivateReservations = PrivateReservations;
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
            if (MyInvocation.BoundParameters.ContainsKey("StepDuration"))
            {
                input.StepDuration = StepDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ReservationOfferingUpdatePayload result = client.Sdk4meClient.Mutation(input, new ReservationOfferingQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetReservationOfferingError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ReservationOffering);
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
