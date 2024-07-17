using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Represents a PowerShell cmdlet for creating a new survey response.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SurveyResponse")]
    [OutputType(typeof(SurveyResponse))]
    public class NewSurveyResponseCommand : PSCmdlet
    {
        /// <summary>
        /// Identifier of the service this response is about.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceId { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the survey this response is for.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string SurveyId { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier for the client performing the mutation.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? ClientMutationId { get; set; }

        /// <summary>
        /// Whether the respondent completed the survey.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public bool Completed { get; set; } = false;

        /// <summary>
        /// Answers of this survey response.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public SurveyAnswerInput[] NewAnswers { get; set; } = Array.Empty<SurveyAnswerInput>();

        /// <summary>
        /// Identifier of the person who provided this response (i.e. the respondent).
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? PersonId { get; set; }

        /// <summary>
        /// Rating calculated based on the answers.
        /// </summary>
        [Parameter(Mandatory = false, Position = 6, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Rating { get; set; }

        /// <summary>
        /// How the individual answers were combined to calculate the rating.
        /// </summary>
        [Parameter(Mandatory = false, Position = 7, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public JToken? RatingCalculation { get; set; }

        /// <summary>
        /// Time this response was submitted.
        /// </summary>
        [Parameter(Mandatory = false, Position = 8, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public DateTime? RespondedAt { get; set; }

        /// <summary>
        /// Identifiers of the SLAs this response is for. (Ignored when supplying a personId.)
        /// </summary>
        [Parameter(Mandatory = false, Position = 9, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string[] SlaIds { get; set; } = Array.Empty<string>();

        /// <summary>
        /// An identifier for the client application submitting the resource or the name of an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 10, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? Source { get; set; }

        /// <summary>
        /// The unique identifier of the resource in an external system.
        /// </summary>
        [Parameter(Mandatory = false, Position = 11, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        public string? SourceID { get; set; }

        /// <summary>
        /// An array of survey response properties to include in the response.
        /// </summary>
        [Parameter(Mandatory = true, Position = 12, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SurveyResponseField[] Properties { get; set; } = Array.Empty<SurveyResponseField>();

        /// <summary>
        /// The client used to execute the create mutation. If not provided, the default client is used.
        /// </summary>
        [Parameter(Mandatory = false, Position = 13, ValueFromPipeline = false, ValueFromPipelineByPropertyName = true)]
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
            SurveyResponseCreateInput  input = new();
            if (MyInvocation.BoundParameters.ContainsKey("ServiceId"))
            {
                input.ServiceId = ServiceId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SurveyId"))
            {
                input.SurveyId = SurveyId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ClientMutationId"))
            {
                input.ClientMutationId = ClientMutationId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Completed"))
            {
                input.Completed = Completed;
            }
            if (MyInvocation.BoundParameters.ContainsKey("NewAnswers"))
            {
                input.NewAnswers = NewAnswers.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("PersonId"))
            {
                input.PersonId = PersonId;
            }
            if (MyInvocation.BoundParameters.ContainsKey("Rating"))
            {
                input.Rating = Rating;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RatingCalculation"))
            {
                input.RatingCalculation = RatingCalculation;
            }
            if (MyInvocation.BoundParameters.ContainsKey("RespondedAt"))
            {
                input.RespondedAt = RespondedAt;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SlaIds"))
            {
                input.SlaIds = SlaIds.ToList();
            }
            if (MyInvocation.BoundParameters.ContainsKey("Source"))
            {
                input.Source = Source;
            }
            if (MyInvocation.BoundParameters.ContainsKey("SourceID"))
            {
                input.SourceID = SourceID;
            }

            PowerShellTraceListener.RegisterCmdlet(this);
            Sdk4mePowerShellClient client = Client ?? Sdk4mePowerShellClientManager.GetClient();
            SurveyResponseCreatePayload result = client.Sdk4meClient.Mutation(input, new SurveyResponseQuery().Select(Properties), false).ConfigureAwait(true).GetAwaiter().GetResult();
            PowerShellTraceListener.UnregisterCmdlet();
            if (result.IsError())
            {
                foreach (ValidationError error in result.Errors ?? new())
                {
                    WriteError(new ErrorRecord(new Exception(error.Message), "NewSurveyResponseError", ErrorCategory.InvalidOperation, input));
                }
                return;
            }
            WriteObject(result.SurveyResponse);
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
