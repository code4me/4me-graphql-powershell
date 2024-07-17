using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Affected SLA query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AffectedSlaQuery")]
    [OutputType(typeof(AffectedSla))]
    public class InvokeAffectedSlaQueryCommand : InvokeQueryCommand<AffectedSla, AffectedSlaQuery>
    {
    }
}
