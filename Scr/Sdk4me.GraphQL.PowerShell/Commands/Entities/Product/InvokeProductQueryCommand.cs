using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Product query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProductQuery")]
    [OutputType(typeof(Product))]
    public class InvokeProductQueryCommand : InvokeQueryCommand<Product, ProductQuery>
    {
    }
}
