﻿using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new webhook policy.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "WebhookPolicy")]
    [OutputType(typeof(WebhookPolicyCreateResponse))]
    public class NewWebhookPolicyCommand : PSCmdlet
    {
        /// <summary>
        /// The algorithm to use for cryptographic signing of webhook messages.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookPolicyJwtAlg JwtAlg { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the webhook policy will be applied.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// The audience claim identifies the recipients that the encrypted message is intended for.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? JwtAudience { get; set; }

        /// <summary>
        /// The number of minutes within which the claim expires.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? JwtClaimExpiresIn { get; set; }

        /// <summary>
        /// An array of webhook policy properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WebhookPolicyCreateResponseField[] Properties { get; set; } = Array.Empty<WebhookPolicyCreateResponseField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            WebhookPolicyCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("JwtAlg"))
            {
                input.JwtAlg = JwtAlg;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Disabled"))
            {
                input.Disabled = Disabled;
            }
            if (MyInvocation.BoundParameters.ContainsKey("JwtAudience"))
            {
                input.JwtAudience = JwtAudience;
            }
            if (MyInvocation.BoundParameters.ContainsKey("JwtClaimExpiresIn"))
            {
                input.JwtClaimExpiresIn = JwtClaimExpiresIn;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            WebhookPolicyCreatePayload result = client.Sdk4meClient.Mutation(input, new WebhookPolicyCreateResponseQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewWebhookPolicyError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.WebhookPolicy);
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