using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new service level agreement.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "ServiceLevelAgreement")]
    [OutputType(typeof(ServiceLevelAgreement))]
    public class NewServiceLevelAgreementCommand : PSCmdlet
    {
        /// <summary>
        /// Identifier of the organization that pays for the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// The name of the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service offering that specifies the conditions that apply to the service level agreement.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceOfferingId { get; set; } = string.Empty;

        /// <summary>
        /// The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider. This contains the activityIDs related to request categories.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ActivityIDInput? ActivityID { get; set; }

        /// <summary>
        /// The Agreement ID is the unique identifier by which all the activities that are performed through the coverage of the SLA are known in the billing system of the service provider.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? AgreementID { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Used to specify how people who are to be covered by the service level agreement are to be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public SlaCoverage? Coverage { get; set; }

        /// <summary>
        /// Identifier of the account which service level managers are allowed to update the parts of the SLA that are intended to be maintained by the service level managers of the customer. More importantly, this field is used to specify whether specialists of the customer are allowed to see the requests that include this SLA in their Affected SLAs section.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CustomerAccountId { get; set; }

        /// <summary>
        /// Identifiers of the people who represents the customer organization for the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] CustomerRepresentativeIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The date through which the service level agreement (SLA) will be active. The SLA expires at the end of this day if it is not renewed before then. When the SLA has expired, its status will automatically be set to &quot;Expired&quot;.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? ExpiryDate { get; set; }
#else
        public DateTime? ExpiryDate { get; set; }
#endif

        /// <summary>
        /// The Rate IDs are the unique identifiers by which an effort class that is linked to a time entry when an activity was performed through the coverage of the SLA is known in the billing system of the service provider.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public EffortClassRateIDInput[] NewEffortClassRateIDs { get; set; } = Array.Empty<EffortClassRateIDInput>();

        /// <summary>
        /// Represents the activityIDs for standard service requests. The Activity ID is the unique identifier by which an activity that is performed in the context of a service offering is known in the billing system of the service provider
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public StandardServiceRequestActivityIDInput[] NewStandardServiceRequestActivityIDs { get; set; } = Array.Empty<StandardServiceRequestActivityIDInput>();

        /// <summary>
        /// The last day on which the service provider organization can still be contacted to terminate the service level agreement (SLA) to ensure that it expires on the intended expiry date. The Notice date field is left empty, and the Expiry date field is filled out, when the SLA is to expire on a specific date and no notice needs to be given to terminate it.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? NoticeDate { get; set; }
#else
        public DateTime? NoticeDate { get; set; }
#endif

        /// <summary>
        /// Identifiers of the organizations of the service level agreement. Only available for service level agreements where the coverage field is set to organizations_and_descendants, organizations or organizations_and_sites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OrganizationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of the people of the service level agreement. Only available for service level agreements where the coverage field is set to people.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] PersonIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Any additional information about the service level agreement that might prove useful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Remarks { get; set; }

        /// <summary>
        /// The attachments used in the remarks field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] RemarksAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Identifier of the service instance that will be used to provide the service to the customer of the service level agreement. Only service instances that are linked to the same service as the selected service offering can be selected.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceInstanceId { get; set; }

        /// <summary>
        /// Identifier of the person of the service provider organization who acts as the service level manager for the customer of the service level agreement.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ServiceLevelManagerId { get; set; }

        /// <summary>
        /// Identifiers of the sites of the service level agreement. Only available for service level agreements where the coverage field is set to sites or organizations_and_sites.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SiteIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of the skill pools of the service level agreement. Only available for service level agreements where the coverage field is set to skill_pools.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SkillPoolIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The first day during which the service level agreement (SLA) is active.
        /// </summary>
        [Parameter(Mandatory = false, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? StartDate { get; set; }
#else
        public DateTime? StartDate { get; set; }
#endif

        /// <summary>
        /// The current status of the service level agreement (SLA).
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AgreementStatus? Status { get; set; }

        /// <summary>
        /// Whether knowledge articles from the service provider should be exposed to the people covered by the service instances related to the service level agreement. Only available for service level agreements where the coverage field is set to service_instances.
        /// </summary>
        [Parameter(Mandatory = false, Position = 25, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool UseKnowledgeFromServiceProvider { get; set; } = false;

        /// <summary>
        /// An array of service level agreement properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 26, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceLevelAgreementField[] Properties { get; set; } = Array.Empty<ServiceLevelAgreementField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
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
            ServiceLevelAgreementCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("CustomerId"))
            {
                input.CustomerId = CustomerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceOfferingId"))
            {
                input.ServiceOfferingId = ServiceOfferingId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ActivityID"))
            {
                input.ActivityID = ActivityID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgreementID"))
            {
                input.AgreementID = AgreementID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Coverage"))
            {
                input.Coverage = Coverage;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerAccountId"))
            {
                input.CustomerAccountId = CustomerAccountId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomerRepresentativeIds"))
            {
                input.CustomerRepresentativeIds = CustomerRepresentativeIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ExpiryDate"))
            {
                input.ExpiryDate = ExpiryDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewEffortClassRateIDs"))
            {
                input.NewEffortClassRateIDs = NewEffortClassRateIDs.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewStandardServiceRequestActivityIDs"))
            {
                input.NewStandardServiceRequestActivityIDs = NewStandardServiceRequestActivityIDs.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("NoticeDate"))
            {
                input.NoticeDate = NoticeDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationIds"))
            {
                input.OrganizationIds = OrganizationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PersonIds"))
            {
                input.PersonIds = PersonIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Remarks"))
            {
                input.Remarks = Remarks;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RemarksAttachments"))
            {
                input.RemarksAttachments = RemarksAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceId"))
            {
                input.ServiceInstanceId = ServiceInstanceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceLevelManagerId"))
            {
                input.ServiceLevelManagerId = ServiceLevelManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SiteIds"))
            {
                input.SiteIds = SiteIds.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("StartDate"))
            {
                input.StartDate = StartDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UseKnowledgeFromServiceProvider"))
            {
                input.UseKnowledgeFromServiceProvider = UseKnowledgeFromServiceProvider;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ServiceLevelAgreementCreatePayload result = client.Sdk4meClient.Mutation(input, new ServiceLevelAgreementQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewServiceLevelAgreementError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ServiceLevelAgreement);
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
