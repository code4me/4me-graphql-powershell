using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Create a new event in 4me.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Event")]
    [OutputType(typeof(Request))]
    public class NewEventCommand : PSCmdlet
    {

        /// <summary>
        /// Used to specify an option in the Category field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestCategory Category { get; set; }

        /// <summary>
        /// <br>Used to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration item needs to be identified by its <c>label</c> or, in case of a software configuration item, its <c>name</c> field value.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ConfigurationItemName { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration item will be identified by its <c>ID</c>.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ConfigurationItemID { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration item will be identified by its <c>source</c> and <c>sourceID</c>.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "ConfigurationItemBySource")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationItemSource { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration item will be identified by its <c>source</c> and <c>sourceID</c>.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "ConfigurationItemBySource")]
        [ValidateNotNullOrEmpty]
        public string ConfigurationItemSourceID { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the configuration item that is to be related to the request.</br>
        /// <br>The configuration will be identified by its <c>ID</c>, or by its <c>source</c> and <c>sourceID</c> when the <c>ID</c> is <c>null</c> or empty.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public ConfigurationItem ConfigurationItem { get; set; } = new();

        /// <summary>
        /// Used to specify an option in the completion reason field of the request when its status field is set to <c>completed</c>.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestCompletionReason CompletionReason { get; set; }

        /// <summary>
        /// <br>Used to specify the date and time that has been agreed on for the completion of the request.</br>
        /// <br>The desired completion overwrites the automatically calculated resolution target of any affected SLA that is related to the request when the desired completion is later than the affected SLA's resolution target.</br>
        /// <br>By default, the <c>requested_by</c> receives a notification based on the ‘Desired Completion Set for Request’ email template whenever the <c>desired_completion_at</c> is set, updated or removed.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime DesiredCompletionAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Used to specify the end date and time of a service outage.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime DownTimeEndAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Used to specify the start date and time of a service outage.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime DownTimeStartAt { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Used to specify an option in the impact field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestImpact Impact { get; set; }

        /// <summary>
        /// Used to provide the text that needs to be added as an internal note to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string InternalNote { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the person to which the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string MemberPrimaryEmail { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the person to which the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long MemberID { get; set; }

        /// <summary>
        /// <br>Used to specify the person to which the request is to be assigned.</br>
        /// <br>The person will be identified by its <c>ID</c>, or by its <c>primary email</c> when the <c>ID</c> is <c>null</c> or empty.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person Member { get; set; } = new();

        /// <summary>
        /// Used to provide the text that needs to be added as a note to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the problem that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long ProblemID { get; set; }

        /// <summary>
        /// <br>Used to specify the problem that is to be related to the request.</br>
        /// <br>The problem will be identified by its <c>ID</c>.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Problem Problem { get; set; } = new();

        /// <summary>
        /// Used to specify the person who is to be selected in the requested by field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RequestedByPrimaryEmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the person who is to be selected in the requested by field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long RequestedByID { get; set; }

        /// <summary>
        /// <br>Used to specify the person who is to be selected in the requested by field of the request.</br>
        /// <br>The person will be identified by its <c>ID</c>, or by its <c>primary email</c> when the <c>ID</c> is <c>null</c> or empty.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person RequestedBy { get; set; } = new();

        /// <summary>
        /// Used to specify the person who is to be selected in the Requested for field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string RequestedForPrimaryEmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the person who is to be selected in the Requested for field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long RequestedForID { get; set; }

        /// <summary>
        /// <br>Used to specify the person who is to be selected in the Requested for field of the request.</br>
        /// <br>The person will be identified by its <c>ID</c>, or by its <c>primary email</c> when the <c>ID</c> is <c>null</c> or empty.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Person RequestedFor { get; set; } = new();

        /// <summary>
        /// Used to specify the service instance that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceInstanceName { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the service instance that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long ServiceInstanceID { get; set; }

        /// <summary>
        /// Used to specify the service instance that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceInstance ServiceInstance { get; set; } = new();

        /// <summary>
        /// <br>Used to specify the name of the monitoring tool, see <see href="https://developer.4me.com/v1/general/source/">source</see>.</br>
        /// <br>After the request has been created, this value is visible in its audit trail.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the unique ID of the event for which the request is to be registered, see <see href="https://developer.4me.com/v1/general/source/">source</see>.</br>
        /// <br>After the request has been created, this value is visible in its audit trail.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SourceID { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify an option in the status field of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Used to specify the subject of the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the organization to which the request has been submitted.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SupplierName { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the organization to which the request has been submitted.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long SupplierID { get; set; }

        /// <summary>
        /// Used to specify the organization to which the request has been submitted.
        /// <br>The organization will be identified by its <c>ID</c>, or by its <c>name</c> when the <c>ID</c> is <c>null</c> or empty.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Organization Supplier { get; set; } = new();

        /// <summary>
        /// <br>Used to specify the support domain account ID in which the request is to be registered.</br>
        /// <br>This parameter needs to be specified when the current user's person record is registered in a directory account.</br>
        /// <br>The ID of a 4me account can be found in the 'Account Overview' section of the Settings console.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SupportDomainAccountID { get; set; } = string.Empty;

        /// <summary>
        /// <br>Used to specify the support domain account in which the request is to be registered.</br>
        /// <br>This parameter needs to be specified when the current user's person record is registered in a directory account.</br>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Account SupportDomain { get; set; } = new();

        /// <summary>
        /// Used to specify the team to which the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// Used to specify the team to which the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long TeamID { get; set; }

        /// <summary>
        /// Used to specify the team to which the request is to be assigned.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Team Team { get; set; } = new();

        /// <summary>
        /// Used to specify the request template that is to be applied to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long RequestTemplateID { get; set; }

        /// <summary>
        /// Used to specify the request template that is to be applied to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplate RequestTemplate { get; set; } = new();

        /// <summary>
        /// Used to specify the date and time at which the status of the request is to be updated from <c>waiting_for</c> to <c>assigned</c>.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public DateTime WaitingUntil { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Used to specify the workflow that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public long WorkflowID { get; set; }

        /// <summary>
        /// Used to specify the workflow that is to be related to the request.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Workflow Workflow { get; set; } = new();

        /// <summary>
        /// The client is used to upload the file. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
        /// Create a new event in 4me.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                RequestEventCreateInput input = new();
                if (MyInvocation.BoundParameters.ContainsKey("Category"))
                {
                    input.Category(Category);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemName"))
                {
                    input.ConfigurationItem(ConfigurationItemName);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemID"))
                {
                    input.ConfigurationItem(ConfigurationItemID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItemSource") && MyInvocation.BoundParameters.ContainsKey("ConfigurationItemSourceID"))
                {
                    input.ConfigurationItem(ConfigurationItemSource, ConfigurationItemSourceID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ConfigurationItem"))
                {
                    input.ConfigurationItem(ConfigurationItem);
                }
                if (MyInvocation.BoundParameters.ContainsKey("CompletionReason"))
                {
                    input.CompletionReason(CompletionReason);
                }
                if (MyInvocation.BoundParameters.ContainsKey("DesiredCompletionAt"))
                {
                    input.DesiredCompletionAt(DesiredCompletionAt);
                }
                if (MyInvocation.BoundParameters.ContainsKey("DownTimeEndAt"))
                {
                    input.DownTimeEndAt(DownTimeEndAt);
                }
                if (MyInvocation.BoundParameters.ContainsKey("DownTimeStartAt"))
                {
                    input.DownTimeStartAt(DownTimeStartAt);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Impact"))
                {
                    input.Impact(Impact);
                }
                if (MyInvocation.BoundParameters.ContainsKey("InternalNote"))
                {
                    input.InternalNote(InternalNote);
                }
                if (MyInvocation.BoundParameters.ContainsKey("MemberPrimaryEmail"))
                {
                    input.Member(MemberPrimaryEmail);
                }
                if (MyInvocation.BoundParameters.ContainsKey("MemberID"))
                {
                    input.Member(MemberID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Member"))
                {
                    input.Member(Member);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Note"))
                {
                    input.Note(Note);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ProblemID"))
                {
                    input.Problem(ProblemID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Problem"))
                {
                    input.Problem(Problem);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedByPrimaryEmailAddress"))
                {
                    input.RequestedBy(RequestedByPrimaryEmailAddress);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedByID"))
                {
                    input.RequestedBy(RequestedByID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedBy"))
                {
                    input.RequestedBy(RequestedBy);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedForPrimaryEmailAddress"))
                {
                    input.RequestedFor(RequestedForPrimaryEmailAddress);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedForID"))
                {
                    input.RequestedFor(RequestedForID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestedFor"))
                {
                    input.RequestedFor(RequestedFor);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceName"))
                {
                    input.ServiceInstance(ServiceInstanceName);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceID"))
                {
                    input.ServiceInstance(ServiceInstanceID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("ServiceInstance"))
                {
                    input.ServiceInstance(ServiceInstance);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Source"))
                {
                    input.Source(Source);
                }
                if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
                {
                    input.SourceID(SourceID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Status"))
                {
                    input.Status(Status);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Subject"))
                {
                    input.Subject(Subject);
                }
                if (MyInvocation.BoundParameters.ContainsKey("SupplierName"))
                {
                    input.Supplier(SupplierName);
                }
                if (MyInvocation.BoundParameters.ContainsKey("SupplierID"))
                {
                    input.Supplier(SupplierID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Supplier"))
                {
                    input.Supplier(Supplier);
                }
                if (MyInvocation.BoundParameters.ContainsKey("SupportDomainAccountID"))
                {
                    input.SupportDomain(SupportDomainAccountID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("SupportDomain"))
                {
                    input.SupportDomain(SupportDomain);
                }
                if (MyInvocation.BoundParameters.ContainsKey("TeamName"))
                {
                    input.Team(TeamName);
                }
                if (MyInvocation.BoundParameters.ContainsKey("TeamID"))
                {
                    input.Team(TeamID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Team"))
                {
                    input.Team(Team);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestTemplateID"))
                {
                    input.RequestTemplate(RequestTemplateID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("RequestTemplate"))
                {
                    input.RequestTemplate(RequestTemplate);
                }
                if (MyInvocation.BoundParameters.ContainsKey("WaitingUntil"))
                {
                    input.WaitingUntil(WaitingUntil);
                }
                if (MyInvocation.BoundParameters.ContainsKey("WorkflowID"))
                {
                    input.Workflow(WorkflowID);
                }
                if (MyInvocation.BoundParameters.ContainsKey("Workflow"))
                {
                    input.Workflow(Workflow);
                }

                PowerShellTraceListener.RegisterCmdlet(this);
                Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
                Request result = client.Sdk4meClient.CreateEvent(input).GetAwaiter().GetResult();
                PowerShellTraceListener.UnregisterCmdlet();
                WriteObject(result);
            }
            catch (Sdk4meException ex)
            {
                ex.ThrowAsTerminatingError(this, "NewEventError", ErrorCategory.InvalidOperation, this);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "NewEventError", ErrorCategory.NotSpecified, this);
            }
        }

        /// <summary>
        /// Completes the processing of the command.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
