using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Trash query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TrashQuery")]
    [OutputType(typeof(Trash))]
    public class NewTrashQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the trash query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a trash properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashField[] Properties { get; set; } = Array.Empty<TrashField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TrashOrderField OrderBy { get; set; }

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
        /// Specify the Trashed Person details to be returned using a person query. This applies if the item is a person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery TrashedPerson { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Problem details to be returned using a problem query. This applies if the item is a problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery TrashedProblem { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Project details to be returned using a project query. This applies if the item is a project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery TrashedProject { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Project task details to be returned using a project task query. This applies if the item is a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery TrashedProjectTask { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Release details to be returned using a release query. This applies if the item is a release.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery TrashedRelease { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Request details to be returned using a request query. This applies if the item is a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery TrashedRequest { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Risk details to be returned using a risk query. This applies if the item is a risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery TrashedRisk { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Task details to be returned using a task query. This applies if the item is a task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskQuery TrashedTask { get; set; } = new();

        /// <summary>
        /// Specify the Trashed Workflow details to be returned using a workflow query. This applies if the item is a workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery TrashedWorkflow { get; set; } = new();

        /// <summary>
        /// Specify the Trashed by to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery TrashedBy { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a trash query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TrashQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<TrashQuery>>();

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
            TrashQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("TrashedPerson"))
            {
                retval.SelectTrashed(TrashedPerson);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedProblem"))
            {
                retval.SelectTrashed(TrashedProblem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedProject"))
            {
                retval.SelectTrashed(TrashedProject);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedProjectTask"))
            {
                retval.SelectTrashed(TrashedProjectTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedRelease"))
            {
                retval.SelectTrashed(TrashedRelease);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedRequest"))
            {
                retval.SelectTrashed(TrashedRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedRisk"))
            {
                retval.SelectTrashed(TrashedRisk);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedTask"))
            {
                retval.SelectTrashed(TrashedTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedWorkflow"))
            {
                retval.SelectTrashed(TrashedWorkflow);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TrashedBy"))
            {
                retval.SelectTrashedBy(TrashedBy);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<TrashQuery> filter in Filters)
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
