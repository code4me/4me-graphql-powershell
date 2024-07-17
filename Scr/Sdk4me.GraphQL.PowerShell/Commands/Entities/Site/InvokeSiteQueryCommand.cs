using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Site query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SiteQuery")]
    [OutputType(typeof(Site))]
    public class InvokeSiteQueryCommand : InvokeQueryCommand<Site, SiteQuery>
    {
    }
}
