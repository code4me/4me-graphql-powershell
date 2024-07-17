using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Short URL query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ShortUrlQuery")]
    [OutputType(typeof(ShortUrl))]
    public class InvokeShortUrlQueryCommand : InvokeQueryCommand<ShortUrl, ShortUrlQuery>
    {
    }
}
