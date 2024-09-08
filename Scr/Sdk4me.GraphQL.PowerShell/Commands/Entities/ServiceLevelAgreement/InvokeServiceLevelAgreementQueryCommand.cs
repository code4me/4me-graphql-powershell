using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Service level agreement query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ServiceLevelAgreementQuery")]
    [OutputType(typeof(ServiceLevelAgreement[]))]
    public class InvokeServiceLevelAgreementQueryCommand : InvokeQueryCommand<ServiceLevelAgreement, ServiceLevelAgreementQuery>
    {
    }
}
