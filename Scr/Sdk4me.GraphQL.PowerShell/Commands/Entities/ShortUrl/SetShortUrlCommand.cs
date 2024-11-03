using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for updating a short uniform resource locator.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "ShortUrl")]
    [OutputType(typeof(ShortUrl))]
    public class SetShortUrlCommand : PSCmdlet
    {
        /// <summary>
        /// The node ID of the record to update.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the CI for which a request is to be registered in Xurrent Self Service when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? CiId { get; set; }

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Identifier of the dashboard which is to be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? DashboardId { get; set; }

        /// <summary>
        /// Values for email that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ShortUrlEmailInput? Email { get; set; }

        /// <summary>
        /// Coordinates of the location for which a map should be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ShortUrlGeoInput? Geo { get; set; }

        /// <summary>
        /// Identifier of the knowledge article which instructions need to be displayed when the short URL is used in Xurrent Self Service.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? KnowledgeArticleId { get; set; }

        /// <summary>
        /// The address (or only the city or country) for which a map should be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? MapAddress { get; set; }

        /// <summary>
        /// The Plain text field is used to enter the text that should be displayed when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PlainText { get; set; }

        /// <summary>
        /// The identifier of the request template that is to be applied to each new request that is opened when in Xurrent Self Service when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? RequestTemplateId { get; set; }

        /// <summary>
        /// The Skype name that is to be called when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SkypeName { get; set; }

        /// <summary>
        /// Values for the SMS message that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public ShortUrlSmsInput? Sms { get; set; }

        /// <summary>
        /// The telephone number that is to be called when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Tel { get; set; }

        /// <summary>
        /// The Twitter tweet that is to be generated when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Tweet { get; set; }

        /// <summary>
        /// The name of the Twitter user whose Twitter feed is to be opened when the short URL is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 14, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? TwitterName { get; set; }

        /// <summary>
        /// The uniform resource identifier (URI) to which the short URL is forwarded.
        /// </summary>
        [Parameter(Mandatory = false, Position = 15, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Uri { get; set; }

        /// <summary>
        /// The uniform resource locator of a website to which the short URL is to forward when it is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 16, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? WebsiteUrl { get; set; }

        /// <summary>
        /// An array of Short URL properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 17, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ShortUrlField[] Properties { get; set; } = Array.Empty<ShortUrlField>();

        /// <summary>
        /// The client used to execute the update mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 18, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            ShortUrlUpdateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ID"))
            {
                input.ID = ID;
            }
            if (MyInvocation.BoundParameters.ContainsKey("CiId"))
            {
                input.CiId = CiId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("DashboardId"))
            {
                input.DashboardId = DashboardId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Email"))
            {
                input.Email = Email;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Geo"))
            {
                input.Geo = Geo;
            }
            if (MyInvocation.BoundParameters.ContainsKey("KnowledgeArticleId"))
            {
                input.KnowledgeArticleId = KnowledgeArticleId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("MapAddress"))
            {
                input.MapAddress = MapAddress;
            }
            if (MyInvocation.BoundParameters.ContainsKey("PlainText"))
            {
                input.PlainText = PlainText;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RequestTemplateId"))
            {
                input.RequestTemplateId = RequestTemplateId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SkypeName"))
            {
                input.SkypeName = SkypeName;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Sms"))
            {
                input.Sms = Sms;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Tel"))
            {
                input.Tel = Tel;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Tweet"))
            {
                input.Tweet = Tweet;
            }
            if (MyInvocation.BoundParameters.ContainsKey("TwitterName"))
            {
                input.TwitterName = TwitterName;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Uri"))
            {
                input.Uri = Uri;
            }
            if (MyInvocation.BoundParameters.ContainsKey("WebsiteUrl"))
            {
                input.WebsiteUrl = WebsiteUrl;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            ShortUrlUpdatePayload result = client.Sdk4meClient.Mutation(input, new ShortUrlQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "SetShortUrlError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.ShortUrl);
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
