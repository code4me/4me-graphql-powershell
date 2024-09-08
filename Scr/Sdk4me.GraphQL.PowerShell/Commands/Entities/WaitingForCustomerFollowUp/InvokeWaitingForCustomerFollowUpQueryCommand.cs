using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Waiting for customer follow up query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "WaitingForCustomerFollowUpQuery")]
    [OutputType(typeof(WaitingForCustomerFollowUp[]))]
    public class InvokeWaitingForCustomerFollowUpQueryCommand : InvokeQueryCommand<WaitingForCustomerFollowUp, WaitingForCustomerFollowUpQuery>
    {
    }
}
