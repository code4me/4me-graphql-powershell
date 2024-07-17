using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Affected SLA query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AffectedSlaQuery")]
    [OutputType(typeof(AffectedSla))]
    public class NewAffectedSlaQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the affected SLA query, rendering other filters redundant by directly referencing a specific object.
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string? ID { get; set; }

        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of an affected service level agreement properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AffectedSlaField[] Properties { get; set; } = Array.Empty<AffectedSlaField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AffectedSlaView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AffectedSlaOrderField OrderBy { get; set; }

        /// <summary>
        /// <br>Specifies the sorting order for the order by field.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrderBySortOrder SortOrder { get; set; } = OrderBySortOrder.None;

        /// <summary>
        /// Specify the First line team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery FirstLineTeam { get; set; } = new();

        /// <summary>
        /// Specify the Request to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery Request { get; set; } = new();

        /// <summary>
        /// Specify the Service hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery ServiceHours { get; set; } = new();

        /// <summary>
        /// Specify the Service instance to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstance { get; set; } = new();

        /// <summary>
        /// Specify the Service level agreement to be returned using a service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery ServiceLevelAgreement { get; set; } = new();

        /// <summary>
        /// Specify the Standard service request to be returned using a standard service request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery StandardServiceRequest { get; set; } = new();

        /// <summary>
        /// Specify the Stopped clock periods to be returned using a period query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PeriodQuery StoppedClockPeriods { get; set; } = new();

        /// <summary>
        /// Specify the Supplier to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Supplier { get; set; } = new();

        /// <summary>
        /// Specify the Support hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHours { get; set; } = new();

        /// <summary>
        /// Specify the Support team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery SupportTeam { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the an affected service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<AffectedSlaQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<AffectedSlaQuery>>();

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Constructs and configures the object based on the provided parameters, and outputs it.
        /// </summary>
        protected override void ProcessRecord()
        {
            AffectedSlaQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

            if (MyInvocation.BoundParameters.ContainsKey("ItemsPerRequest"))
            {
                retval.ItemsPerRequest(ItemsPerRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("View"))
            {
                retval.View(View);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrderBy"))
            {
                retval.OrderBy(OrderBy, SortOrder);
            }

            if (MyInvocation.BoundParameters.ContainsKey("FirstLineTeam"))
            {
                retval.SelectFirstLineTeam(FirstLineTeam);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Request"))
            {
                retval.SelectRequest(Request);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceHours"))
            {
                retval.SelectServiceHours(ServiceHours);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstance"))
            {
                retval.SelectServiceInstance(ServiceInstance);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceLevelAgreement"))
            {
                retval.SelectServiceLevelAgreement(ServiceLevelAgreement);
            }
            if (MyInvocation.BoundParameters.ContainsKey("StandardServiceRequest"))
            {
                retval.SelectStandardServiceRequest(StandardServiceRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("StoppedClockPeriods"))
            {
                retval.SelectStoppedClockPeriods(StoppedClockPeriods);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Supplier"))
            {
                retval.SelectSupplier(Supplier);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHours"))
            {
                retval.SelectSupportHours(SupportHours);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportTeam"))
            {
                retval.SelectSupportTeam(SupportTeam);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<AffectedSlaQuery> filter in Filters)
                {
                    if (filter.StringValues != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.StringValues);
                    }
                    else if (filter.DateTimeValues != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.DateTimeValues);
                    }
                    else if (filter.BooleanValue != null)
                    {
                        retval.Filter(filter.Property, filter.Operator, filter.BooleanValue.Value);
                    }
                    else if (filter.Operator.IsNullableOperator())
                    {
                        retval.Filter(filter.Property, filter.Operator);
                    }
                }
            }

            retval.Select(Properties);
            WriteObject(retval);
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
