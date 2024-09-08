using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project task query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectTaskQuery")]
    [OutputType(typeof(ProjectTask[]))]
    public class InvokeProjectTaskQueryCommand : InvokeQueryCommand<ProjectTask, ProjectTaskQuery>
    {
    }
}
