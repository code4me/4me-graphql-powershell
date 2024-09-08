using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectTemplateQuery")]
    [OutputType(typeof(ProjectTemplate[]))]
    public class InvokeProjectTemplateQueryCommand : InvokeQueryCommand<ProjectTemplate, ProjectTemplateQuery>
    {
    }
}
