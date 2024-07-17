using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Request template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "RequestTemplateQuery")]
    [OutputType(typeof(RequestTemplate))]
    public class InvokeRequestTemplateQueryCommand : InvokeQueryCommand<RequestTemplate, RequestTemplateQuery>
    {
    }
}
