using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a SLA notification scheme query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SlaNotificationSchemeQuery")]
    [OutputType(typeof(SlaNotificationScheme))]
    public class InvokeSlaNotificationSchemeQueryCommand : InvokeQueryCommand<SlaNotificationScheme, SlaNotificationSchemeQuery>
    {
    }
}
