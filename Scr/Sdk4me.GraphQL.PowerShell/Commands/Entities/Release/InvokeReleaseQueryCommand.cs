using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Release query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ReleaseQuery")]
    [OutputType(typeof(Release))]
    public class InvokeReleaseQueryCommand : InvokeQueryCommand<Release, ReleaseQuery>
    {
    }
}
