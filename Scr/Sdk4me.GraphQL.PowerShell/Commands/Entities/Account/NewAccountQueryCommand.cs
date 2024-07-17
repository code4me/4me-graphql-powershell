using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Account query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AccountQuery")]
    [OutputType(typeof(Account))]
    public class NewAccountQueryCommand : PSCmdlet
    {
        /// <summary>
        /// An array of an account properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountField[] Properties { get; set; } = Array.Empty<AccountField>();

        /// <summary>
        /// Specify the Organization to be returned using an organization query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public OrganizationQuery Organization { get; set; } = new();

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Constructs and configures the object based on the provided parameters, and outputs it.
        /// </summary>
        protected override void ProcessRecord()
        {
            AccountQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("Organization"))
            {
                retval.SelectOrganization(Organization);
            }

            retval.Select(Properties);
            WriteObject(retval);
        }

        /// <summary>
        /// Completes the processing of the command. This method is called once after all records have been processed.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
