using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a command to create a new custom filter.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CustomFilter")]
    [OutputType(typeof(CustomFilter))]
    public class NewCustomFilterCommand : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the name of the filter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the operator for the filter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNull]
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the values for the filter.
        /// </summary>
        [Parameter(Mandatory = false)]
        public string?[]? Values { get; set; }

        /// <summary>
        /// Perform initialization of command properties and state.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Process the record by creating and validating a new custom filter.
        /// </summary>
        protected override void ProcessRecord()
        {
            CustomFilter retval = new(Name, Operator, Values);
            if (retval.IsValid(out string? errorMessage))
            {
                WriteObject(retval);
            }
            else
            {
                ThrowTerminatingError(new ErrorRecord(new ArgumentException(errorMessage), "CustomFilterError", ErrorCategory.InvalidArgument, this));
            }
        }

        /// <summary>
        /// Perform cleanup operations or finalizations after processing.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}