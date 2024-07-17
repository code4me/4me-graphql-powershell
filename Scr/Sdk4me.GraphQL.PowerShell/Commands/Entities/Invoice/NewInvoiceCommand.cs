using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new invoice.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Invoice")]
    [OutputType(typeof(Invoice))]
    public class NewInvoiceCommand : PSCmdlet
    {
        /// <summary>
        /// Short description of what was acquired.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The date on which the invoice was sent out by the supplier.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
#if NET6_0_OR_GREATER
        public DateOnly InvoiceDate { get; set; } = DateOnly.MinValue;
#else
        public DateTime InvoiceDate { get; set; } = DateTime.MinValue;
#endif

        /// <summary>
        /// The invoice number that the supplier specified on the invoice.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string InvoiceNr { get; set; } = string.Empty;

        /// <summary>
        /// The number of units that were acquired.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Decimal Quantity { get; set; } = 0;

        /// <summary>
        /// Identifier of the organization from which the invoice was received.
        /// </summary>
        [Parameter(Mandatory = true, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SupplierId { get; set; } = string.Empty;

        /// <summary>
        /// The amount that the supplier has charged per unit that was acquired.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Decimal UnitPrice { get; set; } = 0;

        /// <summary>
        /// The end date of the period over which the invoice is to be amortized.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? AmortizationEnd { get; set; }
#else
        public DateTime? AmortizationEnd { get; set; }
#endif

        /// <summary>
        /// The start date of the period over which the invoice is to be amortized.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? AmortizationStart { get; set; }
#else
        public DateTime? AmortizationStart { get; set; }
#endif

        /// <summary>
        /// Whether the invoice amount is to be amortized over time.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Amortize { get; set; } = false;

        /// <summary>
        /// The configuration items linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] CiIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The contract linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ContractId { get; set; }

        /// <summary>
        /// Currency of the amount value of the invoice.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Currency { get; set; }

        /// <summary>
        /// Used to specify whether or not configuration items that are linked to this invoice are depreciatedand if so, which depreciation method is to be applied. Valid values are:• not_depreciated: Not Depreciated• double_declining_balance: Double Declining Balance• reducing_balance: Reducing Balance (or Diminishing Value)• straight_line: Straight Line (or Prime Cost)• sum_of_the_years_digits: Sum of the Year&apos;s Digits
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProductDepreciationMethod? DepreciationMethod { get; set; }

        /// <summary>
        /// The date on which to start depreciating the asset.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? DepreciationStart { get; set; }
#else
        public DateTime? DepreciationStart { get; set; }
#endif

        /// <summary>
        /// The unique identifier by which the invoice is known in the financial system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FinancialID { get; set; }

        /// <summary>
        /// The first line support agreement linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FlsaId { get; set; }

        /// <summary>
        /// Number of the purchase order that was used to order the (lease of the) configuration item from the supplier.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PoNr { get; set; }

        /// <summary>
        /// The project linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Used to specify the yearly rate that should be applied to calculate the depreciation of the configuration item (CI) using the reducing balance (or diminishing value) method. When creating a new CI and a value is not specified for this field, it is set to the rate of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Rate { get; set; }

        /// <summary>
        /// Any additional information about the invoice that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The value of this configuration item at the end of its useful life (i.e. at the end of its depreciation period). When a value is not specified for this field, it is set to zero.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? SalvageValue { get; set; }

        /// <summary>
        /// The currency of the salvage value attributed to this configuration item.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SalvageValueCurrency { get; set; }

        /// <summary>
        /// The service that covers this invoice. Can only be set when the invoice is linked to a contract or configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// The service level agreement linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SlaId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The number of years within which the configuration item is to be depreciated. When creating a new CI and a value is not specified for this field, it is set to the useful life of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? UsefulLife { get; set; }

        /// <summary>
        /// The workflow linked to this invoice.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowId { get; set; }

        /// <summary>
        /// An array of invoice properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InvoiceField[] Properties { get; set; } = Array.Empty<InvoiceField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            InvoiceCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InvoiceDate"))
            {
                input.InvoiceDate = InvoiceDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InvoiceNr"))
            {
                input.InvoiceNr = InvoiceNr;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Quantity"))
            {
                input.Quantity = Quantity;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupplierId"))
            {
                input.SupplierId = SupplierId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UnitPrice"))
            {
                input.UnitPrice = UnitPrice;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AmortizationEnd"))
            {
                input.AmortizationEnd = AmortizationEnd;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AmortizationStart"))
            {
                input.AmortizationStart = AmortizationStart;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Amortize"))
            {
                input.Amortize = Amortize;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CiIds"))
            {
                input.CiIds = CiIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ContractId"))
            {
                input.ContractId = ContractId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Currency"))
            {
                input.Currency = Currency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DepreciationMethod"))
            {
                input.DepreciationMethod = DepreciationMethod;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DepreciationStart"))
            {
                input.DepreciationStart = DepreciationStart;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FinancialID"))
            {
                input.FinancialID = FinancialID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FlsaId"))
            {
                input.FlsaId = FlsaId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PoNr"))
            {
                input.PoNr = PoNr;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProjectId"))
            {
                input.ProjectId = ProjectId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Rate"))
            {
                input.Rate = Rate;
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
            if (MyInvocation.BoundParameters.ContainsKey("SlaId"))
            {
                input.SlaId = SlaId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UsefulLife"))
            {
                input.UsefulLife = UsefulLife;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowId"))
            {
                input.WorkflowId = WorkflowId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            InvoiceCreatePayload result = client.Sdk4meClient.Mutation(input, new InvoiceQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewInvoiceError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Invoice);
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
