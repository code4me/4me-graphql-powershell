using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new app offering automation rule.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AppOfferingAutomationRule")]
    [OutputType(typeof(AppOfferingAutomationRule))]
    public class NewAppOfferingAutomationRuleCommand : PSCmdlet
    {
        /// <summary>
        /// Identifier of the app offering the rule belongs to.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AppOfferingId { get; set; } = string.Empty;

        /// <summary>
        /// The Condition field is used to define the condition that needs to be met in order for the update action(s) of the rule to be performed. For example: is_assigned and !badge.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Condition { get; set; } = string.Empty;

        /// <summary>
        /// The name of the automation rule.
        /// </summary>
        [Parameter(Mandatory = true, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The Trigger field is used to specify when the automation rule is to be triggered, for example on status update or on note added.
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Trigger { get; set; } = string.Empty;

        /// <summary>
        /// The Actions field is used to define actions that should be executed when the condition of the automation rule is met.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AutomationRuleActionInput[] Actions { get; set; } = Array.Empty<AutomationRuleActionInput>();

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// A high-level description of the automation rule&apos;s function.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Description { get; set; }

        /// <summary>
        /// The Expressions field is used to define expressions that can subsequently be used to define the rule&apos;s conditions and the update action(s) that the rule is to perform.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public AutomationRuleExpressionInput[] Expressions { get; set; } = Array.Empty<AutomationRuleExpressionInput>();

        /// <summary>
        /// The record type this rule is linked to.Valid values are:• request• task• ci
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Generic { get; set; }

        /// <summary>
        /// The Position field dictates the order in which the automation rule is executed.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public long? Position { get; set; }

        /// <summary>
        /// An array of app offering automation rule properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AppOfferingAutomationRuleField[] Properties { get; set; } = Array.Empty<AppOfferingAutomationRuleField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public Sdk4mePowerShellClient? Client { get; set; }

        /// <summary>
        /// Initializes the processing of the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Executes query against the 4me GraphQL API.
        /// </summary>
        protected override void ProcessRecord()
        {
            AppOfferingAutomationRuleCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("AppOfferingId"))
            {
                input.AppOfferingId = AppOfferingId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Condition"))
            {
                input.Condition = Condition;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                input.Name = Name;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Trigger"))
            {
                input.Trigger = Trigger;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Actions"))
            {
                input.Actions = Actions.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Description"))
            {
                input.Description = Description;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Expressions"))
            {
                input.Expressions = Expressions.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Generic"))
            {
                input.Generic = Generic;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Position"))
            {
                input.Position = Position;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            AppOfferingAutomationRuleCreatePayload result = client.Sdk4meClient.Mutation(input, new AppOfferingAutomationRuleQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewAppOfferingAutomationRuleError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.AppOfferingAutomationRule);
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
