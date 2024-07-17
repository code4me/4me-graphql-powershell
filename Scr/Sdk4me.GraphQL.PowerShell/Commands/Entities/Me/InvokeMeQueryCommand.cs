using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Me query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "MeQuery")]
    [OutputType(typeof(Person))]
    public class InvokeMeQueryCommand : InvokeQueryCommand<Person, MeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeMeQueryCommand()"/> class.
        /// </summary>
        public InvokeMeQueryCommand() : base(true)
        {
        }
    }
}
