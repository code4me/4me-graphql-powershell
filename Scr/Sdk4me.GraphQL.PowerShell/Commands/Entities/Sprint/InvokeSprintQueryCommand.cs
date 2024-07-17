using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Sprint query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SprintQuery")]
    [OutputType(typeof(Sprint))]
    public class InvokeSprintQueryCommand : InvokeQueryCommand<Sprint, SprintQuery>
    {
    }
}
