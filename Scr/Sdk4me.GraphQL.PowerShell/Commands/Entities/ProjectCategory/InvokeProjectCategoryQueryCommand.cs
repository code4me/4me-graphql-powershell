using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project category query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectCategoryQuery")]
    [OutputType(typeof(ProjectCategory))]
    public class InvokeProjectCategoryQueryCommand : InvokeQueryCommand<ProjectCategory, ProjectCategoryQuery>
    {
    }
}
