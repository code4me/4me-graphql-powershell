using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Shop order line query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ShopOrderLineQuery")]
    [OutputType(typeof(ShopOrderLine))]
    public class InvokeShopOrderLineQueryCommand : InvokeQueryCommand<ShopOrderLine, ShopOrderLineQuery>
    {
    }
}
