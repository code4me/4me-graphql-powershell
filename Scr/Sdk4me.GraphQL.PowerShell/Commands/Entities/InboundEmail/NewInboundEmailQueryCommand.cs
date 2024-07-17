﻿using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Inbound email query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "InboundEmailQuery")]
    [OutputType(typeof(InboundEmail))]
    public class NewInboundEmailQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of an inbound email properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public InboundEmailField[] Properties { get; set; } = Array.Empty<InboundEmailField>();

        /// <summary>
        /// Specify the Account to be returned using an account query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery Account { get; set; } = new();

        /// <summary>
        /// Specify the Note to be returned using a note query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public NoteQuery Note { get; set; } = new();

        /// <summary>
        /// Specify the Record Problem details to be returned using a problem query. This applies if the item is a problem.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProblemQuery RecordProblem { get; set; } = new();

        /// <summary>
        /// Specify the Record Project details to be returned using a project query. This applies if the item is a project.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectQuery RecordProject { get; set; } = new();

        /// <summary>
        /// Specify the Record Project task details to be returned using a project task query. This applies if the item is a project task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProjectTaskQuery RecordProjectTask { get; set; } = new();

        /// <summary>
        /// Specify the Record Release details to be returned using a release query. This applies if the item is a release.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ReleaseQuery RecordRelease { get; set; } = new();

        /// <summary>
        /// Specify the Record Request details to be returned using a request query. This applies if the item is a request.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestQuery RecordRequest { get; set; } = new();

        /// <summary>
        /// Specify the Record Risk details to be returned using a risk query. This applies if the item is a risk.
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RiskQuery RecordRisk { get; set; } = new();

        /// <summary>
        /// Specify the Record Task details to be returned using a task query. This applies if the item is a task.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TaskQuery RecordTask { get; set; } = new();

        /// <summary>
        /// Specify the Record Workflow details to be returned using a workflow query. This applies if the item is a workflow.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public WorkflowQuery RecordWorkflow { get; set; } = new();

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
            InboundEmailQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("Account"))
            {
                retval.SelectAccount(Account);
            }
            if (MyInvocation.BoundParameters.ContainsKey("Note"))
            {
                retval.SelectNote(Note);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordProblem"))
            {
                retval.SelectRecord(RecordProblem);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordProject"))
            {
                retval.SelectRecord(RecordProject);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordProjectTask"))
            {
                retval.SelectRecord(RecordProjectTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordRelease"))
            {
                retval.SelectRecord(RecordRelease);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordRequest"))
            {
                retval.SelectRecord(RecordRequest);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordRisk"))
            {
                retval.SelectRecord(RecordRisk);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordTask"))
            {
                retval.SelectRecord(RecordTask);
            }
            if (MyInvocation.BoundParameters.ContainsKey("RecordWorkflow"))
            {
                retval.SelectRecord(RecordWorkflow);
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
