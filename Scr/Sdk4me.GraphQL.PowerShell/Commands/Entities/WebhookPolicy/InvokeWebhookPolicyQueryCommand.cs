using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Webhook policy query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WebhookPolicyQuery")]
    [OutputType(typeof(WebhookPolicy[]))]
    public class InvokeWebhookPolicyQueryCommand : InvokeQueryCommand<WebhookPolicy, WebhookPolicyQuery>
    {
    }
}
