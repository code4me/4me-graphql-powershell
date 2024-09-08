using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Custom collection element query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "CustomCollectionElementQuery")]
    [OutputType(typeof(CustomCollectionElement[]))]
    public class InvokeCustomCollectionElementQueryCommand : InvokeQueryCommand<CustomCollectionElement, CustomCollectionElementQuery>
    {
    }
}
