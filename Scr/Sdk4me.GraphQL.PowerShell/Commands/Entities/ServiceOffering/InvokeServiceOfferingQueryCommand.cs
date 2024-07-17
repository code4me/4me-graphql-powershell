using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Service offering query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ServiceOfferingQuery")]
    [OutputType(typeof(ServiceOffering))]
    public class InvokeServiceOfferingQueryCommand : InvokeQueryCommand<ServiceOffering, ServiceOfferingQuery>
    {
    }
}
