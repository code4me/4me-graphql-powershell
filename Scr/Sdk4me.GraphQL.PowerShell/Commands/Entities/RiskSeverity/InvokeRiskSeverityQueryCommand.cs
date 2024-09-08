using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Risk severity query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "RiskSeverityQuery")]
    [OutputType(typeof(RiskSeverity[]))]
    public class InvokeRiskSeverityQueryCommand : InvokeQueryCommand<RiskSeverity, RiskSeverityQuery>
    {
    }
}
