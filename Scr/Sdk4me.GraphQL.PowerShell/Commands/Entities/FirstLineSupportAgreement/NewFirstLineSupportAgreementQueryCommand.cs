using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new First line support agreement query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "FirstLineSupportAgreementQuery")]
    [OutputType(typeof(FirstLineSupportAgreement))]
    public class NewFirstLineSupportAgreementQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the first line support agreement query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a first line support agreement properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementField[] Properties { get; set; } = Array.Empty<FirstLineSupportAgreementField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementOrderField OrderBy { get; set; }

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
        /// Specify the Customer to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Customer { get; set; } = new();

        /// <summary>
        /// Specify the Customer account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery CustomerAccount { get; set; } = new();

        /// <summary>
        /// Specify the Customer representative to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery CustomerRepresentative { get; set; } = new();

        /// <summary>
        /// Specify the Invoices to be returned using an invoice query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceQuery Invoices { get; set; } = new();

        /// <summary>
        /// Specify the Provider to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Provider { get; set; } = new();

        /// <summary>
        /// Specify the Remarks attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RemarksAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Service desk team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery ServiceDeskTeam { get; set; } = new();

        /// <summary>
        /// Specify the Support hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHours { get; set; } = new();

        /// <summary>
        /// Specify the Target details attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery TargetDetailsAttachments { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a first line support agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<FirstLineSupportAgreementQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<FirstLineSupportAgreementQuery>>();

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
            FirstLineSupportAgreementQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("Customer"))
            {
                retval.SelectCustomer(Customer);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerAccount"))
            {
                retval.SelectCustomerAccount(CustomerAccount);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerRepresentative"))
            {
                retval.SelectCustomerRepresentative(CustomerRepresentative);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Invoices"))
            {
                retval.SelectInvoices(Invoices);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Provider"))
            {
                retval.SelectProvider(Provider);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                retval.SelectRemarksAttachments(RemarksAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceDeskTeam"))
            {
                retval.SelectServiceDeskTeam(ServiceDeskTeam);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHours"))
            {
                retval.SelectSupportHours(SupportHours);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TargetDetailsAttachments"))
            {
                retval.SelectTargetDetailsAttachments(TargetDetailsAttachments);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<FirstLineSupportAgreementQuery> filter in Filters)
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
