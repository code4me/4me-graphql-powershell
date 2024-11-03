using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new knowledge article.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "KnowledgeArticle")]
    [OutputType(typeof(KnowledgeArticle))]
    public class NewKnowledgeArticleCommand : PSCmdlet
    {
        /// <summary>
        /// Used to enter instructions for the service desk analysts, specialists and/or end users who are likely to look up the knowledge article to help them with their work or to resolve an issue.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Instructions { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the service for which the knowledge article is made available.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// A short description of the knowledge article.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// The date until which the knowledge article will be active. The knowledge article will be archived at the beginning of this day. When the knowledge article is archived, its status will automatically be set to &quot;Archived&quot;.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
#if NET6_0_OR_GREATER
        public DateOnly? ArchiveDate { get; set; }
#else
        public DateTime? ArchiveDate { get; set; }
#endif

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the knowledge article needs to be available to the people who are a member of the support team of one of the service instances that are selected in the Coverage section of an active SLA for the service that is linked to the article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool CoveredSpecialists { get; set; } = false;

        /// <summary>
        /// Identifier of the person who created the knowledge article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CreatedById { get; set; }

        /// <summary>
        /// Values for custom fields to be used by the UI Extension that is linked to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public CustomFieldCollection? CustomFields { get; set; }

        /// <summary>
        /// The attachments used in the custom fields&apos; values.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] CustomFieldsAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Describes the situation and/or environment in which the instructions of the knowledge article may be helpful.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] DescriptionAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Whether the knowledge article needs to be available to anyone who is covered by an active SLA for the service that is linked to the article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool EndUsers { get; set; } = false;

        /// <summary>
        /// Whether the knowledge article needs to be available to the people who have the Specialist role of the account in which the article is registered.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool InternalSpecialists { get; set; } = false;

        /// <summary>
        /// Whether the knowledge article needs to be available to the people who have the Key Contact role of the customer account of an active SLA for the service that is linked to the article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool KeyContacts { get; set; } = false;

        /// <summary>
        /// A comma-separated list of words that can be used to find the knowledge article using search.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Keywords { get; set; }

        /// <summary>
        /// Whether the knowledge article needs to be available to anyone, including people without access to Xurrent.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Public { get; set; } = false;

        /// <summary>
        /// Identifiers of service instances linked to this knowledge article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] ServiceInstanceIds { get; set; } = Array.Empty<string>();

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
        /// The current status of the knowledge article.
        /// </summary>
        [Parameter(Mandatory = false, Position = 19, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public KnowledgeArticleStatus? Status { get; set; }

        /// <summary>
        /// Identifier of the knowledge article template that this knowledge article is based on.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TemplateId { get; set; }

        /// <summary>
        /// An array of knowledge article properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public KnowledgeArticleField[] Properties { get; set; } = Array.Empty<KnowledgeArticleField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            KnowledgeArticleCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Instructions"))
            {
                input.Instructions = Instructions;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Subject"))
            {
                input.Subject = Subject;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ArchiveDate"))
            {
                input.ArchiveDate = ArchiveDate;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CoveredSpecialists"))
            {
                input.CoveredSpecialists = CoveredSpecialists;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CreatedById"))
            {
                input.CreatedById = CreatedById;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFields"))
            {
                input.CustomFields = CustomFields;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CustomFieldsAttachments"))
            {
                input.CustomFieldsAttachments = CustomFieldsAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DescriptionAttachments"))
            {
                input.DescriptionAttachments = DescriptionAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("EndUsers"))
            {
                input.EndUsers = EndUsers;
            }
            if (MyInvocation.BoundParameters.ContainsKey("InternalSpecialists"))
            {
                input.InternalSpecialists = InternalSpecialists;
            }
            if (MyInvocation.BoundParameters.ContainsKey("KeyContacts"))
            {
                input.KeyContacts = KeyContacts;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Keywords"))
            {
                input.Keywords = Keywords;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Public"))
            {
                input.Public = Public;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceIds"))
            {
                input.ServiceInstanceIds = ServiceInstanceIds.ToList();
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
            if (MyInvocation.BoundParameters.ContainsKey("TemplateId"))
            {
                input.TemplateId = TemplateId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            KnowledgeArticleCreatePayload result = client.Sdk4meClient.Mutation(input, new KnowledgeArticleQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewKnowledgeArticleError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.KnowledgeArticle);
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
