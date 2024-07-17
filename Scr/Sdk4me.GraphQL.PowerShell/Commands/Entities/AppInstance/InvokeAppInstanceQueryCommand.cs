using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an App instance query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AppInstanceQuery")]
    [OutputType(typeof(AppInstance))]
    public class InvokeAppInstanceQueryCommand : InvokeQueryCommand<AppInstance, AppInstanceQuery>
    {
    }
}
