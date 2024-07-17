using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project task template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectTaskTemplateQuery")]
    [OutputType(typeof(ProjectTaskTemplate))]
    public class InvokeProjectTaskTemplateQueryCommand : InvokeQueryCommand<ProjectTaskTemplate, ProjectTaskTemplateQuery>
    {
    }
}
