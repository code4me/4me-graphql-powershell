using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Service query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ServiceQuery")]
    [OutputType(typeof(Service))]
    public class InvokeServiceQueryCommand : InvokeQueryCommand<Service, ServiceQuery>
    {
    }
}
