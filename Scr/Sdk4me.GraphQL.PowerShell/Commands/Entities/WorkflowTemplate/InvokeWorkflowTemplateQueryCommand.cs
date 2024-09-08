using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Workflow template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WorkflowTemplateQuery")]
    [OutputType(typeof(WorkflowTemplate[]))]
    public class InvokeWorkflowTemplateQueryCommand : InvokeQueryCommand<WorkflowTemplate, WorkflowTemplateQuery>
    {
    }
}
