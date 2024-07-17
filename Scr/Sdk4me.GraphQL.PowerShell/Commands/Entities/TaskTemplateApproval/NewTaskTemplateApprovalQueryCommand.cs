using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Task template approval query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "TaskTemplateApprovalQuery")]
    [OutputType(typeof(TaskTemplateApproval))]
    public class NewTaskTemplateApprovalQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of a task template approval properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskTemplateApprovalField[] Properties { get; set; } = Array.Empty<TaskTemplateApprovalField>();

        /// <summary>
        /// Specify the Approver to be returned using a person query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery Approver { get; set; } = new();

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
            TaskTemplateApprovalQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("Approver"))
            {
                retval.SelectApprover(Approver);
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
