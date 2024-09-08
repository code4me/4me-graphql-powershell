using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Knowledge article query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "KnowledgeArticleQuery")]
    [OutputType(typeof(KnowledgeArticle[]))]
    public class InvokeKnowledgeArticleQueryCommand : InvokeQueryCommand<KnowledgeArticle, KnowledgeArticleQuery>
    {
    }
}
