using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an UI extension query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UiExtensionQuery")]
    [OutputType(typeof(UiExtension))]
    public class InvokeUiExtensionQueryCommand : InvokeQueryCommand<UiExtension, UiExtensionQuery>
    {
    }
}
