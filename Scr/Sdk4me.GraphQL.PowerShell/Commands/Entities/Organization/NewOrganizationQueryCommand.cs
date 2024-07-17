using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Organization query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "OrganizationQuery")]
    [OutputType(typeof(Organization))]
    public class NewOrganizationQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the organization query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of an organization properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationField[] Properties { get; set; } = Array.Empty<OrganizationField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationOrderField OrderBy { get; set; }

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
        /// Specify the Addresses to be returned using an address query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AddressQuery Addresses { get; set; } = new();

        /// <summary>
        /// Specify the Business unit organization to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery BusinessUnitOrganization { get; set; } = new();

        /// <summary>
        /// Specify the Child organizations to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery ChildOrganizations { get; set; } = new();

        /// <summary>
        /// Specify the Contacts to be returned using a contact query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContactQuery Contacts { get; set; } = new();

        /// <summary>
        /// Specify the Contracts to be returned using a contract query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContractQuery Contracts { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields to be returned using a custom field query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery CustomFields { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery CustomFieldsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Manager to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Manager { get; set; } = new();

        /// <summary>
        /// Specify the Order template to be returned using a request template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery OrderTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Parent to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Parent { get; set; } = new();

        /// <summary>
        /// Specify the People to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery People { get; set; } = new();

        /// <summary>
        /// Specify the Remarks attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RemarksAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Risks to be returned using a risk query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery Risks { get; set; } = new();

        /// <summary>
        /// Specify the Service level agreements to be returned using a service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementQuery ServiceLevelAgreements { get; set; } = new();

        /// <summary>
        /// Specify the Substitute to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Substitute { get; set; } = new();

        /// <summary>
        /// Specify the Time allocations to be returned using a time allocation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationQuery TimeAllocations { get; set; } = new();

        /// <summary>
        /// Specify the UI extension to be returned using an user interface extension query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery UiExtension { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<OrganizationQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<OrganizationQuery>>();

        /// <summary>
        /// A custom filter to apply to the an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            OrganizationQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("Addresses"))
            {
                retval.SelectAddresses(Addresses);
            }
            if (MyInvocation.BoundParameters.ContainsKey("BusinessUnitOrganization"))
            {
                retval.SelectBusinessUnitOrganization(BusinessUnitOrganization);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ChildOrganizations"))
            {
                retval.SelectChildOrganizations(ChildOrganizations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Contacts"))
            {
                retval.SelectContacts(Contacts);
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
            if (MyInvocation.BoundParameters.ContainsKey("Manager"))
            {
                retval.SelectManager(Manager);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrderTemplate"))
            {
                retval.SelectOrderTemplate(OrderTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Parent"))
            {
                retval.SelectParent(Parent);
            }
            if (MyInvocation.BoundParameters.ContainsKey("People"))
            {
                retval.SelectPeople(People);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                retval.SelectRemarksAttachments(RemarksAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Risks"))
            {
                retval.SelectRisks(Risks);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceLevelAgreements"))
            {
                retval.SelectServiceLevelAgreements(ServiceLevelAgreements);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Substitute"))
            {
                retval.SelectSubstitute(Substitute);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeAllocations"))
            {
                retval.SelectTimeAllocations(TimeAllocations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtension"))
            {
                retval.SelectUiExtension(UiExtension);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<OrganizationQuery> filter in Filters)
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
