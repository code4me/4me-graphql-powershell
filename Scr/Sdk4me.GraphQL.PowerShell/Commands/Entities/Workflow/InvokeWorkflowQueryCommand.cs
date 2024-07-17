using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Workflow query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WorkflowQuery")]
    [OutputType(typeof(Workflow))]
    public class InvokeWorkflowQueryCommand : InvokeQueryCommand<Workflow, WorkflowQuery>
    {
    }
}
