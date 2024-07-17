using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new App offering query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AppOfferingQuery")]
    [OutputType(typeof(AppOffering))]
    public class NewAppOfferingQueryCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies an ID to further filter the app offering query, rendering other filters redundant by directly referencing a specific object.
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
        /// An array of an app offering properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingField[] Properties { get; set; } = Array.Empty<AppOfferingField>();

        /// <summary>
        /// <br>Specifies the view of the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingView View { get; set; }

        /// <summary>
        /// <br>Specifies the field by which to order the query results.</br>
        /// <br>Note: This setting is applicable only to the primary query and will be disregarded for nested queries.</br>
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingOrderField OrderBy { get; set; }

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
        /// Specify the App instances to be returned using an app instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppInstanceQuery AppInstances { get; set; } = new();

        /// <summary>
        /// Specify the Automation rules to be returned using an app offering automation rule query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingAutomationRuleQuery AutomationRules { get; set; } = new();

        /// <summary>
        /// Specify the Compliance attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery ComplianceAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Description attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery DescriptionAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Features attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery FeaturesAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Scopes to be returned using an app offering scope query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingScopeQuery Scopes { get; set; } = new();

        /// <summary>
        /// Specify the Service instance to be returned using a service instance query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstanceQuery ServiceInstance { get; set; } = new();

        /// <summary>
        /// Specify the UI extension version to be returned using an user interface extension version query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionVersionQuery UiExtensionVersion { get; set; } = new();

        /// <summary>
        /// An array of additional filters to apply to the an app offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public QueryFilter<AppOfferingQuery>[] Filters { get; set; } = Array.Empty<QueryFilter<AppOfferingQuery>>();

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
            AppOfferingQuery retval = ID == null || ID == string.Empty ? new() : new(ID);

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
            if (MyInvocation.BoundParameters.ContainsKey("AppInstances"))
            {
                retval.SelectAppInstances(AppInstances);
            }
            if (MyInvocation.BoundParameters.ContainsKey("AutomationRules"))
            {
                retval.SelectAutomationRules(AutomationRules);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ComplianceAttachments"))
            {
                retval.SelectComplianceAttachments(ComplianceAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("DescriptionAttachments"))
            {
                retval.SelectDescriptionAttachments(DescriptionAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("FeaturesAttachments"))
            {
                retval.SelectFeaturesAttachments(FeaturesAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Scopes"))
            {
                retval.SelectScopes(Scopes);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstance"))
            {
                retval.SelectServiceInstance(ServiceInstance);
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionVersion"))
            {
                retval.SelectUiExtensionVersion(UiExtensionVersion);
            }

            if (MyInvocation.BoundParameters.ContainsKey("Filters"))
            {
                foreach (QueryFilter<AppOfferingQuery> filter in Filters)
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
