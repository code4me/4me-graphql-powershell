using System.Collections.Generic;
using System.Linq;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// Manages instances of <see cref="Sdk4mePowerShellClientManager"/> allowing for easy access and lifecycle management of multiple clients.
    /// </summary>
    internal class Sdk4mePowerShellClientManager
    {
        private readonly static List<Sdk4mePowerShellClient> clients = new();

        /// <summary>
        /// Adds a <see cref="Sdk4mePowerShellClient"/> to the managed list of clients.
        /// </summary>
        /// <param name="client">The <see cref="Sdk4mePowerShellClient"/> to add to the management list.</param>
        public static void AddClient(Sdk4mePowerShellClient client)
        {
            clients.Add(client);
        }

        /// <summary>
        /// Retrieves the first <see cref="Sdk4mePowerShellClient"/> from the managed list of clients.
        /// </summary>
        /// <returns>The first <see cref="Sdk4mePowerShellClient"/> instance from the managed list.</returns>
        /// <exception cref="Sdk4meException">Thrown when there are no clients in the managed list.</exception>
        public static Sdk4mePowerShellClient GetClient()
        {
            if (clients.Count == 0)
                throw new Sdk4meException("No active connection to a 4me instance detected. Please establish a connection using New-4meConnection before proceeding.");
            return clients.First();
        }
    }
}
