using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new configuration item.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ConfigurationItem")]
    [OutputType(typeof(ConfigurationItem))]
    public class NewConfigurationItemCommand : PSCmdlet
    {
        /// <summary>
        /// Identifier of the related product.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ProductId { get; set; } = string.Empty;

        /// <summary>
        /// The appropriate status for the configuration item (CI).
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CiStatus Status { get; set; }

        /// <summary>
        /// Alternate names the configuration item is also known by.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] AlternateNames { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Asset identifier of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AssetID { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifiers of the contracts of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ContractIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The date at which the support for this configuration item ends.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? EndOfSupportDate { get; set; }
#else
        public DateTime? EndOfSupportDate { get; set; }
#endif

        /// <summary>
        /// Identifier of the internal organization which budget is used to pay for the configuration item. If the CI is leased or rented, the organization that pays the lease or rent is selected in this field. When creating a new CI and a value is not specified for this field, it is set to the financial owner of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FinancialOwnerId { get; set; }

        /// <summary>
        /// The date on which the expense for the configuration item (CI) was incurred or, if the CI is depreciated over time, the date on which the depreciation was started. This is typically the invoice date.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? InUseSince { get; set; }
#else
        public DateTime? InUseSince { get; set; }
#endif

        /// <summary>
        /// The label that is attached to the configuration item (CI). A label is automatically generated using the same prefix of other CIs of the same product category, followed by the next available number as the suffix.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Label { get; set; }

        /// <summary>
        /// The date and time at which the configuration item was last seen.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? LastSeenAt { get; set; }

        /// <summary>
        /// Identifiers of the sites at which the software that is covered by the license certificate may be used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] LicensedSiteIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The date through which the temporary software license certificate is valid. The license certificate expires at the end of this day.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? LicenseExpiryDate { get; set; }
#else
        public DateTime? LicenseExpiryDate { get; set; }
#endif

        /// <summary>
        /// The type of license that the license certificate covers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CiLicenseType? LicenseType { get; set; }

        /// <summary>
        /// The name or number of the room in which the CI is located, if it concerns a hardware CI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Location { get; set; }

        /// <summary>
        /// The name of the configuration item (CI). When creating a new CI and a value is not specified for this field, it is set to the name of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Relations to other configuration items.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CiRelationInput[] NewCiRelations { get; set; } = Array.Empty<CiRelationInput>();

        /// <summary>
        /// The total number of processor cores that are installed in the server.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? NrOfCores { get; set; }

        /// <summary>
        /// The number of licenses that the license certificate covers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? NrOfLicenses { get; set; }

        /// <summary>
        /// The number of processors that are installed in the server.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? NrOfProcessors { get; set; }

        /// <summary>
        /// Identifier of the (software) configuration item representing the operating system of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? OperatingSystemId { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// The amount that was paid for the configuration item (this is normally equal to the invoice amount).
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? PurchaseValue { get; set; }

        /// <summary>
        /// The currency of the purchase value attributed to this configuration item.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PurchaseValueCurrency { get; set; }

        /// <summary>
        /// The amount of RAM (in GB) of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? RamAmount { get; set; }

        /// <summary>
        /// Recurrence for maintenance of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RecurrenceInput? Recurrence { get; set; }

        /// <summary>
        /// Any additional information about the configuration item that might prove useful. When creating a new CI and a value is not specified for this field, it is set to the remarks of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The Rule set field is automatically set to the rule set of product category, except when the CI is a license certificate, in which case the rule set is license_certificate.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ProductCategoryRuleSet? RuleSet { get; set; }

        /// <summary>
        /// Serial number of the configuration item. The concatenation of product&apos;s&apos; brand and serialNr must be unique within a 4me account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SerialNr { get; set; }

        /// <summary>
        /// Which service instance(s) the configuration item is, or will be, a part of. When creating a new CI and a value is not specified for this field, it is set to the service of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceId { get; set; }

        /// <summary>
        /// Identifiers of the service instances of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceInstanceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Where the CI is located, if it concerns a hardware CI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SiteId { get; set; }

        /// <summary>
        /// true for license certificates that may only be used at one or more specific locations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool SiteLicense { get; set; } = false;

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// Identifier of the supplier from which the configuration item (CI) has been obtained. When creating a new CI and a value is not specified for this field, it is set to the supplier of the CI&apos;s product.
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupplierId { get; set; }

        /// <summary>
        /// Identifier of the team responsible for supporting the configuration item and maintaining its information in the configuration management database (CMDB). When creating a new CI and a value is not specified for this field, it is set to the support team of the CI&apos;s product. Optional when status of CI equals &quot;Removed&quot;, required otherwise.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportTeamId { get; set; }

        /// <summary>
        /// System identifier of the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SystemID { get; set; }

        /// <summary>
        /// true for license certificates that are not valid indefinitely.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool TemporaryLicense { get; set; } = false;

        /// <summary>
        /// Identifiers of the users of this configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] UserIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The date through which the warranty coverage for the configuration item is valid. The warranty expires at the end of this day.
        /// </summary>
        [Parameter(Mandatory = false, Position = 43, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? WarrantyExpiryDate { get; set; }
#else
        public DateTime? WarrantyExpiryDate { get; set; }
#endif

        /// <summary>
        /// The person who will be responsible for coordinating the workflows that will be generated automatically in accordance with the recurrence schedule.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowManagerId { get; set; }

        /// <summary>
        /// The workflow template that is used to periodically maintain the configuration item.
        /// </summary>
        [Parameter(Mandatory = false, Position = 45, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkflowTemplateId { get; set; }

        /// <summary>
        /// An array of configuration item properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 46, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemField[] Properties { get; set; } = Array.Empty<ConfigurationItemField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 47, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ConfigurationItemCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ProductId"))
            {
                input.ProductId = ProductId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AlternateNames"))
            {
                input.AlternateNames = AlternateNames.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("AssetID"))
            {
                input.AssetID = AssetID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ContractIds"))
            {
                input.ContractIds = ContractIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndOfSupportDate"))
            {
                input.EndOfSupportDate = EndOfSupportDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FinancialOwnerId"))
            {
                input.FinancialOwnerId = FinancialOwnerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InUseSince"))
            {
                input.InUseSince = InUseSince;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Label"))
            {
                input.Label = Label;
            }
            if (MyInvocation.BoundParameters.ContainsKey("LastSeenAt"))
            {
                input.LastSeenAt = LastSeenAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("LicensedSiteIds"))
            {
                input.LicensedSiteIds = LicensedSiteIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("LicenseExpiryDate"))
            {
                input.LicenseExpiryDate = LicenseExpiryDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("LicenseType"))
            {
                input.LicenseType = LicenseType;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Location"))
            {
                input.Location = Location;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewCiRelations"))
            {
                input.NewCiRelations = NewCiRelations.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NrOfCores"))
            {
                input.NrOfCores = NrOfCores;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NrOfLicenses"))
            {
                input.NrOfLicenses = NrOfLicenses;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NrOfProcessors"))
            {
                input.NrOfProcessors = NrOfProcessors;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OperatingSystemId"))
            {
                input.OperatingSystemId = OperatingSystemId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PurchaseValue"))
            {
                input.PurchaseValue = PurchaseValue;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PurchaseValueCurrency"))
            {
                input.PurchaseValueCurrency = PurchaseValueCurrency;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RamAmount"))
            {
                input.RamAmount = RamAmount;
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
            if (MyInvocation.BoundParameters.ContainsKey("RuleSet"))
            {
                input.RuleSet = RuleSet;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SerialNr"))
            {
                input.SerialNr = SerialNr;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceIds"))
            {
                input.ServiceInstanceIds = ServiceInstanceIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("SiteId"))
            {
                input.SiteId = SiteId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SiteLicense"))
            {
                input.SiteLicense = SiteLicense;
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
            if (MyInvocation.BoundParameters.ContainsKey("SystemID"))
            {
                input.SystemID = SystemID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TemporaryLicense"))
            {
                input.TemporaryLicense = TemporaryLicense;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UserIds"))
            {
                input.UserIds = UserIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("WarrantyExpiryDate"))
            {
                input.WarrantyExpiryDate = WarrantyExpiryDate;
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
            ConfigurationItemCreatePayload result = client.Sdk4meClient.Mutation(input, new ConfigurationItemQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewConfigurationItemError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ConfigurationItem);
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
