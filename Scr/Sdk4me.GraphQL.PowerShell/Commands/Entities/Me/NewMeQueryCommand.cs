using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Me query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "MeQuery")]
    [OutputType(typeof(Person))]
    public class NewMeQueryCommand : PSCmdlet
    {
        /// <summary>
        /// An array of a me properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonField[] Properties { get; set; } = Array.Empty<PersonField>();

        /// <summary>
        /// Specify the Account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery Account { get; set; } = new();

        /// <summary>
        /// Specify the Addresses to be returned using an address query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AddressQuery Addresses { get; set; } = new();

        /// <summary>
        /// Specify the Cart to be returned using a shop order line query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShopOrderLineQuery Cart { get; set; } = new();

        /// <summary>
        /// Specify the Configuration items to be returned using a configuration item query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ConfigurationItemQuery ConfigurationItems { get; set; } = new();

        /// <summary>
        /// Specify the Contacts to be returned using a contact query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ContactQuery Contacts { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields to be returned using a custom field query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CustomFieldQuery CustomFields { get; set; } = new();

        /// <summary>
        /// Specify the Custom fields attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery CustomFieldsAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Information attachments to be returned using an attachment query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AttachmentQuery InformationAttachments { get; set; } = new();

        /// <summary>
        /// Specify the Manager to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Manager { get; set; } = new();

        /// <summary>
        /// Specify the Organization to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organization { get; set; } = new();

        /// <summary>
        /// Specify the Out of office periods to be returned using an out of office period query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OutOfOfficePeriodQuery OutOfOfficePeriods { get; set; } = new();

        /// <summary>
        /// Specify the Permissions to be returned using a permission query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PermissionQuery Permissions { get; set; } = new();

        /// <summary>
        /// Specify the Site to be returned using a site query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SiteQuery Site { get; set; } = new();

        /// <summary>
        /// Specify the Skill pools to be returned using a skill pool query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SkillPoolQuery SkillPools { get; set; } = new();

        /// <summary>
        /// Specify the Teams to be returned using a team query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamQuery Teams { get; set; } = new();

        /// <summary>
        /// Specify the UI extension to be returned using an user interface extension query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public UiExtensionQuery UiExtension { get; set; } = new();

        /// <summary>
        /// Specify the Work hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery WorkHours { get; set; } = new();

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
            MeQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("Account"))
            {
                retval.SelectAccount(Account);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Addresses"))
            {
                retval.SelectAddresses(Addresses);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Cart"))
            {
                retval.SelectCart(Cart);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItems"))
            {
                retval.SelectConfigurationItems(ConfigurationItems);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Contacts"))
            {
                retval.SelectContacts(Contacts);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                retval.SelectCustomFields(CustomFields);
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                retval.SelectCustomFieldsAttachments(CustomFieldsAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("InformationAttachments"))
            {
                retval.SelectInformationAttachments(InformationAttachments);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Manager"))
            {
                retval.SelectManager(Manager);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Organization"))
            {
                retval.SelectOrganization(Organization);
            }
            if (MyInvocation.BoundParameters.ContainsKey("OutOfOfficePeriods"))
            {
                retval.SelectOutOfOfficePeriods(OutOfOfficePeriods);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Permissions"))
            {
                retval.SelectPermissions(Permissions);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Site"))
            {
                retval.SelectSite(Site);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPools"))
            {
                retval.SelectSkillPools(SkillPools);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Teams"))
            {
                retval.SelectTeams(Teams);
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtension"))
            {
                retval.SelectUiExtension(UiExtension);
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHours"))
            {
                retval.SelectWorkHours(WorkHours);
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
