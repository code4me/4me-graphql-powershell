using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Translation query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "TranslationQuery")]
    [OutputType(typeof(Translation))]
    public class InvokeTranslationQueryCommand : InvokeQueryCommand<Translation, TranslationQuery>
    {
    }
}
