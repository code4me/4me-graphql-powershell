using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Automation rule query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AutomationRuleQuery")]
    [OutputType(typeof(AutomationRule[]))]
    public class InvokeAutomationRuleQueryCommand : InvokeQueryCommand<AutomationRule, AutomationRuleQuery>
    {
    }
}
