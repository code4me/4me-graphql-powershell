using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new translation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Translation")]
    [OutputType(typeof(Translation))]
    public class NewTranslationCommand : PSCmdlet
    {
        /// <summary>
        /// The field of the record from which the translation is obtained.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Field { get; set; } = string.Empty;

        /// <summary>
        /// The language in which the text is specified.The complete list is available on the 4me developer site.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// The record from which the translation is obtained.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string OwnerId { get; set; } = string.Empty;

        /// <summary>
        /// The text of the translation.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// An array of translation properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationField[] Properties { get; set; } = Array.Empty<TranslationField>();

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
            TranslationCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Field"))
            {
                input.Field = Field;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Language"))
            {
                input.Language = Language;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerId"))
            {
                input.OwnerId = OwnerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Text"))
            {
                input.Text = Text;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            TranslationCreatePayload result = client.Sdk4meClient.Mutation(input, new TranslationQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewTranslationError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Translation);
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
