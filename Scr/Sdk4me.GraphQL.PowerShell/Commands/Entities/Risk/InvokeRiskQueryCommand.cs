using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Risk query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "RiskQuery")]
    [OutputType(typeof(Risk))]
    public class InvokeRiskQueryCommand : InvokeQueryCommand<Risk, RiskQuery>
    {
    }
}
