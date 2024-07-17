using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a service offering.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "ServiceOffering")]
    [OutputType(typeof(ServiceOffering))]
    public class SetServiceOfferingCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// The duration, expressed as percentage of the total number of service hours, during which the service is to be available to customers with an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? Availability { get; set; }

        /// <summary>
        /// The amount that the service provider will charge the customer for the delivery of the service per charge driver, per charge term.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Charges { get; set; }

        /// <summary>
        /// Defines how a Case must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeCase { get; set; }

        /// <summary>
        /// Defines how a high incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeHigh { get; set; }

        /// <summary>
        /// Defines how a low incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeLow { get; set; }

        /// <summary>
        /// Defines how a medium incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeMedium { get; set; }

        /// <summary>
        /// Defines how a RFC must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeRfc { get; set; }

        /// <summary>
        /// Defines how a RFI must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeRfi { get; set; }

        /// <summary>
        /// Defines how a top incident must be charged: as a Fixed Price or in Time and Materials.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingChargeType? ChargeTypeTop { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The continuity measures for the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Continuity { get; set; }

        /// <summary>
        /// Identifier of the effort class that is selected by default, when someone registers time on a request with an affected SLA linked to this service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? DefaultEffortClassId { get; set; }

        /// <summary>
        /// Identifiers of effort classes of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] EffortClassIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of effort class rates to remove from the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] EffortClassRatesToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The limitations that apply to the service level agreements that are based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Limitations { get; set; }

        /// <summary>
        /// The name of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Effort class rates of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public EffortClassRateInput[] NewEffortClassRates { get; set; } = Array.Empty<EffortClassRateInput>();

        /// <summary>
        /// Standard service requests of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public StandardServiceRequestInput[] NewStandardServiceRequests { get; set; } = Array.Empty<StandardServiceRequestInput>();

        /// <summary>
        /// Used to specify what the penalties will be for the service provider organization if a service level target has been breached.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Penalties { get; set; }

        /// <summary>
        /// Used to describe the transaction(s) and the maximum time these transaction(s) can take to complete.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Performance { get; set; }

        /// <summary>
        /// Used to specify which requirements need to be met by the customer in order for the customer to be able to benefit from the service. The service provider cannot be held accountable for breaches of the service level targets caused by a failure of the customer to meet one or more of these prerequisites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Prerequisites { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a Case.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateCase { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a Case.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateCaseCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a high incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateHigh { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a high incident.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateHighCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a low incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateLow { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a low incident.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateLowCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a medium incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateMedium { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a medium incident.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateMediumCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a RFC.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateRfc { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFC.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateRfcCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a RFI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateRfi { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a RFI.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateRfiCurrency { get; set; }

        /// <summary>
        /// Defines the fixed price rate for a top incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RateTop { get; set; }

        /// <summary>
        /// Defines the currency for the fixed price rate of a top incident.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RateTopCurrency { get; set; }

        /// <summary>
        /// The Recovery Point Objective (RPO) is the maximum targeted duration in minutes in which data (transactions) might be lost from an IT service due to a major incident.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RecoveryPointObjective { get; set; }

        /// <summary>
        /// The Recovery Time Objective (RTO) is the maximum targeted duration in minutes in which a business process must be restored after a disaster (or disruption) in order to avoid unacceptable consequences associated with a break in business continuity.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RecoveryTimeObjective { get; set; }

        /// <summary>
        /// Used to specify the maximum number of times per month that the service may become unavailable to customers with an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Reliability { get; set; }

        /// <summary>
        /// Used to specify how often the representative of a customer of an active SLA that is based on the service offering will receive a report comparing the service level targets specified in the service offering with the actual level of service provided.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingReportFrequency? ReportFrequency { get; set; }

        /// <summary>
        /// The minimum percentage of incidents that is to be resolved before their resolution target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionsWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category &quot;Case&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetCase { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value &quot;High - Service Degraded for Several Users&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetHigh { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value &quot;Low - Service Degraded for One User&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetLow { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value &quot;Medium - Service Down for One User&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetMedium { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category &quot;RFC - Request for Change&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetRfc { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the category &quot;RFI - Request for Information&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 46, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetRfi { get; set; }

        /// <summary>
        /// The number of minutes within which a request with the impact value &quot;Top - Service Down for Several Users&quot; is to be resolved when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResolutionTargetTop { get; set; }

        /// <summary>
        /// The minimum percentage of incidents that is to be responded to before their response target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 48, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponsesWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category &quot;Case&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 49, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetCase { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact &quot;High - Service Degraded for Several Users&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 50, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetHigh { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact &quot;Low - Service Degraded for One User&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 51, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetLow { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact &quot;Medium - Service Down for One User&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 52, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetMedium { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category &quot;RFC - Request for Change&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 53, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetRfc { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the category &quot;RFI - Request for Information&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 54, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetRfi { get; set; }

        /// <summary>
        /// The number of minutes within which a response needs to have been provided for a request with the impact &quot;Top - Service Down for Several Users&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 55, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ResponseTargetTop { get; set; }

        /// <summary>
        /// How often an active SLA that is based on the service offering will be reviewed with the representative of its customer.
        /// </summary>
        [Parameter(Mandatory = false, Position = 56, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingReviewFrequency? ReviewFrequency { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the hours during which the service is supposed to be available.
        /// </summary>
        [Parameter(Mandatory = false, Position = 57, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceHoursId { get; set; }

        /// <summary>
        /// Identifier of the service for which the service offering is being prepared.
        /// </summary>
        [Parameter(Mandatory = false, Position = 58, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 59, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 60, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifiers of standard service requests to remove from the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 61, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] StandardServiceRequestsToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The current status of the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 62, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ServiceOfferingStatus? Status { get; set; }

        /// <summary>
        /// A high-level description of the differentiators between this service offering and other service offerings that have already been, or could be, prepared for the same service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 63, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Summary { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category &quot;Case&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 64, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursCaseId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact &quot;High - Service Degraded for Several Users&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 65, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursHighId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact &quot;Low - Service Degraded for One User&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 66, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursLowId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact &quot;Medium - Service Down for One User&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 67, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursMediumId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category &quot;RFC - Request for Change&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 68, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursRfcId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the category &quot;RFI - Request for Information&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 69, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursRfiId { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours for a request with the impact &quot;Top - Service Down for Several Users&quot; when it affects an active SLA that is based on the service offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 70, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursTopId { get; set; }

        /// <summary>
        /// Used to describe the length of notice required for changing or terminating the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 71, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Termination { get; set; }

        /// <summary>
        /// The time zone that applies to the selected service hours.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 72, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// An array of Service offering properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 73, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingField[] Properties { get; set; } = Array.Empty<ServiceOfferingField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 74, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ServiceOfferingUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Availability"))
            {
                input.Availability = Availability;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Charges"))
            {
                input.Charges = Charges;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeCase"))
            {
                input.ChargeTypeCase = ChargeTypeCase;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeHigh"))
            {
                input.ChargeTypeHigh = ChargeTypeHigh;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeLow"))
            {
                input.ChargeTypeLow = ChargeTypeLow;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeMedium"))
            {
                input.ChargeTypeMedium = ChargeTypeMedium;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeRfc"))
            {
                input.ChargeTypeRfc = ChargeTypeRfc;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeRfi"))
            {
                input.ChargeTypeRfi = ChargeTypeRfi;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargeTypeTop"))
            {
                input.ChargeTypeTop = ChargeTypeTop;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Continuity"))
            {
                input.Continuity = Continuity;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DefaultEffortClassId"))
            {
                input.DefaultEffortClassId = DefaultEffortClassId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassIds"))
            {
                input.EffortClassIds = EffortClassIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassRatesToDelete"))
            {
                input.EffortClassRatesToDelete = EffortClassRatesToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Limitations"))
            {
                input.Limitations = Limitations;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewEffortClassRates"))
            {
                input.NewEffortClassRates = NewEffortClassRates.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewStandardServiceRequests"))
            {
                input.NewStandardServiceRequests = NewStandardServiceRequests.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Penalties"))
            {
                input.Penalties = Penalties;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Performance"))
            {
                input.Performance = Performance;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Prerequisites"))
            {
                input.Prerequisites = Prerequisites;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateCase"))
            {
                input.RateCase = RateCase;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateCaseCurrency"))
            {
                input.RateCaseCurrency = RateCaseCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateHigh"))
            {
                input.RateHigh = RateHigh;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateHighCurrency"))
            {
                input.RateHighCurrency = RateHighCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateLow"))
            {
                input.RateLow = RateLow;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateLowCurrency"))
            {
                input.RateLowCurrency = RateLowCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateMedium"))
            {
                input.RateMedium = RateMedium;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateMediumCurrency"))
            {
                input.RateMediumCurrency = RateMediumCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateRfc"))
            {
                input.RateRfc = RateRfc;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateRfcCurrency"))
            {
                input.RateRfcCurrency = RateRfcCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateRfi"))
            {
                input.RateRfi = RateRfi;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateRfiCurrency"))
            {
                input.RateRfiCurrency = RateRfiCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateTop"))
            {
                input.RateTop = RateTop;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RateTopCurrency"))
            {
                input.RateTopCurrency = RateTopCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecoveryPointObjective"))
            {
                input.RecoveryPointObjective = RecoveryPointObjective;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecoveryTimeObjective"))
            {
                input.RecoveryTimeObjective = RecoveryTimeObjective;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reliability"))
            {
                input.Reliability = Reliability;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ReportFrequency"))
            {
                input.ReportFrequency = ReportFrequency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionsWithinTarget"))
            {
                input.ResolutionsWithinTarget = ResolutionsWithinTarget;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetCase"))
            {
                input.ResolutionTargetCase = ResolutionTargetCase;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetHigh"))
            {
                input.ResolutionTargetHigh = ResolutionTargetHigh;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetLow"))
            {
                input.ResolutionTargetLow = ResolutionTargetLow;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetMedium"))
            {
                input.ResolutionTargetMedium = ResolutionTargetMedium;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetRfc"))
            {
                input.ResolutionTargetRfc = ResolutionTargetRfc;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetRfi"))
            {
                input.ResolutionTargetRfi = ResolutionTargetRfi;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResolutionTargetTop"))
            {
                input.ResolutionTargetTop = ResolutionTargetTop;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponsesWithinTarget"))
            {
                input.ResponsesWithinTarget = ResponsesWithinTarget;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetCase"))
            {
                input.ResponseTargetCase = ResponseTargetCase;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetHigh"))
            {
                input.ResponseTargetHigh = ResponseTargetHigh;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetLow"))
            {
                input.ResponseTargetLow = ResponseTargetLow;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetMedium"))
            {
                input.ResponseTargetMedium = ResponseTargetMedium;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetRfc"))
            {
                input.ResponseTargetRfc = ResponseTargetRfc;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetRfi"))
            {
                input.ResponseTargetRfi = ResponseTargetRfi;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResponseTargetTop"))
            {
                input.ResponseTargetTop = ResponseTargetTop;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ReviewFrequency"))
            {
                input.ReviewFrequency = ReviewFrequency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceHoursId"))
            {
                input.ServiceHoursId = ServiceHoursId;
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
            if (MyInvocation.BoundParameters.ContainsKey("StandardServiceRequestsToDelete"))
            {
                input.StandardServiceRequestsToDelete = StandardServiceRequestsToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Summary"))
            {
                input.Summary = Summary;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursCaseId"))
            {
                input.SupportHoursCaseId = SupportHoursCaseId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursHighId"))
            {
                input.SupportHoursHighId = SupportHoursHighId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursLowId"))
            {
                input.SupportHoursLowId = SupportHoursLowId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursMediumId"))
            {
                input.SupportHoursMediumId = SupportHoursMediumId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursRfcId"))
            {
                input.SupportHoursRfcId = SupportHoursRfcId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursRfiId"))
            {
                input.SupportHoursRfiId = SupportHoursRfiId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursTopId"))
            {
                input.SupportHoursTopId = SupportHoursTopId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Termination"))
            {
                input.Termination = Termination;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ServiceOfferingUpdatePayload result = client.Sdk4meClient.Mutation(input, new ServiceOfferingQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetServiceOfferingError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ServiceOffering);
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
