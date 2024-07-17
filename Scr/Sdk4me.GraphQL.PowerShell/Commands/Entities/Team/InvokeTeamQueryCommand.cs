using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Team query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TeamQuery")]
    [OutputType(typeof(Team))]
    public class InvokeTeamQueryCommand : InvokeQueryCommand<Team, TeamQuery>
    {
    }
}
