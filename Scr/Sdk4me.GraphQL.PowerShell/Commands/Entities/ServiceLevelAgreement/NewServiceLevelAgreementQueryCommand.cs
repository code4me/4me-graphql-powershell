using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Service level agreement query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ServiceLevelAgreementQuery")]
    [OutputType(typeof(ServiceLevelAgreement))]
    public class NewServiceLevelAgreementQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the service level agreement query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a service level agreement properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementField[] Properties { get; set; } = Array.Empty<ServiceLevelAgreementField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementOrderField OrderBy { get; set; }

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
        /// Specify the Activity ID to be returned using an activity identifier query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ActivityIDQuery ActivityID { get; set; } = new();

        /// <summary>
        /// Specify the Coverage groups to be returned using a service level agreement coverage group query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaCoverageGroupQuery CoverageGroups { get; set; } = new();

        /// <summary>
        /// Specify the Customer to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Customer { get; set; } = new();

        /// <summary>
        /// Specify the Customer account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery CustomerAccount { get; set; } = new();

        /// <summary>
        /// Specify the Customer representatives to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery CustomerRepresentatives { get; set; } = new();

        /// <summary>
        /// Specify the Effort class rate IDs to be returned using an effort class rate identifier query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateIDQuery EffortClassRateIDs { get; set; } = new();

        /// <summary>
        /// Specify the Invoices to be returned using an invoice query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery Invoices { get; set; } = new();

        /// <summary>
        /// Specify the Organizations to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organizations { get; set; } = new();

        /// <summary>
        /// Specify the People to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery People { get; set; } = new();

        /// <summary>
        /// Specify the Remarks attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RemarksAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Service instance to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstance { get; set; } = new();

        /// <summary>
        /// Specify the Service instances to be returned using a parent service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ParentServiceInstanceQuery ServiceInstances { get; set; } = new();

        /// <summary>
        /// Specify the Service level manager to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery ServiceLevelManager { get; set; } = new();

        /// <summary>
        /// Specify the Service offering to be returned using a service offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery ServiceOffering { get; set; } = new();

        /// <summary>
        /// Specify the Sites to be returned using a site query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery Sites { get; set; } = new();

        /// <summary>
        /// Specify the Skill pools to be returned using a skill pool query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery SkillPools { get; set; } = new();

        /// <summary>
        /// Specify the Standard service request activity IDs to be returned using a standard service request activity identifier query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestActivityIDQuery StandardServiceRequestActivityIDs { get; set; } = new();

        /// <summary>
        /// Specify the Support domain to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery SupportDomain { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ServiceLevelAgreementQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<ServiceLevelAgreementQuery>>();

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
            ServiceLevelAgreementQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("ActivityID"))
            {
                retval.SelectActivityID(ActivityID);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CoverageGroups"))
            {
                retval.SelectCoverageGroups(CoverageGroups);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Customer"))
            {
                retval.SelectCustomer(Customer);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerAccount"))
            {
                retval.SelectCustomerAccount(CustomerAccount);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerRepresentatives"))
            {
                retval.SelectCustomerRepresentatives(CustomerRepresentatives);
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClassRateIDs"))
            {
                retval.SelectEffortClassRateIDs(EffortClassRateIDs);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Invoices"))
            {
                retval.SelectInvoices(Invoices);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Organizations"))
            {
                retval.SelectOrganizations(Organizations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("People"))
            {
                retval.SelectPeople(People);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                retval.SelectRemarksAttachments(RemarksAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstance"))
            {
                retval.SelectServiceInstance(ServiceInstance);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstances"))
            {
                retval.SelectServiceInstances(ServiceInstances);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceLevelManager"))
            {
                retval.SelectServiceLevelManager(ServiceLevelManager);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceOffering"))
            {
                retval.SelectServiceOffering(ServiceOffering);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Sites"))
            {
                retval.SelectSites(Sites);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPools"))
            {
                retval.SelectSkillPools(SkillPools);
            }
            if (MyInvocation.BoundParameters.ContainsKey("StandardServiceRequestActivityIDs"))
            {
                retval.SelectStandardServiceRequestActivityIDs(StandardServiceRequestActivityIDs);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportDomain"))
            {
                retval.SelectSupportDomain(SupportDomain);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<ServiceLevelAgreementQuery> filter in Filters)
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
