using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Request template query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "RequestTemplateQuery")]
    [OutputType(typeof(RequestTemplate))]
    public class NewRequestTemplateQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the request template query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a request template properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateField[] Properties { get; set; } = Array.Empty<RequestTemplateField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateOrderField OrderBy { get; set; }

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
        /// Specify the Automation rules to be returned using an automation rule query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery AutomationRules { get; set; } = new();

        /// <summary>
        /// Specify the Configuration item to be returned using a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery ConfigurationItem { get; set; } = new();

        /// <summary>
        /// Specify the Effort class to be returned using an effort class query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery EffortClass { get; set; } = new();

        /// <summary>
        /// Specify the Instructions attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery InstructionsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Member to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Member { get; set; } = new();

        /// <summary>
        /// Specify the Note attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery NoteAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Organizations to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organizations { get; set; } = new();

        /// <summary>
        /// Specify the Registration hints attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery RegistrationHintsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Requests to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery Requests { get; set; } = new();

        /// <summary>
        /// Specify the Reservation offerings to be returned using a reservation offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReservationOfferingQuery ReservationOfferings { get; set; } = new();

        /// <summary>
        /// Specify the Service to be returned using a service query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery Service { get; set; } = new();

        /// <summary>
        /// Specify the Standard service requests to be returned using a standard service request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestQuery StandardServiceRequests { get; set; } = new();

        /// <summary>
        /// Specify the Supplier to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Supplier { get; set; } = new();

        /// <summary>
        /// Specify the Support hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHours { get; set; } = new();

        /// <summary>
        /// Specify the Team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery Team { get; set; } = new();

        /// <summary>
        /// Specify the Translations to be returned using a translation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery Translations { get; set; } = new();

        /// <summary>
        /// Specify the UI extension to be returned using an user interface extension query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery UiExtension { get; set; } = new();

        /// <summary>
        /// Specify the Workflow manager to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery WorkflowManager { get; set; } = new();

        /// <summary>
        /// Specify the Workflow template to be returned using a workflow template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery WorkflowTemplate { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a request template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<RequestTemplateQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<RequestTemplateQuery>>();

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
            RequestTemplateQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("AutomationRules"))
            {
                retval.SelectAutomationRules(AutomationRules);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItem"))
            {
                retval.SelectConfigurationItem(ConfigurationItem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("EffortClass"))
            {
                retval.SelectEffortClass(EffortClass);
            }
            if (MyInvocation.BoundParameters.ContainsKey("InstructionsAttachments"))
            {
                retval.SelectInstructionsAttachments(InstructionsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Member"))
            {
                retval.SelectMember(Member);
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoteAttachments"))
            {
                retval.SelectNoteAttachments(NoteAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Organizations"))
            {
                retval.SelectOrganizations(Organizations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RegistrationHintsAttachments"))
            {
                retval.SelectRegistrationHintsAttachments(RegistrationHintsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Requests"))
            {
                retval.SelectRequests(Requests);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ReservationOfferings"))
            {
                retval.SelectReservationOfferings(ReservationOfferings);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Service"))
            {
                retval.SelectService(Service);
            }
            if (MyInvocation.BoundParameters.ContainsKey("StandardServiceRequests"))
            {
                retval.SelectStandardServiceRequests(StandardServiceRequests);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Supplier"))
            {
                retval.SelectSupplier(Supplier);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHours"))
            {
                retval.SelectSupportHours(SupportHours);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Team"))
            {
                retval.SelectTeam(Team);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Translations"))
            {
                retval.SelectTranslations(Translations);
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtension"))
            {
                retval.SelectUiExtension(UiExtension);
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
                foreach (QueryFilter<RequestTemplateQuery> filter in Filters)
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
