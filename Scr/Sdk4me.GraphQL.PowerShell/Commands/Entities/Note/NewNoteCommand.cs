using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new note.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Note")]
    [OutputType(typeof(Note))]
    public class NewNoteCommand : PSCmdlet
    {
        /// <summary>
        /// Text of the note.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// The attachments used in the note field.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AttachmentInput[] Attachments { get; set; } = Array.Empty<AttachmentInput>();

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the note should be visible only for people who have the Auditor, Specialist or Account Administrator role of the account. Internal notes are only available for Requests.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Internal { get; set; } = false;

        /// <summary>
        /// The record that the note should be added to.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? OwnerId { get; set; }

        /// <summary>
        /// Whether Note Added notifications for this note should be suppressed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool SuppressNoteAddedNotifications { get; set; } = false;

        /// <summary>
        /// An array of note properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteField[] Properties { get; set; } = Array.Empty<NoteField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            NoteCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("Text"))
            {
                input.Text = Text;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Attachments"))
            {
                input.Attachments = Attachments.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Internal"))
            {
                input.Internal = Internal;
            }
            if (MyInvocation.BoundParameters.ContainsKey("OwnerId"))
            {
                input.OwnerId = OwnerId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SuppressNoteAddedNotifications"))
            {
                input.SuppressNoteAddedNotifications = SuppressNoteAddedNotifications;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            NoteCreatePayload result = client.Sdk4meClient.Mutation(input, new NoteQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewNoteError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.Note);
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
