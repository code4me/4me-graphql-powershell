using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking a Configuration item query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "ConfigurationItemQuery")]
    [OutputType(typeof(ConfigurationItem))]
    public class InvokeConfigurationItemQueryCommand : InvokeQueryCommand<ConfigurationItem, ConfigurationItemQuery>
    {
    }
}
