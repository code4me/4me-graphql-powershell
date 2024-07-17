using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Rate limit query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "RateLimitQuery")]
    [OutputType(typeof(RateLimit))]
    public class InvokeRateLimitQueryCommand : InvokeQueryCommand<RateLimit, RateLimitQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeRateLimitQueryCommand()"/> class.
        /// </summary>
        public InvokeRateLimitQueryCommand() : base(true)
        {
        }
    }
}
