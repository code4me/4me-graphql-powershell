using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Effort class rate query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "EffortClassRateQuery")]
    [OutputType(typeof(EffortClassRate))]
    public class NewEffortClassRateQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of an effort class rate properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassRateField[] Properties { get; set; } = Array.Empty<EffortClassRateField>();

        /// <summary>
        /// Specify the Effort class to be returned using an effort class query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public EffortClassQuery EffortClass { get; set; } = new();

        /// <summary>
        /// Specify the Service offering to be returned using a service offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery ServiceOffering { get; set; } = new();

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
            EffortClassRateQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("EffortClass"))
            {
                retval.SelectEffortClass(EffortClass);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceOffering"))
            {
                retval.SelectServiceOffering(ServiceOffering);
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
