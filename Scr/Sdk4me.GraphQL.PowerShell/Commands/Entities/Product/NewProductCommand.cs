using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new product.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Product")]
    [OutputType(typeof(Product))]
    public class NewProductCommand : PSCmdlet
    {
        /// <summary>
        /// The brand name is typically the name of the product&apos;s manufacturer.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// The appropriate product category for the product.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The name of the product. Fill out the Brand, Model, Product ID (optional) and Category fields to automatically generate a name based on the values entered in these fields.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Used to specify whether or not configuration items that are based on the product are typically depreciated and if so, which depreciation method is normally applied. Valid values are:• not_depreciated: Not Depreciated• double_declining_balance: Double Declining Balance• reducing_balance: Reducing Balance (or Diminishing Value)• straight_line: Straight Line (or Prime Cost)• sum_of_the_years_digits: Sum of the Year&apos;s Digits
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProductDepreciationMethod? DepreciationMethod { get; set; }

        /// <summary>
        /// Whether the product may no longer be used to register new configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Identifier of the internal organization which budget is normally used to obtain the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FinancialOwnerId { get; set; }

        /// <summary>
        /// The model of the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Model { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// The unique identifier of the product that is used by the manufacturer. The concatenation of brand and productID must be unique within a Xurrent account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProductID { get; set; }

        /// <summary>
        /// The yearly rate that should normally be applied to calculate the depreciation of configuration items that are based on the product using the reducing balance (or diminishing value) method.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Rate { get; set; }

        /// <summary>
        /// Recurrence for maintenance of configuration items created from the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RecurrenceInput? Recurrence { get; set; }

        /// <summary>
        /// Any additional information about the product that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The value of this configuration item at the end of its useful life (i.e. at the end of its depreciation period). When a value is not specified for this field, it is set to zero.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? SalvageValue { get; set; }

        /// <summary>
        /// The currency of the salvage value attributed to this configuration item.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SalvageValueCurrency { get; set; }

        /// <summary>
        /// Identifier of the Service which Service Instances would typically include the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the organization from which the product is typically obtained. If the product is developed internally, select the internal organization that develops it. Note that a lease company should be selected in this field if the product is normally leased.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team responsible for maintaining the product&apos;s information in the configuration management database (CMDB).
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportTeamId { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The number of years within which configuration items that are based on the product are typically depreciated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? UsefulLife { get; set; }

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// The workflow template that is used to periodically maintain configuration items created from the product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// An array of product properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProductField[] Properties { get; set; } = Array.Empty<ProductField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ProductCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Brand"))
            {
                input.Brand = Brand;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Category"))
            {
                input.Category = Category;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("DepreciationMethod"))
            {
                input.DepreciationMethod = DepreciationMethod;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FinancialOwnerId"))
            {
                input.FinancialOwnerId = FinancialOwnerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Model"))
            {
                input.Model = Model;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProductID"))
            {
                input.ProductID = ProductID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Rate"))
            {
                input.Rate = Rate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Recurrence"))
            {
                input.Recurrence = Recurrence;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Remarks"))
            {
                input.Remarks = Remarks;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                input.RemarksAttachments = RemarksAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("SalvageValue"))
            {
                input.SalvageValue = SalvageValue;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SalvageValueCurrency"))
            {
                input.SalvageValueCurrency = SalvageValueCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupplierId"))
            {
                input.SupplierId = SupplierId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportTeamId"))
            {
                input.SupportTeamId = SupportTeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UsefulLife"))
            {
                input.UsefulLife = UsefulLife;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowManagerId"))
            {
                input.WorkflowManagerId = WorkflowManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowTemplateId"))
            {
                input.WorkflowTemplateId = WorkflowTemplateId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ProductCreatePayload result = client.Sdk4meClient.Mutation(input, new ProductQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewProductError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Product);
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
