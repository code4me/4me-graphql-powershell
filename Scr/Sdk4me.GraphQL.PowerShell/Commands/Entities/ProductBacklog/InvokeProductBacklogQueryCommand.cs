using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Product backlog query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProductBacklogQuery")]
    [OutputType(typeof(ProductBacklog))]
    public class InvokeProductBacklogQueryCommand : InvokeQueryCommand<ProductBacklog, ProductBacklogQuery>
    {
    }
}
