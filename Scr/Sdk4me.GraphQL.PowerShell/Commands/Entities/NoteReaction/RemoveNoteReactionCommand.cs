using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for deleting a note reaction.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "NoteReaction")]
    [OutputType(typeof(bool))]
    public class RemoveNoteReactionCommand : PSCmdlet
    {
        /// <summary>
        /// The identifier of the note reaction to delete.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// Set the Client mutation ID value for this delete action.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// The client used to execute the delete mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            NoteReactionDeleteMutationInput  input = new(ID);

            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }

            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            NoteReactionDeleteMutationPayload result = client.Sdk4meClient.Mutation(input, false).ConfigureAwait(true).GetAwaiter().GetResult();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "RemoveNoteReactionError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(true);
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
