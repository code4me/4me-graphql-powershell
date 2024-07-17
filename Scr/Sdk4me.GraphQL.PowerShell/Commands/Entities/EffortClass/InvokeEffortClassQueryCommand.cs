using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Effort class query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "EffortClassQuery")]
    [OutputType(typeof(EffortClass))]
    public class InvokeEffortClassQueryCommand : InvokeQueryCommand<EffortClass, EffortClassQuery>
    {
    }
}
