using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Person query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "PersonQuery")]
    [OutputType(typeof(Person))]
    public class InvokePersonQueryCommand : InvokeQueryCommand<Person, PersonQuery>
    {
    }
}
