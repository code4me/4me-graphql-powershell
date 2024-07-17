using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Workflow template phase query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "WorkflowTemplatePhaseQuery")]
    [OutputType(typeof(WorkflowTemplatePhase))]
    public class NewWorkflowTemplatePhaseQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of a workflow template phase properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseField[] Properties { get; set; } = Array.Empty<WorkflowTemplatePhaseField>();

        /// <summary>
        /// Specify the Translations to be returned using a translation query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery Translations { get; set; } = new();

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
            WorkflowTemplatePhaseQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("Translations"))
            {
                retval.SelectTranslations(Translations);
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
