using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Archive query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ArchiveQuery")]
    [OutputType(typeof(Archive))]
    public class NewArchiveQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the archive query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of an archive properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveField[] Properties { get; set; } = Array.Empty<ArchiveField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ArchiveOrderField OrderBy { get; set; }

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
        /// Specify the Archived Person details to be returned using a person query. This applies if the item is a person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery ArchivedPerson { get; set; } = new();

        /// <summary>
        /// Specify the Archived Problem details to be returned using a problem query. This applies if the item is a problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery ArchivedProblem { get; set; } = new();

        /// <summary>
        /// Specify the Archived Project details to be returned using a project query. This applies if the item is a project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery ArchivedProject { get; set; } = new();

        /// <summary>
        /// Specify the Archived Project task details to be returned using a project task query. This applies if the item is a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery ArchivedProjectTask { get; set; } = new();

        /// <summary>
        /// Specify the Archived Release details to be returned using a release query. This applies if the item is a release.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery ArchivedRelease { get; set; } = new();

        /// <summary>
        /// Specify the Archived Request details to be returned using a request query. This applies if the item is a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery ArchivedRequest { get; set; } = new();

        /// <summary>
        /// Specify the Archived Risk details to be returned using a risk query. This applies if the item is a risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery ArchivedRisk { get; set; } = new();

        /// <summary>
        /// Specify the Archived Task details to be returned using a task query. This applies if the item is a task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskQuery ArchivedTask { get; set; } = new();

        /// <summary>
        /// Specify the Archived Workflow details to be returned using a workflow query. This applies if the item is a workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery ArchivedWorkflow { get; set; } = new();

        /// <summary>
        /// Specify the Archived by to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery ArchivedBy { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the an archive query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<ArchiveQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<ArchiveQuery>>();

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
            ArchiveQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedPerson"))
            {
                retval.SelectArchived(ArchivedPerson);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedProblem"))
            {
                retval.SelectArchived(ArchivedProblem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedProject"))
            {
                retval.SelectArchived(ArchivedProject);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedProjectTask"))
            {
                retval.SelectArchived(ArchivedProjectTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedRelease"))
            {
                retval.SelectArchived(ArchivedRelease);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedRequest"))
            {
                retval.SelectArchived(ArchivedRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedRisk"))
            {
                retval.SelectArchived(ArchivedRisk);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedTask"))
            {
                retval.SelectArchived(ArchivedTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedWorkflow"))
            {
                retval.SelectArchived(ArchivedWorkflow);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchivedBy"))
            {
                retval.SelectArchivedBy(ArchivedBy);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<ArchiveQuery> filter in Filters)
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
