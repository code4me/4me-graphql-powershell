using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Knowledge article template query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "KnowledgeArticleTemplateQuery")]
    [OutputType(typeof(KnowledgeArticleTemplate))]
    public class InvokeKnowledgeArticleTemplateQueryCommand : InvokeQueryCommand<KnowledgeArticleTemplate, KnowledgeArticleTemplateQuery>
    {
    }
}
