using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Survey query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SurveyQuery")]
    [OutputType(typeof(Survey[]))]
    public class InvokeSurveyQueryCommand : InvokeQueryCommand<Survey, SurveyQuery>
    {
    }
}
