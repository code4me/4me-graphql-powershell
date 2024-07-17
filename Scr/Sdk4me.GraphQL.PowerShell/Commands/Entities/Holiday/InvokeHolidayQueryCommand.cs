using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Holiday query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "HolidayQuery")]
    [OutputType(typeof(Holiday))]
    public class InvokeHolidayQueryCommand : InvokeQueryCommand<Holiday, HolidayQuery>
    {
    }
}
