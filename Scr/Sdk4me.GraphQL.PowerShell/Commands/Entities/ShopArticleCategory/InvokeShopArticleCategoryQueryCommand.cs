using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Shop article category query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ShopArticleCategoryQuery")]
    [OutputType(typeof(ShopArticleCategory[]))]
    public class InvokeShopArticleCategoryQueryCommand : InvokeQueryCommand<ShopArticleCategory, ShopArticleCategoryQuery>
    {
    }
}
