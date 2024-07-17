using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a first line support agreement.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "FirstLineSupportAgreement")]
    [OutputType(typeof(FirstLineSupportAgreement))]
    public class SetFirstLineSupportAgreementCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// The amounts that the customer will be charged for the first line support agreement. These can be recurring as well as one-off charges.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Charges { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the organization that pays for the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CustomerId { get; set; }

        /// <summary>
        /// Identifier of the customer representative.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CustomerRepresentativeId { get; set; }

        /// <summary>
        /// The date through which the first line support agreement (FLSA) will be active. The FLSA expires at the end of this day if it is not renewed before then. When the FLSA has expired, its status will automatically be set to &quot;Expired&quot;.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? ExpiryDate { get; set; }
#else
        public DateTime? ExpiryDate { get; set; }
#endif

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team during their registration.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? FirstCallResolutions { get; set; }

        /// <summary>
        /// The name of the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The last day on which the first line support provider organization can still be contacted to terminate the first line support agreement (FLSA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the FLSA is to expire on a specific date and no notice needs to be given to terminate it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? NoticeDate { get; set; }
#else
        public DateTime? NoticeDate { get; set; }
#endif

        /// <summary>
        /// The minimum percentage of requests that are to be picked up by the service desk team within the pickup target.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PickupsWithinTarget { get; set; }

        /// <summary>
        /// The number of minutes within which a new or existing request that has been assigned to the service desk team is assigned to a specific member within the service desk team, is assigned to another team, or is set to a status other than assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PickupTarget { get; set; }

        /// <summary>
        /// Identifier of the organization that provides the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ProviderId { get; set; }

        /// <summary>
        /// The maximum percentage of requests that were reopened (i.e. which status in the account that is covered by the first line support agreement was updated from completed to another status).
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? RejectedSolutions { get; set; }

        /// <summary>
        /// Any additional information about the first line support agreement that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team without having been assigned to any other team within the account that is covered by the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ServiceDeskOnlyResolutions { get; set; }

        /// <summary>
        /// The minimum percentage of requests that are to be completed by the service desk team.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? ServiceDeskResolutions { get; set; }

        /// <summary>
        /// Identifier of the specific team within the first line support provider organization that provides first line support for the users covered by the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceDeskTeamId { get; set; }

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The first day during which the first line support agreement (FLSA) is active.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? StartDate { get; set; }
#else
        public DateTime? StartDate { get; set; }
#endif

        /// <summary>
        /// The current status of the first line support agreement (FLSA).
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AgreementStatus? Status { get; set; }

        /// <summary>
        /// The number of minutes within which a new or existing chat request that has been assigned to the service desk team is assigned to a specific member within the service desk team, is assigned to another team, or is set to a status other than assigned.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? SupportChatPickupTarget { get; set; }

        /// <summary>
        /// Identifier of the calendar that defines the support hours during which the service desk team can be contacted for first line support.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SupportHoursId { get; set; }

        /// <summary>
        /// A description of all the targets of the first line support agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TargetDetails { get; set; }

        /// <summary>
        /// The time zone that applies to the start, notice and expiry dates, and to the support hours.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TimeZone { get; set; }

        /// <summary>
        /// An array of First line support agreement properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public FirstLineSupportAgreementField[] Properties { get; set; } = Array.Empty<FirstLineSupportAgreementField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 27, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            FirstLineSupportAgreementUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Charges"))
            {
                input.Charges = Charges;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerId"))
            {
                input.CustomerId = CustomerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerRepresentativeId"))
            {
                input.CustomerRepresentativeId = CustomerRepresentativeId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ExpiryDate"))
            {
                input.ExpiryDate = ExpiryDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("FirstCallResolutions"))
            {
                input.FirstCallResolutions = FirstCallResolutions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoticeDate"))
            {
                input.NoticeDate = NoticeDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PickupsWithinTarget"))
            {
                input.PickupsWithinTarget = PickupsWithinTarget;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PickupTarget"))
            {
                input.PickupTarget = PickupTarget;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProviderId"))
            {
                input.ProviderId = ProviderId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RejectedSolutions"))
            {
                input.RejectedSolutions = RejectedSolutions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Remarks"))
            {
                input.Remarks = Remarks;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                input.RemarksAttachments = RemarksAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceDeskOnlyResolutions"))
            {
                input.ServiceDeskOnlyResolutions = ServiceDeskOnlyResolutions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceDeskResolutions"))
            {
                input.ServiceDeskResolutions = ServiceDeskResolutions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceDeskTeamId"))
            {
                input.ServiceDeskTeamId = ServiceDeskTeamId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("StartDate"))
            {
                input.StartDate = StartDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportChatPickupTarget"))
            {
                input.SupportChatPickupTarget = SupportChatPickupTarget;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHoursId"))
            {
                input.SupportHoursId = SupportHoursId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TargetDetails"))
            {
                input.TargetDetails = TargetDetails;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TimeZone"))
            {
                input.TimeZone = TimeZone;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            FirstLineSupportAgreementUpdatePayload result = client.Sdk4meClient.Mutation(input, new FirstLineSupportAgreementQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetFirstLineSupportAgreementError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.FirstLineSupportAgreement);
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
