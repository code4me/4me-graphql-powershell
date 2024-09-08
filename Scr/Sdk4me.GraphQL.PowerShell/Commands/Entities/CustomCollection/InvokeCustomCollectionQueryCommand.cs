using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Custom collection query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "CustomCollectionQuery")]
    [OutputType(typeof(CustomCollection[]))]
    public class InvokeCustomCollectionQueryCommand : InvokeQueryCommand<CustomCollection, CustomCollectionQuery>
    {
    }
}
