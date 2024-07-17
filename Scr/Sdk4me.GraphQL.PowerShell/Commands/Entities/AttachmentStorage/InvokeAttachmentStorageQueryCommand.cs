using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Attachment storage query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AttachmentStorageQuery")]
    [OutputType(typeof(AttachmentStorage))]
    public class InvokeAttachmentStorageQueryCommand : InvokeQueryCommand<AttachmentStorage, AttachmentStorageQuery>
    {
    }
}
