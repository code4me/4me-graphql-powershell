using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Account query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "AccountQuery")]
    [OutputType(typeof(Account))]
    public class InvokeAccountQueryCommand : InvokeQueryCommand<Account, AccountQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeAccountQueryCommand()"/> class.
        /// </summary>
        public InvokeAccountQueryCommand() : base(true)
        {
        }
    }
}
