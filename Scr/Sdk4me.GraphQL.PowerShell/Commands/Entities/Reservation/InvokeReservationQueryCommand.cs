using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Reservation query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ReservationQuery")]
    [OutputType(typeof(Reservation[]))]
    public class InvokeReservationQueryCommand : InvokeQueryCommand<Reservation, ReservationQuery>
    {
    }
}
