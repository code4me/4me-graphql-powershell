using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a person.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "Person")]
    [OutputType(typeof(Person))]
    public class SetPersonCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Identifiers of accounts this person&apos;s permissions will be deleted for. Permissions for other accounts will not be altered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] AccountPermissionsToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of addresses to remove from this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] AddressesToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Uniquely identify the user for Single Sign-On
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AuthenticationID { get; set; }

        /// <summary>
        /// Whether the person should be offered translations for texts that are written in languages other than the ones selected in the Language (language) and the Do not translate (do_not_translate_languages) arguments. Such texts are translated automatically into the language selected in the Language (language) argument.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AutoTranslation { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Configuration items this person is related to as a user.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ConfigurationItemIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of contacts to remove from this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ContactsToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The person&apos;s estimated total cost per work hour for the service provider organization. The value in this argument should include the costs of the person&apos;s salary (or rate in case of a long-term contractor), office space, service subscriptions, training, etc.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public Decimal? CostPerHour { get; set; }

        /// <summary>
        /// The currency of the cost per hour value attributed to this person.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CostPerHourCurrency { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// true when the person may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The languages that should not be translated automatically for the person. Translations will not be offered to the person for texts in any of these languages. Supported language codes are: en, nl, de, fr, es, pt, it, da, fi, sv, pl, cs, tr, ru, ar, id, fa, no, zh, ja, ko, he, hi, ms.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] DoNotTranslateLanguages { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The unique identifier for a person typically based on order of hire or association with an organization.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EmployeeID { get; set; }

        /// <summary>
        /// Whether team notifications should be excluded from all notifications.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool ExcludeTeamNotifications { get; set; } = false;

        /// <summary>
        /// Any additional information about the person that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Information { get; set; }

        /// <summary>
        /// The person&apos;s job title.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? JobTitle { get; set; }

        /// <summary>
        /// The language preference of the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Language { get; set; }

        /// <summary>
        /// The name or number of the room, cubicle or area where the person has his/her primary work space.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Location { get; set; }

        /// <summary>
        /// The manager or supervisor to whom the person reports.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// The name of the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Permissions for specific accounts of this person to add or update. Permissions for other accounts will not be altered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public PermissionInput[] NewAccountPermissions { get; set; } = Array.Empty<PermissionInput>();

        /// <summary>
        /// New or updated addresses of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AddressInput[] NewAddresses { get; set; } = Array.Empty<AddressInput>();

        /// <summary>
        /// New or updated contacts of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ContactInput[] NewContacts { get; set; } = Array.Empty<ContactInput>();

        /// <summary>
        /// An enabled OAuth person is mentionable and visible in suggest fields, just like a real person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool OauthPersonEnablement { get; set; } = false;

        /// <summary>
        /// The organization for which the person works as an employee or long-term contractor.
        /// </summary>
        [Parameter(Mandatory = false, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Permissions of this person. These will overwrite all existing permissions of this person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public PermissionInput[] Permissions { get; set; } = Array.Empty<PermissionInput>();

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 28, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// The email address to which email notifications are to be sent. This email address acts as the unique identifier for the person within the 4me account. This primary email address also acts as the person&apos;s login name if he/she is a user of the 4me service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 29, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PrimaryEmail { get; set; }

        /// <summary>
        /// Indicates when to send email notifications to the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 30, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public PersonSendEmailNotifications? SendEmailNotifications { get; set; }

        /// <summary>
        /// Indicates when to show a notification popup to the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 31, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public PersonShowNotificationPopup? ShowNotificationPopup { get; set; }

        /// <summary>
        /// Where the person is stationed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 32, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SiteId { get; set; }

        /// <summary>
        /// Skill pools this person belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 33, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SkillPoolIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 34, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 35, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// A number or code that a service desk analyst can ask the person for when the person contacts the service desk for support.
        /// </summary>
        [Parameter(Mandatory = false, Position = 36, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportID { get; set; }

        /// <summary>
        /// Teams this person belongs to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 37, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] TeamIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether the person prefers to see times displayed within the 4me service in the 24-hour format or not (in which case the 12-hour format is applied).
        /// </summary>
        [Parameter(Mandatory = false, Position = 38, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool TimeFormat24h { get; set; } = false;

        /// <summary>
        /// The time zone in which the person normally resides.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 39, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 40, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Whether the person is a very important person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 41, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Vip { get; set; } = false;

        /// <summary>
        /// Calendar that represents the work hours of the person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 42, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// An array of Person properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 43, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonField[] Properties { get; set; } = Array.Empty<PersonField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 44, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            PersonUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AccountPermissionsToDelete"))
            {
                input.AccountPermissionsToDelete = AccountPermissionsToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("AddressesToDelete"))
            {
                input.AddressesToDelete = AddressesToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("AuthenticationID"))
            {
                input.AuthenticationID = AuthenticationID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AutoTranslation"))
            {
                input.AutoTranslation = AutoTranslation;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemIds"))
            {
                input.ConfigurationItemIds = ConfigurationItemIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ContactsToDelete"))
            {
                input.ContactsToDelete = ContactsToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("CostPerHour"))
            {
                input.CostPerHour = CostPerHour;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CostPerHourCurrency"))
            {
                input.CostPerHourCurrency = CostPerHourCurrency;
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
            if (MyInvocation.BoundParameters.ContainsKey("DoNotTranslateLanguages"))
            {
                input.DoNotTranslateLanguages = DoNotTranslateLanguages.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("EmployeeID"))
            {
                input.EmployeeID = EmployeeID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ExcludeTeamNotifications"))
            {
                input.ExcludeTeamNotifications = ExcludeTeamNotifications;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Information"))
            {
                input.Information = Information;
            }
            if (MyInvocation.BoundParameters.ContainsKey("JobTitle"))
            {
                input.JobTitle = JobTitle;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Language"))
            {
                input.Language = Language;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Location"))
            {
                input.Location = Location;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewAccountPermissions"))
            {
                input.NewAccountPermissions = NewAccountPermissions.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewAddresses"))
            {
                input.NewAddresses = NewAddresses.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewContacts"))
            {
                input.NewContacts = NewContacts.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("OauthPersonEnablement"))
            {
                input.OauthPersonEnablement = OauthPersonEnablement;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationId"))
            {
                input.OrganizationId = OrganizationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Permissions"))
            {
                input.Permissions = Permissions.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PrimaryEmail"))
            {
                input.PrimaryEmail = PrimaryEmail;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SendEmailNotifications"))
            {
                input.SendEmailNotifications = SendEmailNotifications;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ShowNotificationPopup"))
            {
                input.ShowNotificationPopup = ShowNotificationPopup;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SiteId"))
            {
                input.SiteId = SiteId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPoolIds"))
            {
                input.SkillPoolIds = SkillPoolIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportID"))
            {
                input.SupportID = SupportID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamIds"))
            {
                input.TeamIds = TeamIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeFormat24h"))
            {
                input.TimeFormat24h = TimeFormat24h;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Vip"))
            {
                input.Vip = Vip;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursId"))
            {
                input.WorkHoursId = WorkHoursId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            PersonUpdatePayload result = client.Sdk4meClient.Mutation(input, new PersonQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetPersonError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Person);
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
