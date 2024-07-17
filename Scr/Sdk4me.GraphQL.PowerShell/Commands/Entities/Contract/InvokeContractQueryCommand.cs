using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Contract query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ContractQuery")]
    [OutputType(typeof(Contract))]
    public class InvokeContractQueryCommand : InvokeQueryCommand<Contract, ContractQuery>
    {
    }
}
