using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Shop article query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ShopArticleQuery")]
    [OutputType(typeof(ShopArticle))]
    public class InvokeShopArticleQueryCommand : InvokeQueryCommand<ShopArticle, ShopArticleQuery>
    {
    }
}
