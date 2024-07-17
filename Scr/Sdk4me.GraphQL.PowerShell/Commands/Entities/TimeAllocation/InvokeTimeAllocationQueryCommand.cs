using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Time allocation query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TimeAllocationQuery")]
    [OutputType(typeof(TimeAllocation))]
    public class InvokeTimeAllocationQueryCommand : InvokeQueryCommand<TimeAllocation, TimeAllocationQuery>
    {
    }
}
