using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Sync set query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SyncSetQuery")]
    [OutputType(typeof(SyncSet))]
    public class InvokeSyncSetQueryCommand : InvokeQueryCommand<SyncSet, SyncSetQuery>
    {
    }
}
