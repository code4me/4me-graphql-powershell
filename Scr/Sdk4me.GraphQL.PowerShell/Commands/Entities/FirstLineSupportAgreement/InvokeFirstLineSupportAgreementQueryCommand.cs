using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a First line support agreement query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "FirstLineSupportAgreementQuery")]
    [OutputType(typeof(FirstLineSupportAgreement))]
    public class InvokeFirstLineSupportAgreementQueryCommand : InvokeQueryCommand<FirstLineSupportAgreement, FirstLineSupportAgreementQuery>
    {
    }
}
