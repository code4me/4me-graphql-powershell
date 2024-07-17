using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Out of office period query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "OutOfOfficePeriodQuery")]
    [OutputType(typeof(OutOfOfficePeriod))]
    public class InvokeOutOfOfficePeriodQueryCommand : InvokeQueryCommand<OutOfOfficePeriod, OutOfOfficePeriodQuery>
    {
    }
}
