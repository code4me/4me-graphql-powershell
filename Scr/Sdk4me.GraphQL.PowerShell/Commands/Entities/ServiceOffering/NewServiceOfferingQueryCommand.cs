using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Service offering query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ServiceOfferingQuery")]
    [OutputType(typeof(ServiceOffering))]
    public class NewServiceOfferingQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the service offering query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a service offering properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingField[] Properties { get; set; } = Array.Empty<ServiceOfferingField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingOrderField OrderBy { get; set; }

        /// <summary>
        /// <br>Specifies the sorting order for the order by field.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrderBySortOrder SortOrder { get; set; } = OrderBySortOrder.None;

        /// <summary>
        /// Specify the Account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery Account { get; set; } = new();

        /// <summary>
        /// Specify the Charges attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery ChargesAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Continuity attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery ContinuityAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Default effort class to be returned using an effort class query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery DefaultEffortClass { get; set; } = new();

        /// <summary>
        /// Specify the Effort classes to be returned using an effort class query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery EffortClasses { get; set; } = new();

        /// <summary>
        /// Specify the Effort class rates to be returned using an effort class rate query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateQuery EffortClassRates { get; set; } = new();

        /// <summary>
        /// Specify the Limitations attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery LimitationsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Penalties attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery PenaltiesAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Performance attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery PerformanceAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Prerequisites attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery PrerequisitesAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Service to be returned using a service query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery Service { get; set; } = new();

        /// <summary>
        /// Specify the Service hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery ServiceHours { get; set; } = new();

        /// <summary>
        /// Specify the Service level agreements to be returned using a service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery ServiceLevelAgreements { get; set; } = new();

        /// <summary>
        /// Specify the Shop articles to be returned using a shop article query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery ShopArticles { get; set; } = new();

        /// <summary>
        /// Specify the SLA notification scheme high to be returned using a service level agreement notification scheme query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery SlaNotificationSchemeHigh { get; set; } = new();

        /// <summary>
        /// Specify the SLA notification scheme low to be returned using a service level agreement notification scheme query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery SlaNotificationSchemeLow { get; set; } = new();

        /// <summary>
        /// Specify the SLA notification scheme medium to be returned using a service level agreement notification scheme query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery SlaNotificationSchemeMedium { get; set; } = new();

        /// <summary>
        /// Specify the SLA notification scheme top to be returned using a service level agreement notification scheme query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery SlaNotificationSchemeTop { get; set; } = new();

        /// <summary>
        /// Specify the Standard service requests to be returned using a standard service request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery StandardServiceRequests { get; set; } = new();

        /// <summary>
        /// Specify the Summary attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery SummaryAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Support hours case to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursCase { get; set; } = new();

        /// <summary>
        /// Specify the Support hours high to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursHigh { get; set; } = new();

        /// <summary>
        /// Specify the Support hours low to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursLow { get; set; } = new();

        /// <summary>
        /// Specify the Support hours medium to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursMedium { get; set; } = new();

        /// <summary>
        /// Specify the Support hours RFC to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursRfc { get; set; } = new();

        /// <summary>
        /// Specify the Support hours RFI to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursRfi { get; set; } = new();

        /// <summary>
        /// Specify the Support hours top to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHoursTop { get; set; } = new();

        /// <summary>
        /// Specify the Termination attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery TerminationAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Waiting for customer follow up to be returned using a waiting for customer follow up query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WaitingForCustomerFollowUpQuery WaitingForCustomerFollowUp { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a service offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ServiceOfferingQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<ServiceOfferingQuery>>();

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
            ServiceOfferingQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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

            if (MyInvocation.BoundParameters.ContainsKey("Account"))
            {
                retval.SelectAccount(Account);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChargesAttachments"))
            {
                retval.SelectChargesAttachments(ChargesAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ContinuityAttachments"))
            {
                retval.SelectContinuityAttachments(ContinuityAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("DefaultEffortClass"))
            {
                retval.SelectDefaultEffortClass(DefaultEffortClass);
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClasses"))
            {
                retval.SelectEffortClasses(EffortClasses);
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassRates"))
            {
                retval.SelectEffortClassRates(EffortClassRates);
            }
            if (MyInvocation.BoundParameters.ContainsKey("LimitationsAttachments"))
            {
                retval.SelectLimitationsAttachments(LimitationsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("PenaltiesAttachments"))
            {
                retval.SelectPenaltiesAttachments(PenaltiesAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("PerformanceAttachments"))
            {
                retval.SelectPerformanceAttachments(PerformanceAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("PrerequisitesAttachments"))
            {
                retval.SelectPrerequisitesAttachments(PrerequisitesAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Service"))
            {
                retval.SelectService(Service);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceHours"))
            {
                retval.SelectServiceHours(ServiceHours);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceLevelAgreements"))
            {
                retval.SelectServiceLevelAgreements(ServiceLevelAgreements);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ShopArticles"))
            {
                retval.SelectShopArticles(ShopArticles);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaNotificationSchemeHigh"))
            {
                retval.SelectSlaNotificationSchemeHigh(SlaNotificationSchemeHigh);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaNotificationSchemeLow"))
            {
                retval.SelectSlaNotificationSchemeLow(SlaNotificationSchemeLow);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaNotificationSchemeMedium"))
            {
                retval.SelectSlaNotificationSchemeMedium(SlaNotificationSchemeMedium);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaNotificationSchemeTop"))
            {
                retval.SelectSlaNotificationSchemeTop(SlaNotificationSchemeTop);
            }
            if (MyInvocation.BoundParameters.ContainsKey("StandardServiceRequests"))
            {
                retval.SelectStandardServiceRequests(StandardServiceRequests);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SummaryAttachments"))
            {
                retval.SelectSummaryAttachments(SummaryAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursCase"))
            {
                retval.SelectSupportHoursCase(SupportHoursCase);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursHigh"))
            {
                retval.SelectSupportHoursHigh(SupportHoursHigh);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursLow"))
            {
                retval.SelectSupportHoursLow(SupportHoursLow);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursMedium"))
            {
                retval.SelectSupportHoursMedium(SupportHoursMedium);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursRfc"))
            {
                retval.SelectSupportHoursRfc(SupportHoursRfc);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursRfi"))
            {
                retval.SelectSupportHoursRfi(SupportHoursRfi);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursTop"))
            {
                retval.SelectSupportHoursTop(SupportHoursTop);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TerminationAttachments"))
            {
                retval.SelectTerminationAttachments(TerminationAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("WaitingForCustomerFollowUp"))
            {
                retval.SelectWaitingForCustomerFollowUp(WaitingForCustomerFollowUp);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<ServiceOfferingQuery> filter in Filters)
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
