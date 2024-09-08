using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Survey response query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SurveyResponseQuery")]
    [OutputType(typeof(SurveyResponse[]))]
    public class InvokeSurveyResponseQueryCommand : InvokeQueryCommand<SurveyResponse, SurveyResponseQuery>
    {
    }
}
