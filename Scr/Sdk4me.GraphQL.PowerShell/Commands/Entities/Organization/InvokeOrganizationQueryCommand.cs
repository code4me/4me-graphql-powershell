using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for invoking an Organization query.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "OrganizationQuery")]
    [OutputType(typeof(Organization[]))]
    public class InvokeOrganizationQueryCommand : InvokeQueryCommand<Organization, OrganizationQuery>
    {
    }
}
