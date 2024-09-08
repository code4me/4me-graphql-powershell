using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Skill pool query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SkillPoolQuery")]
    [OutputType(typeof(SkillPool[]))]
    public class InvokeSkillPoolQueryCommand : InvokeQueryCommand<SkillPool, SkillPoolQuery>
    {
    }
}
