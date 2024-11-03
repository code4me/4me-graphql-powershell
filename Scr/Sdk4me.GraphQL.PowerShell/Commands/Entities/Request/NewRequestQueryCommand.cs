using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Request query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "RequestQuery")]
    [OutputType(typeof(Request))]
    public class NewRequestQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the request query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a request properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestField[] Properties { get; set; } = Array.Empty<RequestField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestOrderField OrderBy { get; set; }

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
        /// Specify the Affected SLAs to be returned using an affected service level agreement query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AffectedSlaQuery AffectedSlas { get; set; } = new();

        /// <summary>
        /// Specify the Agile board to be returned using an agile board query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery AgileBoard { get; set; } = new();

        /// <summary>
        /// Specify the Agile board column to be returned using an agile board column query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery AgileBoardColumn { get; set; } = new();

        /// <summary>
        /// Specify the Automation rules to be returned using an automation rule query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery AutomationRules { get; set; } = new();

        /// <summary>
        /// Specify the Configuration items to be returned using a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery ConfigurationItems { get; set; } = new();

        /// <summary>
        /// Specify the Created by to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery CreatedBy { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields to be returned using a custom field query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery CustomFields { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery CustomFieldsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Feedback to be returned using a feedback query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FeedbackQuery Feedback { get; set; } = new();

        /// <summary>
        /// Specify the Feedback on knowledge article to be returned using a knowledge article query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery FeedbackOnKnowledgeArticle { get; set; } = new();

        /// <summary>
        /// Specify the Grouped into to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery GroupedInto { get; set; } = new();

        /// <summary>
        /// Specify the Grouped requests to be returned using a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery GroupedRequests { get; set; } = new();

        /// <summary>
        /// Specify the Knowledge articles to be returned using a knowledge article query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery KnowledgeArticles { get; set; } = new();

        /// <summary>
        /// Specify the Member to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Member { get; set; } = new();

        /// <summary>
        /// Specify the Notes to be returned using a note query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery Notes { get; set; } = new();

        /// <summary>
        /// Specify the Organization to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organization { get; set; } = new();

        /// <summary>
        /// Specify the Problem to be returned using a problem query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery Problem { get; set; } = new();

        /// <summary>
        /// Specify the Product backlog to be returned using a product backlog query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductBacklogQuery ProductBacklog { get; set; } = new();

        /// <summary>
        /// Specify the Project to be returned using a project query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery Project { get; set; } = new();

        /// <summary>
        /// Specify the Requested by to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery RequestedBy { get; set; } = new();

        /// <summary>
        /// Specify the Requested for to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery RequestedFor { get; set; } = new();

        /// <summary>
        /// Specify the Service instance to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstance { get; set; } = new();

        /// <summary>
        /// Specify the Sprint backlog items to be returned using a sprint backlog item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SprintBacklogItemQuery SprintBacklogItems { get; set; } = new();

        /// <summary>
        /// Specify the Supplier to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Supplier { get; set; } = new();

        /// <summary>
        /// Specify the Tags to be returned using a tag query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TagQuery Tags { get; set; } = new();

        /// <summary>
        /// Specify the Task to be returned using a task query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskQuery Task { get; set; } = new();

        /// <summary>
        /// Specify the Team to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery Team { get; set; } = new();

        /// <summary>
        /// Specify the Template to be returned using a request template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery Template { get; set; } = new();

        /// <summary>
        /// Specify the Time entries to be returned using a time entry query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeEntryQuery TimeEntries { get; set; } = new();

        /// <summary>
        /// Specify the Watches to be returned using a watch query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WatchQuery Watches { get; set; } = new();

        /// <summary>
        /// Specify the Workflow to be returned using a workflow query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery Workflow { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<RequestQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<RequestQuery>>();

        /// <summary>
        /// A custom filter to apply to the a request query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            RequestQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("AffectedSlas"))
            {
                retval.SelectAffectedSlas(AffectedSlas);
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoard"))
            {
                retval.SelectAgileBoard(AgileBoard);
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardColumn"))
            {
                retval.SelectAgileBoardColumn(AgileBoardColumn);
            }
            if (MyInvocation.BoundParameters.ContainsKey("AutomationRules"))
            {
                retval.SelectAutomationRules(AutomationRules);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItems"))
            {
                retval.SelectConfigurationItems(ConfigurationItems);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CreatedBy"))
            {
                retval.SelectCreatedBy(CreatedBy);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                retval.SelectCustomFields(CustomFields);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                retval.SelectCustomFieldsAttachments(CustomFieldsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Feedback"))
            {
                retval.SelectFeedback(Feedback);
            }
            if (MyInvocation.BoundParameters.ContainsKey("FeedbackOnKnowledgeArticle"))
            {
                retval.SelectFeedbackOnKnowledgeArticle(FeedbackOnKnowledgeArticle);
            }
            if (MyInvocation.BoundParameters.ContainsKey("GroupedInto"))
            {
                retval.SelectGroupedInto(GroupedInto);
            }
            if (MyInvocation.BoundParameters.ContainsKey("GroupedRequests"))
            {
                retval.SelectGroupedRequests(GroupedRequests);
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeArticles"))
            {
                retval.SelectKnowledgeArticles(KnowledgeArticles);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Member"))
            {
                retval.SelectMember(Member);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Notes"))
            {
                retval.SelectNotes(Notes);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Organization"))
            {
                retval.SelectOrganization(Organization);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Problem"))
            {
                retval.SelectProblem(Problem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductBacklog"))
            {
                retval.SelectProductBacklog(ProductBacklog);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Project"))
            {
                retval.SelectProject(Project);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestedBy"))
            {
                retval.SelectRequestedBy(RequestedBy);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestedFor"))
            {
                retval.SelectRequestedFor(RequestedFor);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstance"))
            {
                retval.SelectServiceInstance(ServiceInstance);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SprintBacklogItems"))
            {
                retval.SelectSprintBacklogItems(SprintBacklogItems);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Supplier"))
            {
                retval.SelectSupplier(Supplier);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Tags"))
            {
                retval.SelectTags(Tags);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Task"))
            {
                retval.SelectTask(Task);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Team"))
            {
                retval.SelectTeam(Team);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Template"))
            {
                retval.SelectTemplate(Template);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeEntries"))
            {
                retval.SelectTimeEntries(TimeEntries);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Watches"))
            {
                retval.SelectWatches(Watches);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Workflow"))
            {
                retval.SelectWorkflow(Workflow);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<RequestQuery> filter in Filters)
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
