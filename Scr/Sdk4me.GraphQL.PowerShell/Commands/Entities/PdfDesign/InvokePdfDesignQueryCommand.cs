using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Pdf design query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "PdfDesignQuery")]
    [OutputType(typeof(PdfDesign[]))]
    public class InvokePdfDesignQueryCommand : InvokeQueryCommand<PdfDesign, PdfDesignQuery>
    {
    }
}
