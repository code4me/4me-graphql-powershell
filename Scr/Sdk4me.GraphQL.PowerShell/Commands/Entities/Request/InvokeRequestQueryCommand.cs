using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Request query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "RequestQuery")]
    [OutputType(typeof(Request))]
    public class InvokeRequestQueryCommand : InvokeQueryCommand<Request, RequestQuery>
    {
    }
}
