using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Task query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TaskQuery")]
    [OutputType(typeof(Task))]
    public class InvokeTaskQueryCommand : InvokeQueryCommand<Task, TaskQuery>
    {
    }
}
