using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new app offering.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AppOffering")]
    [OutputType(typeof(AppOffering))]
    public class NewAppOfferingCommand : PSCmdlet
    {
        /// <summary>
        /// Name of the app offering.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the the service instance this app offering is linked to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceInstanceId { get; set; } = string.Empty;

        /// <summary>
        /// Short description of the app offering to be shown on the card in the App store.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CardDescription { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Compliance description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Compliance { get; set; }

        /// <summary>
        /// The URI where the app can be configured. The placeholder {account} can be used to include the customer account id in the URI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ConfigurationUriTemplate { get; set; }

        /// <summary>
        /// Description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The attachments used in the description field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] DescriptionAttachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// Whether the app offering may not be used for new instances.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Feature description of the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Features { get; set; }

        /// <summary>
        /// Scopes of this app offering
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AppOfferingScopeInput[] NewScopes { get; set; } = Array.Empty<AppOfferingScopeInput>();

        /// <summary>
        /// The endpoints for the OAuth application that will be created for this app to use in the Authorization Code Grant flow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] OauthAuthorizationEndpoints { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The hyperlink to the image file for the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PictureUri { get; set; }

        /// <summary>
        /// The algorithm used for generating the policy for the app offering&apos;s webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public WebhookPolicyJwtAlg? PolicyJwtAlg { get; set; }

        /// <summary>
        /// The audience for the policy for the app offering&apos;s webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PolicyJwtAudience { get; set; }

        /// <summary>
        /// The claim expiry time for the policy for the app offering&apos;s webhook.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? PolicyJwtClaimExpiresIn { get; set; }

        /// <summary>
        /// This reference can be used to link the app offering to an instance using the Xurrent APIs or the Xurrent Import functionality.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Reference { get; set; }

        /// <summary>
        /// This app requires an enabled OAuth person.
        /// </summary>
        [Parameter(Mandatory = false, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool RequiresEnabledOauthPerson { get; set; } = false;

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
        /// UI extension that is to be applied to the record.
        /// </summary>
        [Parameter(Mandatory = false, Position = 20, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionId { get; set; }

        /// <summary>
        /// Identifier of the UI extension version that is linked to the app offering.
        /// </summary>
        [Parameter(Mandatory = false, Position = 21, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? UiExtensionVersionId { get; set; }

        /// <summary>
        /// The URI for the app offering&apos;s webhook. The placeholder {account} can be used to include the customer account id in the URI.
        /// </summary>
        [Parameter(Mandatory = false, Position = 22, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WebhookUriTemplate { get; set; }

        /// <summary>
        /// An array of app offering properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 23, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingField[] Properties { get; set; } = Array.Empty<AppOfferingField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 24, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            AppOfferingCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceInstanceId"))
            {
                input.ServiceInstanceId = ServiceInstanceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CardDescription"))
            {
                input.CardDescription = CardDescription;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Compliance"))
            {
                input.Compliance = Compliance;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ConfigurationUriTemplate"))
            {
                input.ConfigurationUriTemplate = ConfigurationUriTemplate;
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
            if (MyInvocation.BoundParameters.ContainsKey("Features"))
            {
                input.Features = Features;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewScopes"))
            {
                input.NewScopes = NewScopes.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("OauthAuthorizationEndpoints"))
            {
                input.OauthAuthorizationEndpoints = OauthAuthorizationEndpoints.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PictureUri"))
            {
                input.PictureUri = PictureUri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PolicyJwtAlg"))
            {
                input.PolicyJwtAlg = PolicyJwtAlg;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PolicyJwtAudience"))
            {
                input.PolicyJwtAudience = PolicyJwtAudience;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PolicyJwtClaimExpiresIn"))
            {
                input.PolicyJwtClaimExpiresIn = PolicyJwtClaimExpiresIn;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reference"))
            {
                input.Reference = Reference;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequiresEnabledOauthPerson"))
            {
                input.RequiresEnabledOauthPerson = RequiresEnabledOauthPerson;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionId"))
            {
                input.UiExtensionId = UiExtensionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("UiExtensionVersionId"))
            {
                input.UiExtensionVersionId = UiExtensionVersionId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WebhookUriTemplate"))
            {
                input.WebhookUriTemplate = WebhookUriTemplate;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            AppOfferingCreatePayload result = client.Sdk4meClient.Mutation(input, new AppOfferingQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewAppOfferingError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.AppOffering);
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
