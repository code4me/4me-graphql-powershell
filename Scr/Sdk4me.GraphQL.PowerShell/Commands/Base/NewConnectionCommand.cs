using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new connection to the 4me GraphQL API using various authentication methods.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "Connection")]
    [OutputType(typeof(Sdk4mePowerShellClient))]
    public class NewConnectionCommand : PSCmdlet
    {
        /// <summary>
        /// Specifies the client ID required for OAuth authentication.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [ValidateNotNullOrEmpty]
        public string ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the client secret required for OAuth authentication.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [ValidateNotNullOrEmpty]
        public string ClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the personal access token used for authentication.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [ValidateNotNullOrEmpty]
        public string PersonalAccessToken { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the credentials used for authentication. This should include the client id and client secret.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [ValidateNotNull]
        public PSCredential? Credential { get; set; }

        /// <summary>
        /// Specifies the account identifier required for establishing the connection.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [ValidateNotNullOrEmpty]
        public string AccountID { get; set; } = string.Empty;

        /// <summary>
        /// Specifies the environment type. This setting helps define the API configuration.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2ApiBaseUrl")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessTokenApiBaseUrl")]
        [Parameter(Mandatory = false, ParameterSetName = "CredentialApiBaseUrl")]
        [ValidateNotNull]
        public EnvironmentType EnvironmentType { get; set; }

        /// <summary>
        /// Specifies the region for the client. This setting determines the geographical API endpoint.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = true, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = true, ParameterSetName = "Credential")]
        [ValidateNotNull]
        public EnvironmentRegion EnvironmentRegion { get; set; }

        /// <summary>
        /// Allows specification of a custom base URL for constructing the full API endpoint.
        /// When set, this will override the default URL derived from the provided environment type and region.
        /// </summary>
        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [Hidden]
        public string? ApiBaseUrl { get; set; }

        /// <summary>
        /// Sets the maximum number of recursive requests allowed during operations.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [ValidateNotNull]
        [ValidateRange(1, 1000)]
        public int MaximumRecursiveRequests { get; private set; } = 10;

        /// <summary>
        /// Specifies the maximum depth for query connections.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [ValidateNotNull]
        [ValidateRange(1, 13)]
        public int MaximumQueryDepthLevelConnections { get; set; } = 2;

        /// <summary>
        /// Specifies the default number of items to be requested per operation.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [ValidateNotNull]
        [ValidateRange(1, 100)]
        public int DefaultItemsPerRequest { get; set; } = 100;

        /// <summary>
        /// Enables or disables tolerance for enumerators within the serializer.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "OAuth2")]
        [Parameter(Mandatory = false, ParameterSetName = "PersonalAccessToken")]
        [Parameter(Mandatory = false, ParameterSetName = "Credential")]
        [ValidateNotNull]
        public bool EnumeratorTolerantSerializer { get; set; } = true;

        /// <summary>
        /// Initial setup operations before processing the command.
        /// </summary>
        protected override void BeginProcessing()
        {
            this.StartProcessingHeader();
            this.WriteParameters();
        }

        /// <summary>
        /// Executes the connection process based on the specified parameters.
        /// </summary>
        protected override void ProcessRecord()
        {
            try
            {
                Sdk4mePowerShellClient client;
                if (ApiBaseUrl != null)
                {
                    client = ParameterSetName switch
                    {
                        "OAuth2" => new(ClientId, ClientSecret, AccountID, ApiBaseUrl),
                        "PersonalAccessToken" => new(PersonalAccessToken, AccountID, ApiBaseUrl),
                        "Credential" => Credential == null ? throw new ArgumentNullException(nameof(Credential)) : new(Credential.UserName, Credential.GetNetworkCredential().Password, AccountID, ApiBaseUrl),
                        _ => throw new InvalidOperationException()
                    };
                }
                else
                {
                    client = ParameterSetName switch
                    {
                        "OAuth2" => new(ClientId, ClientSecret, AccountID, EnvironmentType, EnvironmentRegion),
                        "PersonalAccessToken" => new(PersonalAccessToken, AccountID, EnvironmentType, EnvironmentRegion),
                        "Credential" => Credential == null ? throw new ArgumentNullException(nameof(Credential)) : new(Credential.UserName, Credential.GetNetworkCredential().Password, AccountID, EnvironmentType, EnvironmentRegion),
                        _ => throw new InvalidOperationException()
                    };
                }

                if (MyInvocation.BoundParameters.ContainsKey("MaximumRecursiveRequests"))
                {
                    client.MaximumRecursiveRequests = MaximumRecursiveRequests;
                }
                if (MyInvocation.BoundParameters.ContainsKey("MaximumQueryDepthLevelConnections"))
                {
                    client.MaximumQueryDepthLevelConnections = MaximumQueryDepthLevelConnections;
                }

                if (MyInvocation.BoundParameters.ContainsKey("DefaultItemsPerRequest"))
                {
                    client.DefaultItemsPerRequest = DefaultItemsPerRequest;
                }
                if (MyInvocation.BoundParameters.ContainsKey("EnumeratorTolerantSerializer"))
                {
                    client.EnumeratorTolerantSerializer = EnumeratorTolerantSerializer;
                }

                Sdk4mePowerShellClientManager.AddClient(client);
                WriteObject(client);
            }
            catch (Exception ex)
            {
                ex.ThrowAsTerminatingError(this, "ConnectionError", ErrorCategory.ConnectionError);
            }
        }

        /// <summary>
        /// Final cleanup operations after processing the command.
        /// </summary>
        protected override void EndProcessing()
        {
            this.EndProcessingFooter();
        }
    }
}
