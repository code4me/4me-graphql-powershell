using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an App offering query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AppOfferingQuery")]
    [OutputType(typeof(AppOffering[]))]
    public class InvokeAppOfferingQueryCommand : InvokeQueryCommand<AppOffering, AppOfferingQuery>
    {
    }
}
