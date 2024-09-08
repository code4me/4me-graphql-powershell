using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Invoice query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "InvoiceQuery")]
    [OutputType(typeof(Invoice[]))]
    public class InvokeInvoiceQueryCommand : InvokeQueryCommand<Invoice, InvoiceQuery>
    {
    }
}
