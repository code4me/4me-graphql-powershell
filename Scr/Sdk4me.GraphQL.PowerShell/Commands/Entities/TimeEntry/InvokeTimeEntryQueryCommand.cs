using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Time entry query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TimeEntryQuery")]
    [OutputType(typeof(TimeEntry))]
    public class InvokeTimeEntryQueryCommand : InvokeQueryCommand<TimeEntry, TimeEntryQuery>
    {
    }
}
