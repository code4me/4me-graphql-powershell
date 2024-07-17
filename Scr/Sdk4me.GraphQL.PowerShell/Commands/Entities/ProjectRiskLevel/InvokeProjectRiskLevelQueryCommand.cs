using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Project risk level query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProjectRiskLevelQuery")]
    [OutputType(typeof(ProjectRiskLevel))]
    public class InvokeProjectRiskLevelQueryCommand : InvokeQueryCommand<ProjectRiskLevel, ProjectRiskLevelQuery>
    {
    }
}
