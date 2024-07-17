using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a shop article.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "ShopArticle")]
    [OutputType(typeof(ShopArticle))]
    public class SetShopArticleCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Calendar that represents the work hours related to the fulfillment/delivery.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CalendarId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The number of minutes it usually takes to deliver the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? DeliveryDuration { get; set; }

        /// <summary>
        /// Whether the shop article is visible in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// After this moment the shop article is no longer available in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// The request template used to order one of more units of this shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FulfillmentTemplateId { get; set; }

        /// <summary>
        /// The full description of the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FullDescription { get; set; }

        /// <summary>
        /// The largest number of units that may be bought at once.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? MaxQuantity { get; set; }

        /// <summary>
        /// The display name of the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// The price of a single unit.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? Price { get; set; }

        /// <summary>
        /// The currency of the price of this shop article.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PriceCurrency { get; set; }

        /// <summary>
        /// Related product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProductId { get; set; }

        /// <summary>
        /// The frequency in which the recurring price is due.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ShopArticleRecurringPeriod? RecurringPeriod { get; set; }

        /// <summary>
        /// The recurring price of a single unit.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RecurringPrice { get; set; }

        /// <summary>
        /// The currency of the recurring price of this shop article.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RecurringPriceCurrency { get; set; }

        /// <summary>
        /// This reference can be used to link the shop article to a shop order line using the 4me APIs or the 4me Import functionality.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Reference { get; set; }

        /// <summary>
        /// Whether or not this is a physical article that requires shipping.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool RequiresShipping { get; set; } = false;

        /// <summary>
        /// The shop description of the shop article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ShortDescription { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The moment the shop article becomes available in the shop.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The Time zone related to the calendar.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// An array of Shop article properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopArticleField[] Properties { get; set; } = Array.Empty<ShopArticleField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Sdk4mePowerShellClient? Client { get; set; }

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Executes query against the 4me GraphQL API.
        /// </summary>
        protected override void ProcessRecord()
        {
            ShopArticleUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CalendarId"))
            {
                input.CalendarId = CalendarId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DeliveryDuration"))
            {
                input.DeliveryDuration = DeliveryDuration;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndAt"))
            {
                input.EndAt = EndAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FulfillmentTemplateId"))
            {
                input.FulfillmentTemplateId = FulfillmentTemplateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FullDescription"))
            {
                input.FullDescription = FullDescription;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MaxQuantity"))
            {
                input.MaxQuantity = MaxQuantity;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Price"))
            {
                input.Price = Price;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PriceCurrency"))
            {
                input.PriceCurrency = PriceCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductId"))
            {
                input.ProductId = ProductId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecurringPeriod"))
            {
                input.RecurringPeriod = RecurringPeriod;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecurringPrice"))
            {
                input.RecurringPrice = RecurringPrice;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecurringPriceCurrency"))
            {
                input.RecurringPriceCurrency = RecurringPriceCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reference"))
            {
                input.Reference = Reference;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequiresShipping"))
            {
                input.RequiresShipping = RequiresShipping;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ShortDescription"))
            {
                input.ShortDescription = ShortDescription;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("StartAt"))
            {
                input.StartAt = StartAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ShopArticleUpdatePayload result = client.Sdk4meClient.Mutation(input, new ShopArticleQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetShopArticleError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ShopArticle);
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
