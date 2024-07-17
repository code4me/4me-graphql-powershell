using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Workflow task template relation query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "WorkflowTaskTemplateRelationQuery")]
    [OutputType(typeof(WorkflowTaskTemplateRelation))]
    public class NewWorkflowTaskTemplateRelationQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of a workflow task template relation properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTaskTemplateRelationField[] Properties { get; set; } = Array.Empty<WorkflowTaskTemplateRelationField>();

        /// <summary>
        /// Specify the Automation rules to be returned using an automation rule query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AutomationRuleQuery AutomationRules { get; set; } = new();

        /// <summary>
        /// Specify the Failure task template to be returned using a task template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskTemplateQuery FailureTaskTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Phase to be returned using a workflow template phase query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplatePhaseQuery Phase { get; set; } = new();

        /// <summary>
        /// Specify the Task template to be returned using a task template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskTemplateQuery TaskTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Workflow template to be returned using a workflow template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowTemplateQuery WorkflowTemplate { get; set; } = new();

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
            WorkflowTaskTemplateRelationQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("AutomationRules"))
            {
                retval.SelectAutomationRules(AutomationRules);
            }
            if (MyInvocation.BoundParameters.ContainsKey("FailureTaskTemplate"))
            {
                retval.SelectFailureTaskTemplate(FailureTaskTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Phase"))
            {
                retval.SelectPhase(Phase);
            }
            if (MyInvocation.BoundParameters.ContainsKey("TaskTemplate"))
            {
                retval.SelectTaskTemplate(TaskTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("WorkflowTemplate"))
            {
                retval.SelectWorkflowTemplate(WorkflowTemplate);
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
