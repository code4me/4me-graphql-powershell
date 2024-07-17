using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Broadcast query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "BroadcastQuery")]
    [OutputType(typeof(Broadcast))]
    public class InvokeBroadcastQueryCommand : InvokeQueryCommand<Broadcast, BroadcastQuery>
    {
    }
}
