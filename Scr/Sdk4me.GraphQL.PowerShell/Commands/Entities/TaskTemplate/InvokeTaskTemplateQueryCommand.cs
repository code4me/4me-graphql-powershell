using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Task template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TaskTemplateQuery")]
    [OutputType(typeof(TaskTemplate[]))]
    public class InvokeTaskTemplateQueryCommand : InvokeQueryCommand<TaskTemplate, TaskTemplateQuery>
    {
    }
}
