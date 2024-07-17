using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new risk.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Risk")]
    [OutputType(typeof(Risk))]
    public class NewRiskCommand : PSCmdlet
    {
        /// <summary>
        /// The severity of the risk.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Severity { get; set; } = string.Empty;

        /// <summary>
        /// The subject of the risk.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The appropriate closure reason for the risk when it has been closed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RiskClosureReason? ClosureReason { get; set; }

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
        /// Identifier of the manager of the risk. This person is able to maintain the information about the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ManagerId { get; set; }

        /// <summary>
        /// The date by which the risk should have been mitigated.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? MitigationTargetAt { get; set; }
#else
        public DateTime? MitigationTargetAt { get; set; }
#endif

        /// <summary>
        /// The Note field is used to provide a detailed description of the risk and the actions that are planned or have already been taken to eliminate it, or to minimize its severity. This field is also used when the status is set to closed to explain why it was decided to close the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Note { get; set; }

        /// <summary>
        /// Identifiers of organizations linked to the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OrganizationIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of projects linked to the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ProjectIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Identifiers of services linked to the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// The current status of the risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public RiskStatus? Status { get; set; }

        /// <summary>
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// An array of risk properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskField[] Properties { get; set; } = Array.Empty<RiskField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            RiskCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Severity"))
            {
                input.Severity = Severity;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClosureReason"))
            {
                input.ClosureReason = ClosureReason;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ManagerId"))
            {
                input.ManagerId = ManagerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MitigationTargetAt"))
            {
                input.MitigationTargetAt = MitigationTargetAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                input.Note = Note;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OrganizationIds"))
            {
                input.OrganizationIds = OrganizationIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ProjectIds"))
            {
                input.ProjectIds = ProjectIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceIds"))
            {
                input.ServiceIds = ServiceIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Status"))
            {
                input.Status = Status;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            RiskCreatePayload result = client.Sdk4meClient.Mutation(input, new RiskQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewRiskError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Risk);
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
