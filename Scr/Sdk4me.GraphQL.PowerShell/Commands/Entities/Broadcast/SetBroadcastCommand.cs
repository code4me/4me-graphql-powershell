using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a broadcast.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "Broadcast")]
    [OutputType(typeof(Broadcast))]
    public class SetBroadcastCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// The body for the email broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Body { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The customer organizations when the broadcast is to be displayed for the specialists of the account in requests that were received from the selected organizations. This is available only when the &quot;Specialists in requests from the following customers&quot; visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] CustomerIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Whether the message should not be broadcasted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The id of the email template used for the email broadcast. This email template needs to be of the type Send Email from Broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? EmailTemplateId { get; set; }

        /// <summary>
        /// The end date and time of the broadcast. This field is left empty when the message is to be broadcasted until the Disabled box is checked. (If the broadcast should end at midnight at the end of a day, specify 12:00am or 24:00.)
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Message that is to be broadcasted in the language of the account.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Message { get; set; }

        /// <summary>
        /// The appropriate icon for the message. The selected icon is displayed alongside the message when the broadcast is presented.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public BroadcastMessageType? MessageType { get; set; }

        /// <summary>
        /// The ids of the organizations, to which people belong, that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OrganizationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Any additional information about the broadcast that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// Files and inline images linked to the Remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The request group to which end users can subscribe when they are also affected by the issue for which the broadcast was created.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestId { get; set; }

        /// <summary>
        /// The service instances for which the people, who are covered for them by an active SLA, need to see the broadcast. This is available only when the &quot;People covered for the following service instance(s)&quot; visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceInstanceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The ids of the sites to which people belong and that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SiteIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The ids of the skill pools to which people belong and that need to see the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SkillPoolIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The ids of the service level agreements for which the customer representatives will receive the email broadcast. This is only available for broadcasts when the message type &quot;email&quot; is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SlaIds { get; set; } = Array.Empty<string>();

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
        /// The start date and time of the broadcast. (If the broadcast should start at midnight at the start of a day, specify 00:00.)
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// The subject for the email broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Subject { get; set; }

        /// <summary>
        /// The teams which members need to see the broadcast. This is available only when the &quot;Members of the following team(s)&quot; visibility option is selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] TeamIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The time zone that applies to the dates and times specified in the Start and End fields.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// Identifiers of translations to remove from this broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] TranslationsToDelete { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Defines the target audience of the broadcast.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public BroadcastVisibility? Visibility { get; set; }

        /// <summary>
        /// An array of Broadcast properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public BroadcastField[] Properties { get; set; } = Array.Empty<BroadcastField>();

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
            BroadcastUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Body"))
            {
                input.Body = Body;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerIds"))
            {
                input.CustomerIds = CustomerIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EmailTemplateId"))
            {
                input.EmailTemplateId = EmailTemplateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndAt"))
            {
                input.EndAt = EndAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Message"))
            {
                input.Message = Message;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MessageType"))
            {
                input.MessageType = MessageType;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationIds"))
            {
                input.OrganizationIds = OrganizationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Remarks"))
            {
                input.Remarks = Remarks;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                input.RemarksAttachments = RemarksAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestId"))
            {
                input.RequestId = RequestId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceIds"))
            {
                input.ServiceInstanceIds = ServiceInstanceIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("SiteIds"))
            {
                input.SiteIds = SiteIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkillPoolIds"))
            {
                input.SkillPoolIds = SkillPoolIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaIds"))
            {
                input.SlaIds = SlaIds.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TeamIds"))
            {
                input.TeamIds = TeamIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TranslationsToDelete"))
            {
                input.TranslationsToDelete = TranslationsToDelete.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Visibility"))
            {
                input.Visibility = Visibility;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            BroadcastUpdatePayload result = client.Sdk4meClient.Mutation(input, new BroadcastQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetBroadcastError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Broadcast);
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
