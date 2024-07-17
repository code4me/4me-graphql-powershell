using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new note reaction.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "NoteReaction")]
    [OutputType(typeof(NoteReaction))]
    public class NewNoteReactionCommand : PSCmdlet
    {
        /// <summary>
        /// The identifier of the note you want to add a reaction to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string NoteId { get; set; } = string.Empty;

        /// <summary>
        /// The type of reaction to add to the note. Valid values are:• 👍• 👎• 😀• 😕• 🎉• ❤️
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Reaction { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// An array of note reaction properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteReactionField[] Properties { get; set; } = Array.Empty<NoteReactionField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            NoteReactionCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("NoteId"))
            {
                input.NoteId = NoteId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Reaction"))
            {
                input.Reaction = Reaction;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            NoteReactionCreatePayload result = client.Sdk4meClient.Mutation(input, new NoteReactionQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewNoteReactionError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.NoteReaction);
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
