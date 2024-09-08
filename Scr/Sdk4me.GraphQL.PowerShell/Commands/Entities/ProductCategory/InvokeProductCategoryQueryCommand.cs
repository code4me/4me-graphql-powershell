using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Product category query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ProductCategoryQuery")]
    [OutputType(typeof(ProductCategory[]))]
    public class InvokeProductCategoryQueryCommand : InvokeQueryCommand<ProductCategory, ProductCategoryQuery>
    {
    }
}
