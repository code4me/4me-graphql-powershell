using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Trash query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TrashQuery")]
    [OutputType(typeof(Trash[]))]
    public class InvokeTrashQueryCommand : InvokeQueryCommand<Trash, TrashQuery>
    {
    }
}
