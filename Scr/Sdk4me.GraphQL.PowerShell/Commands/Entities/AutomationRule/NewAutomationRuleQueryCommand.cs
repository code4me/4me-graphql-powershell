using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Automation rule query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AutomationRuleQuery")]
    [OutputType(typeof(AutomationRule))]
    public class NewAutomationRuleQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the automation rule query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of an automation rule properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleField[] Properties { get; set; } = Array.Empty<AutomationRuleField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleOrderField OrderBy { get; set; }

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
        /// Specify the Actions to be returned using an automation rule action query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleActionQuery Actions { get; set; } = new();

        /// <summary>
        /// Specify the Expressions to be returned using an automation rule expression query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleExpressionQuery Expressions { get; set; } = new();

        /// <summary>
        /// Specify the Owner Project task details to be returned using a project task query. This applies if the item is a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery OwnerProjectTask { get; set; } = new();

        /// <summary>
        /// Specify the Owner Project task template details to be returned using a project task template query. This applies if the item is a project task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateQuery OwnerProjectTaskTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Owner Project task template relation details to be returned using a project task template relation query. This applies if the item is a project task template relation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskTemplateRelationQuery OwnerProjectTaskTemplateRelation { get; set; } = new();

        /// <summary>
        /// Specify the Owner Request details to be returned using a request query. This applies if the item is a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery OwnerRequest { get; set; } = new();

        /// <summary>
        /// Specify the Owner Request template details to be returned using a request template query. This applies if the item is a request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery OwnerRequestTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Owner Task details to be returned using a task query. This applies if the item is a task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskQuery OwnerTask { get; set; } = new();

        /// <summary>
        /// Specify the Owner Task template details to be returned using a task template query. This applies if the item is a task template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskTemplateQuery OwnerTaskTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Owner Workflow details to be returned using a workflow query. This applies if the item is a workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery OwnerWorkflow { get; set; } = new();

        /// <summary>
        /// Specify the Owner Workflow task template relation details to be returned using a workflow task template relation query. This applies if the item is a workflow task template relation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateRelationQuery OwnerWorkflowTaskTemplateRelation { get; set; } = new();

        /// <summary>
        /// Specify the Owner Workflow template details to be returned using a workflow template query. This applies if the item is a workflow template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery OwnerWorkflowTemplate { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the an automation rule query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<AutomationRuleQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<AutomationRuleQuery>>();

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
            AutomationRuleQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("Actions"))
            {
                retval.SelectActions(Actions);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Expressions"))
            {
                retval.SelectExpressions(Expressions);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerProjectTask"))
            {
                retval.SelectOwner(OwnerProjectTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerProjectTaskTemplate"))
            {
                retval.SelectOwner(OwnerProjectTaskTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerProjectTaskTemplateRelation"))
            {
                retval.SelectOwner(OwnerProjectTaskTemplateRelation);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerRequest"))
            {
                retval.SelectOwner(OwnerRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerRequestTemplate"))
            {
                retval.SelectOwner(OwnerRequestTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerTask"))
            {
                retval.SelectOwner(OwnerTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerTaskTemplate"))
            {
                retval.SelectOwner(OwnerTaskTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerWorkflow"))
            {
                retval.SelectOwner(OwnerWorkflow);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerWorkflowTaskTemplateRelation"))
            {
                retval.SelectOwner(OwnerWorkflowTaskTemplateRelation);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerWorkflowTemplate"))
            {
                retval.SelectOwner(OwnerWorkflowTemplate);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<AutomationRuleQuery> filter in Filters)
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
