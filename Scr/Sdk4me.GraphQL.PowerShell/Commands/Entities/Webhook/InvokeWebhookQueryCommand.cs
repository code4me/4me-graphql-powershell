using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Webhook query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WebhookQuery")]
    [OutputType(typeof(Webhook[]))]
    public class InvokeWebhookQueryCommand : InvokeQueryCommand<Webhook, WebhookQuery>
    {
    }
}
