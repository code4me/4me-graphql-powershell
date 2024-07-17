using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Agile board query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AgileBoardQuery")]
    [OutputType(typeof(AgileBoard))]
    public class InvokeAgileBoardQueryCommand : InvokeQueryCommand<AgileBoard, AgileBoardQuery>
    {
    }
}
