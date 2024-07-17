using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Scrum workspace query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ScrumWorkspaceQuery")]
    [OutputType(typeof(ScrumWorkspace))]
    public class InvokeScrumWorkspaceQueryCommand : InvokeQueryCommand<ScrumWorkspace, ScrumWorkspaceQuery>
    {
    }
}
