using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Reservation offering query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ReservationOfferingQuery")]
    [OutputType(typeof(ReservationOffering))]
    public class InvokeReservationOfferingQueryCommand : InvokeQueryCommand<ReservationOffering, ReservationOfferingQuery>
    {
    }
}
