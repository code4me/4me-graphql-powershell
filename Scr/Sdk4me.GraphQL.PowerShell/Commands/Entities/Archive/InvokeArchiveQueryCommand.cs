using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Archive query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ArchiveQuery")]
    [OutputType(typeof(Archive[]))]
    public class InvokeArchiveQueryCommand : InvokeQueryCommand<Archive, ArchiveQuery>
    {
    }
}
