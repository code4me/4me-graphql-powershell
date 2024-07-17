using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Service instance query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ServiceInstanceQuery")]
    [OutputType(typeof(ServiceInstance))]
    public class InvokeServiceInstanceQueryCommand : InvokeQueryCommand<ServiceInstance, ServiceInstanceQuery>
    {
    }
}
