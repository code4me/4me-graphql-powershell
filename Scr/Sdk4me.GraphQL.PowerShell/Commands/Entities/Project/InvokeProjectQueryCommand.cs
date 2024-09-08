using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectQuery")]
    [OutputType(typeof(Project[]))]
    public class InvokeProjectQueryCommand : InvokeQueryCommand<Project, ProjectQuery>
    {
    }
}
