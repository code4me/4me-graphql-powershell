using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Service category query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ServiceCategoryQuery")]
    [OutputType(typeof(ServiceCategory))]
    public class InvokeServiceCategoryQueryCommand : InvokeQueryCommand<ServiceCategory, ServiceCategoryQuery>
    {
    }
}
