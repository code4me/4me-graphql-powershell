using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Calendar query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "CalendarQuery")]
    [OutputType(typeof(Calendar[]))]
    public class InvokeCalendarQueryCommand : InvokeQueryCommand<Calendar, CalendarQuery>
    {
    }
}
