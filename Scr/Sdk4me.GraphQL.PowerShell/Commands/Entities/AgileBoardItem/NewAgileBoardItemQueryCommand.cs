using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Agile board item query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AgileBoardItemQuery")]
    [OutputType(typeof(AgileBoardItem))]
    public class NewAgileBoardItemQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of an agile board item properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardItemField[] Properties { get; set; } = Array.Empty<AgileBoardItemField>();

        /// <summary>
        /// Specify the Agile board to be returned using an agile board query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardQuery AgileBoard { get; set; } = new();

        /// <summary>
        /// Specify the Agile board column to be returned using an agile board column query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AgileBoardColumnQuery AgileBoardColumn { get; set; } = new();

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
            AgileBoardItemQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("AgileBoard"))
            {
                retval.SelectAgileBoard(AgileBoard);
            }
            if (MyInvocation.BoundParameters.ContainsKey("AgileBoardColumn"))
            {
                retval.SelectAgileBoardColumn(AgileBoardColumn);
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
