using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new webhook.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Webhook")]
    [OutputType(typeof(Webhook))]
    public class NewWebhookCommand : PSCmdlet
    {
        /// <summary>
        /// Event that will trigger this webhook.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookEvent Event { get; set; }

        /// <summary>
        /// Publicly accessible URI that Xurrent can use to POST http messages to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Uri { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Description of the webhook&apos;s purpose.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] DescriptionAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Whether the webhook will be triggered when the event occurs.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Comma separated list of email addresses who will be informed when the webhook execution fails.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MailExceptionsTo { get; set; }

        /// <summary>
        /// Name of this webhook. Defaults to the event name.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Name { get; set; }

        /// <summary>
        /// The webhook policy to use for cryptographic signing of the messages.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WebhookPolicyId { get; set; }

        /// <summary>
        /// An array of webhook properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookField[] Properties { get; set; } = Array.Empty<WebhookField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            WebhookCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Event"))
            {
                input.Event = Event;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Uri"))
            {
                input.Uri = Uri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DescriptionAttachments"))
            {
                input.DescriptionAttachments = DescriptionAttachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MailExceptionsTo"))
            {
                input.MailExceptionsTo = MailExceptionsTo;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WebhookPolicyId"))
            {
                input.WebhookPolicyId = WebhookPolicyId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            WebhookCreatePayload result = client.Sdk4meClient.Mutation(input, new WebhookQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewWebhookError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Webhook);
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
