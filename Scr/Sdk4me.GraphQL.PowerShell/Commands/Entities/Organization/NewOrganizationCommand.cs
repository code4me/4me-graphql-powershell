using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new organization.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Organization")]
    [OutputType(typeof(Organization))]
    public class NewOrganizationCommand : PSCmdlet
    {
        /// <summary>
        /// The full name of the organization.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Whether the organization needs to be treated as a separate entity from a reporting perspective. This checkbox is only available for internal organizations.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool BusinessUnit { get; set; } = false;

        /// <summary>
        /// Refers to itself if the organization is a business unit, or refers to the business unit that the organization belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? BusinessUnitOrganizationId { get; set; }

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
        /// Whether the organization may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Whether end users from this organization should be prevented from seeing information of other end users.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool EndUserPrivacy { get; set; } = false;

        /// <summary>
        /// The unique identifier by which the organization is known in the financial system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? FinancialID { get; set; }

        /// <summary>
        /// The manager of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// New or updated addresses of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AddressInput[] NewAddresses { get; set; } = Array.Empty<AddressInput>();

        /// <summary>
        /// New or updated contacts of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ContactInput[] NewContacts { get; set; } = Array.Empty<ContactInput>();

        /// <summary>
        /// The organization&apos;s parent organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ParentId { get; set; }

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// Which region the organization belongs to. It is possible to select a previously entered region name or to enter a new one. The Region field of a business unit&apos;s child organizations cannot be modified, as it is automatically set to the same value as the Region field of the business unit.Examples of commonly used region names are:- Asia Pacific (APAC)- Europe, Middle East &amp; Africa (EMEA)- North America (NA)
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Region { get; set; }

        /// <summary>
        /// Any additional information about the organization that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The person who acts as the substitute of the organization&apos;s manager.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SubstituteId { get; set; }

        /// <summary>
        /// Time allocations of the organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] TimeAllocationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// An array of organization properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationField[] Properties { get; set; } = Array.Empty<OrganizationField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            OrganizationCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("BusinessUnit"))
            {
                input.BusinessUnit = BusinessUnit;
            }
            if (MyInvocation.BoundParameters.ContainsKey("BusinessUnitOrganizationId"))
            {
                input.BusinessUnitOrganizationId = BusinessUnitOrganizationId;
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
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndUserPrivacy"))
            {
                input.EndUserPrivacy = EndUserPrivacy;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FinancialID"))
            {
                input.FinancialID = FinancialID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewAddresses"))
            {
                input.NewAddresses = NewAddresses.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewContacts"))
            {
                input.NewContacts = NewContacts.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ParentId"))
            {
                input.ParentId = ParentId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Region"))
            {
                input.Region = Region;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Remarks"))
            {
                input.Remarks = Remarks;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                input.RemarksAttachments = RemarksAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SubstituteId"))
            {
                input.SubstituteId = SubstituteId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeAllocationIds"))
            {
                input.TimeAllocationIds = TimeAllocationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            OrganizationCreatePayload result = client.Sdk4meClient.Mutation(input, new OrganizationQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewOrganizationError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Organization);
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
