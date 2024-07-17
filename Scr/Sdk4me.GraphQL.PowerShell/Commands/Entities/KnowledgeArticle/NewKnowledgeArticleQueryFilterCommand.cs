using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new knowledge article query filter.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "KnowledgeArticleQueryFilter")]
    [OutputType(typeof(QueryFilter<KnowledgeArticleQuery>))]
    public class NewKnowledgeArticleQueryFilterCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the field property to filter on.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleFilter Property { get; set; }

        /// <summary>
        /// Gets or sets the operator to use in the filter.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the text values to filter the property by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string?[]? TextValues { get; set; }

        /// <summary>
        /// Gets or sets the DateTime values to filter the property by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime?[]? DateTimeValues { get; set; }

        /// <summary>
        /// Gets or sets the Boolean value to filter the property by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool? BooleanValue { get; set; }

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
            QueryFilter<KnowledgeArticleQuery> filter = new(Property.GetEnumMemberValue(), Operator)
            {
                StringValues = TextValues,
                DateTimeValues = DateTimeValues,
                BooleanValue = BooleanValue
            };

            if (filter.IsValid(out string? errorMessage))
            {
                WriteObject(filter);
            }
            else
            {
                new Sdk4meFilterException(errorMessage).ThrowAsTerminatingError(this, "NewKnowledgeArticleQueryFilterError", ErrorCategory.InvalidArgument, this);
            }
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
