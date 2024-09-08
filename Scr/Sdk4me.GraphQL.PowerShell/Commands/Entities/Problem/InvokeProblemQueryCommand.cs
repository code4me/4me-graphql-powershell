using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Problem query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProblemQuery")]
    [OutputType(typeof(Problem[]))]
    public class InvokeProblemQueryCommand : InvokeQueryCommand<Problem, ProblemQuery>
    {
    }
}
