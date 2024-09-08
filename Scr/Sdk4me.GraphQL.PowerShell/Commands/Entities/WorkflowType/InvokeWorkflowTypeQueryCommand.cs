using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Workflow type query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WorkflowTypeQuery")]
    [OutputType(typeof(WorkflowType[]))]
    public class InvokeWorkflowTypeQueryCommand : InvokeQueryCommand<WorkflowType, WorkflowTypeQuery>
    {
    }
}
