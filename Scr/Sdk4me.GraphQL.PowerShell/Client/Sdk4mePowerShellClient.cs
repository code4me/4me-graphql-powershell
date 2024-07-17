namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// The 4me GraphQL PowerShell client.
    /// </summary>
    public sealed class Sdk4mePowerShellClient
    {
        private readonly Sdk4meClient client;

        /// <summary>
        /// Get the <see cref="GraphQL.Sdk4meClient"/>.
        /// </summary>
        internal Sdk4meClient Sdk4meClient
        {
            get => client;
        }

        /// <summary>
        /// <br>Get or set the number of recursive requests.</br>
        /// <br>The value must be at least 1 and maximum 1000.</br>
        /// </summary>
        public int MaximumRecursiveRequests
        {
            get => client.MaximumRecursiveRequests;
            set => client.MaximumRecursiveRequests = value;
        }

        /// <summary>
        /// <br>Get or set the maximum number of GraphQL depth level connections.</br>
        /// <br>The value must be at least 1 and maximum 13.</br>
        /// <para>Warning: changing this to a higher value can impact performance significantly because of the built-in pagination handling. The default value is 2.</para>
        /// </summary>
        public int MaximumQueryDepthLevelConnections
        {
            get => client.MaximumQueryDepthLevelConnections;
            set => client.MaximumQueryDepthLevelConnections = value;
        }

        /// <summary>
        /// <br>Get or set the number of objects returned per API call.</br>
        /// <br>The value needs to be between 1 and 100 inclusive.</br>
        /// </summary>
        public int DefaultItemsPerRequest
        {
            get => client.DefaultItemsPerRequest;
            set => client.DefaultItemsPerRequest = value;
        }

        /// <summary>
        /// Get or set the 4me account ID.
        /// </summary>
        public string AccountID
        {
            get => client.AccountID;
            set => client.AccountID = value;
        }

        /// <summary>
        /// <para>
        /// <br>Specify the enumerator serialization behavior.</br>
        /// </para>
        /// <br>True to ignore unmappable enumerator values; otherwise false.</br>
        /// <br>If the SDK cannot recognize a specific enumerator value, it will either return null or a default value instead.</br>
        /// </summary>
        public bool EnumeratorTolerantSerializer
        {
            get => client.EnumeratorTolerantSerializer;
            set => client.EnumeratorTolerantSerializer = value;
        }

        /// <summary>
        /// Create a new instance of the 4me GraphQL SDK PowerShell client.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        public Sdk4mePowerShellClient(string personalAccessToken, string accountID, EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            client = new(new AuthenticationToken(personalAccessToken), accountID, environment, environmentRegion);
        }

        /// <summary>
        /// Create a new instance of the 4me GraphQL SDK PowerShell client.
        /// </summary>
        /// <param name="clientId">The OAuht2 client id.</param>
        /// <param name="clientSecret">The OAuth2 client secret.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="environment">The 4me environment.</param>
        /// <param name="environmentRegion">The 4me environment region.</param>
        public Sdk4mePowerShellClient(string clientId, string clientSecret, string accountID, EnvironmentType environment, EnvironmentRegion environmentRegion)
        {
            client = new(new AuthenticationToken(clientId, clientSecret), accountID, environment, environmentRegion);
        }

        /// <summary>
        /// Create a new instance of the 4me GraphQL SDK PowerShell client.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="apiBaseUrl">The base URL for constructing the full API endpoint.</param>
        internal Sdk4mePowerShellClient(string personalAccessToken, string accountID, string apiBaseUrl)
        {
            client = new(new AuthenticationToken(personalAccessToken), accountID, apiBaseUrl);
        }

        /// <summary>
        /// Create a new instance of the 4me GraphQL SDK PowerShell client.
        /// </summary>
        /// <param name="clientId">The OAuht2 client id.</param>
        /// <param name="clientSecret">The OAuth2 client secret.</param>
        /// <param name="accountID">The 4me Account ID.</param>
        /// <param name="apiBaseUrl">The base URL for constructing the full API endpoint.</param>
        internal Sdk4mePowerShellClient(string clientId, string clientSecret, string accountID, string apiBaseUrl)
        {
            client = new(new AuthenticationToken(clientId, clientSecret), accountID, apiBaseUrl);
        }
    }
}
