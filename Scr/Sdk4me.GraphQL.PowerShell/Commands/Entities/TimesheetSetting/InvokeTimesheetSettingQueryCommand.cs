using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Timesheet setting query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TimesheetSettingQuery")]
    [OutputType(typeof(TimesheetSetting))]
    public class InvokeTimesheetSettingQueryCommand : InvokeQueryCommand<TimesheetSetting, TimesheetSettingQuery>
    {
    }
}
