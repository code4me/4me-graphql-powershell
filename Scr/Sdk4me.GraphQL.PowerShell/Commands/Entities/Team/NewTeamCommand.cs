using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new team.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Team")]
    [OutputType(typeof(Team))]
    public class NewTeamCommand : PSCmdlet
    {
        /// <summary>
        /// The name of the team.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Used to automatically link records to the agile board when they are assigned to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgileBoardId { get; set; }

        /// <summary>
        /// Whether requests are auto-assigned to a team member.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool AutoAssign { get; set; } = false;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The person who maintains the information about the configuration items that the team supports.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ConfigurationManagerId { get; set; }

        /// <summary>
        /// The current team coordinator for the team. Only members of the team can be selected in this field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CoordinatorId { get; set; }

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
        /// Whether the team may no longer be related to other records.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Used to specify an email address for the team. When an email is sent to this email address, a new request gets generated and assigned to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? InboundEmailLocalPart { get; set; }

        /// <summary>
        /// The manager or supervisor of the team. This person is able to maintain the information about the team. The manager of a team does not need to be a member of the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// People that are linked as member to the team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] MemberIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// Any additional information about the team that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The time zone that applies to the selected work hours.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// The calendar that defines the work hours during which the team is available for work on all types of assignments.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WorkHoursId { get; set; }

        /// <summary>
        /// An array of team properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TeamField[] Properties { get; set; } = Array.Empty<TeamField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            TeamCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardId"))
            {
                input.AgileBoardId = AgileBoardId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AutoAssign"))
            {
                input.AutoAssign = AutoAssign;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationManagerId"))
            {
                input.ConfigurationManagerId = ConfigurationManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CoordinatorId"))
            {
                input.CoordinatorId = CoordinatorId;
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
            if (MyInvocation.BoundParameters.ContainsKey("InboundEmailLocalPart"))
            {
                input.InboundEmailLocalPart = InboundEmailLocalPart;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MemberIds"))
            {
                input.MemberIds = MemberIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
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
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkHoursId"))
            {
                input.WorkHoursId = WorkHoursId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TeamCreatePayload result = client.Sdk4meClient.Mutation(input, new TeamQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTeamError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Team);
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
