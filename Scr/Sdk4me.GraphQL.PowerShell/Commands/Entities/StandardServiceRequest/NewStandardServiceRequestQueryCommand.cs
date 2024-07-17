using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new Standard service request query.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "StandardServiceRequestQuery")]
    [OutputType(typeof(StandardServiceRequest))]
    public class NewStandardServiceRequestQueryCommand : PSCmdlet
    {
        /// <summary>
        /// The request specifies a maximum number of items per request. The allowed range for the number of items is between 1 and 100, inclusive..
        /// </summary>
        [Parameter(Mandatory = false, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int ItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// An array of a standard service request properties to include in the results.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestField[] Properties { get; set; } = Array.Empty<StandardServiceRequestField>();

        /// <summary>
        /// Specify the Request template to be returned using a request template query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery RequestTemplate { get; set; } = new();

        /// <summary>
        /// Specify the Service offering to be returned using a service offering query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery ServiceOffering { get; set; } = new();

        /// <summary>
        /// Specify the SLA notification scheme to be returned using a service level agreement notification scheme query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery SlaNotificationScheme { get; set; } = new();

        /// <summary>
        /// Specify the Support hours to be returned using a calendar query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery SupportHours { get; set; } = new();

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
            StandardServiceRequestQuery retval = new();

            if (MyInvocation.BoundParameters.ContainsKey("RequestTemplate"))
            {
                retval.SelectRequestTemplate(RequestTemplate);
            }
            if (MyInvocation.BoundParameters.ContainsKey("ServiceOffering"))
            {
                retval.SelectServiceOffering(ServiceOffering);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaNotificationScheme"))
            {
                retval.SelectSlaNotificationScheme(SlaNotificationScheme);
            }
            if (MyInvocation.BoundParameters.ContainsKey("SupportHours"))
            {
                retval.SelectSupportHours(SupportHours);
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
