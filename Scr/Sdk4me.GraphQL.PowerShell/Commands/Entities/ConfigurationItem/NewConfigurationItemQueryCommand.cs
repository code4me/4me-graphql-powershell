using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Configuration item query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ConfigurationItemQuery")]
    [OutputType(typeof(ConfigurationItem))]
    public class NewConfigurationItemQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the configuration item query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a configuration item properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemField[] Properties { get; set; } = Array.Empty<ConfigurationItemField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemOrderField OrderBy { get; set; }

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
        /// Specify the Ci relations to be returned using a configuration item relation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemRelationQuery CiRelations { get; set; } = new();

        /// <summary>
        /// Specify the Contracts to be returned using a contract query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContractQuery Contracts { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields to be returned using a custom field query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery CustomFields { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery CustomFieldsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Financial owner to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery FinancialOwner { get; set; } = new();

        /// <summary>
        /// Specify the Invoices to be returned using an invoice query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery Invoices { get; set; } = new();

        /// <summary>
        /// Specify the Licensed sites to be returned using a site query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery LicensedSites { get; set; } = new();

        /// <summary>
        /// Specify the Operating system to be returned using a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery OperatingSystem { get; set; } = new();

        /// <summary>
        /// Specify the Problems to be returned using a problem query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery Problems { get; set; } = new();

        /// <summary>
        /// Specify the Product to be returned using a product query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductQuery Product { get; set; } = new();

        /// <summary>
        /// Specify the Recurrence to be returned using a recurrence query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RecurrenceQuery Recurrence { get; set; } = new();

        /// <summary>
        /// Specify the Remarks attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RemarksAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Requests to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery Requests { get; set; } = new();

        /// <summary>
        /// Specify the Service to be returned using a service query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery Service { get; set; } = new();

        /// <summary>
        /// Specify the Service instances to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstances { get; set; } = new();

        /// <summary>
        /// Specify the Site to be returned using a site query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery Site { get; set; } = new();

        /// <summary>
        /// Specify the Supplier to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Supplier { get; set; } = new();

        /// <summary>
        /// Specify the Support account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery SupportAccount { get; set; } = new();

        /// <summary>
        /// Specify the Support team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery SupportTeam { get; set; } = new();

        /// <summary>
        /// Specify the Users to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Users { get; set; } = new();

        /// <summary>
        /// Specify the Workflow manager to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery WorkflowManager { get; set; } = new();

        /// <summary>
        /// Specify the Workflow template to be returned using a workflow template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery WorkflowTemplate { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ConfigurationItemQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<ConfigurationItemQuery>>();

        /// <summary>
        /// A custom filter to apply to the a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFilter[] CustomFilters { get; set; } = Array.Empty<CustomFilter>();

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
            ConfigurationItemQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("CiRelations"))
            {
                retval.SelectCiRelations(CiRelations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Contracts"))
            {
                retval.SelectContracts(Contracts);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                retval.SelectCustomFields(CustomFields);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                retval.SelectCustomFieldsAttachments(CustomFieldsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("FinancialOwner"))
            {
                retval.SelectFinancialOwner(FinancialOwner);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Invoices"))
            {
                retval.SelectInvoices(Invoices);
            }
            if (MyInvocation.BoundParameters.ContainsKey("LicensedSites"))
            {
                retval.SelectLicensedSites(LicensedSites);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OperatingSystem"))
            {
                retval.SelectOperatingSystem(OperatingSystem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Problems"))
            {
                retval.SelectProblems(Problems);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Product"))
            {
                retval.SelectProduct(Product);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Recurrence"))
            {
                retval.SelectRecurrence(Recurrence);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                retval.SelectRemarksAttachments(RemarksAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Requests"))
            {
                retval.SelectRequests(Requests);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Service"))
            {
                retval.SelectService(Service);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstances"))
            {
                retval.SelectServiceInstances(ServiceInstances);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Site"))
            {
                retval.SelectSite(Site);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Supplier"))
            {
                retval.SelectSupplier(Supplier);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportAccount"))
            {
                retval.SelectSupportAccount(SupportAccount);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportTeam"))
            {
                retval.SelectSupportTeam(SupportTeam);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Users"))
            {
                retval.SelectUsers(Users);
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowManager"))
            {
                retval.SelectWorkflowManager(WorkflowManager);
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowTemplate"))
            {
                retval.SelectWorkflowTemplate(WorkflowTemplate);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<ConfigurationItemQuery> filter in Filters)
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

            if (MyInvocation.BoundParameters.ContainsKey("CustomFilters"))
            {
                foreach (CustomFilter filter in CustomFilters)
                {
                    if (filter.Values != null)
                    {
                        retval.CustomFilter(filter.Name, filter.Operator, filter.Values);
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
