using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Translation query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TranslationQuery")]
    [OutputType(typeof(Translation))]
    public class NewTranslationQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the translation query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of a translation properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationField[] Properties { get; set; } = Array.Empty<TranslationField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationOrderField OrderBy { get; set; }

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
        /// Specify the Owner Custom collection element details to be returned using a custom collection element query. This applies if the item is a custom collection element.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomCollectionElementQuery OwnerCustomCollectionElement { get; set; } = new();

        /// <summary>
        /// Specify the Owner Email template details to be returned using an email template query. This applies if the item is an email template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EmailTemplateQuery OwnerEmailTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Owner Knowledge article details to be returned using a knowledge article query. This applies if the item is a knowledge article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleQuery OwnerKnowledgeArticle { get; set; } = new();

        /// <summary>
        /// Specify the Owner Pdf design details to be returned using a pdf design query. This applies if the item is a pdf design.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PdfDesignQuery OwnerPdfDesign { get; set; } = new();

        /// <summary>
        /// Specify the Owner Product category details to be returned using a product category query. This applies if the item is a product category.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductCategoryQuery OwnerProductCategory { get; set; } = new();

        /// <summary>
        /// Specify the Owner Request template details to be returned using a request template query. This applies if the item is a request template.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery OwnerRequestTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Owner Risk severity details to be returned using a risk severity query. This applies if the item is a risk severity.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskSeverityQuery OwnerRiskSeverity { get; set; } = new();

        /// <summary>
        /// Specify the Owner Service category details to be returned using a service category query. This applies if the item is a service category.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceCategoryQuery OwnerServiceCategory { get; set; } = new();

        /// <summary>
        /// Specify the Owner Service instance details to be returned using a service instance query. This applies if the item is a service instance.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery OwnerServiceInstance { get; set; } = new();

        /// <summary>
        /// Specify the Owner Service details to be returned using a service query. This applies if the item is a service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceQuery OwnerService { get; set; } = new();

        /// <summary>
        /// Specify the Owner Shop article category details to be returned using a shop article category query. This applies if the item is a shop article category.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleCategoryQuery OwnerShopArticleCategory { get; set; } = new();

        /// <summary>
        /// Specify the Owner Shop article details to be returned using a shop article query. This applies if the item is a shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleQuery OwnerShopArticle { get; set; } = new();

        /// <summary>
        /// Specify the Owner Survey details to be returned using a survey query. This applies if the item is a survey.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuery OwnerSurvey { get; set; } = new();

        /// <summary>
        /// Specify the Owner Survey question details to be returned using a survey question query. This applies if the item is a survey question.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyQuestionQuery OwnerSurveyQuestion { get; set; } = new();

        /// <summary>
        /// Specify the Owner Time allocation details to be returned using a time allocation query. This applies if the item is a time allocation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TimeAllocationQuery OwnerTimeAllocation { get; set; } = new();

        /// <summary>
        /// Specify the Owner UI extension details to be returned using an user interface extension query. This applies if the item is an UI extension.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery OwnerUiExtension { get; set; } = new();

        /// <summary>
        /// Specify the Owner Workflow template phase details to be returned using a workflow template phase query. This applies if the item is a workflow template phase.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseQuery OwnerWorkflowTemplatePhase { get; set; } = new();

        /// <summary>
        /// Specify the Owner Workflow type details to be returned using a workflow type query. This applies if the item is a workflow type.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTypeQuery OwnerWorkflowType { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the a translation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<TranslationQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<TranslationQuery>>();

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
            TranslationQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("OwnerCustomCollectionElement"))
            {
                retval.SelectOwner(OwnerCustomCollectionElement);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerEmailTemplate"))
            {
                retval.SelectOwner(OwnerEmailTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerKnowledgeArticle"))
            {
                retval.SelectOwner(OwnerKnowledgeArticle);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerPdfDesign"))
            {
                retval.SelectOwner(OwnerPdfDesign);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerProductCategory"))
            {
                retval.SelectOwner(OwnerProductCategory);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerRequestTemplate"))
            {
                retval.SelectOwner(OwnerRequestTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerRiskSeverity"))
            {
                retval.SelectOwner(OwnerRiskSeverity);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerServiceCategory"))
            {
                retval.SelectOwner(OwnerServiceCategory);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerServiceInstance"))
            {
                retval.SelectOwner(OwnerServiceInstance);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerService"))
            {
                retval.SelectOwner(OwnerService);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerShopArticleCategory"))
            {
                retval.SelectOwner(OwnerShopArticleCategory);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerShopArticle"))
            {
                retval.SelectOwner(OwnerShopArticle);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerSurvey"))
            {
                retval.SelectOwner(OwnerSurvey);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerSurveyQuestion"))
            {
                retval.SelectOwner(OwnerSurveyQuestion);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerTimeAllocation"))
            {
                retval.SelectOwner(OwnerTimeAllocation);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerUiExtension"))
            {
                retval.SelectOwner(OwnerUiExtension);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerWorkflowTemplatePhase"))
            {
                retval.SelectOwner(OwnerWorkflowTemplatePhase);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerWorkflowType"))
            {
                retval.SelectOwner(OwnerWorkflowType);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<TranslationQuery> filter in Filters)
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
