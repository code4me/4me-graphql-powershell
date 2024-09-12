using Sdk4me.GraphQL.PowerShell.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// Provides extension methods for PSCmdlet to enhance logging and tracing capabilities within PowerShell cmdlets.
    /// </summary>
    public static class PSCmdletExtensions
    {
        private static readonly PowerShellTraceListener traceListener = new();

        static PSCmdletExtensions()
        {
            Trace.Listeners.Add(traceListener);
        }

        /// <summary>
        /// Starts processing for a cmdlet and logs a start message.
        /// If verbose logging is enabled, it also sets up a trace listener to capture detailed execution logs.
        /// </summary>
        /// <param name="cmdlet">The instance of the cmdlet executing this method.</param>
        public static void StartProcessingHeader(this PSCmdlet cmdlet)
        {
            cmdlet.WriteVerbose($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fffK}] [{cmdlet.MyInvocation.MyCommand.Name}] Start");
        }

        /// <summary>
        /// Logs each bound parameter and its corresponding value to the verbose output, provided verbose mode is active.
        /// </summary>
        /// <param name="cmdlet">The cmdlet instance for which parameters are being logged.</param>
        public static void WriteParameters(this PSCmdlet cmdlet)
        {
            foreach (KeyValuePair<string, object> boundParameter in cmdlet.MyInvocation.BoundParameters)
            {
                if (cmdlet is NewClientCommand &&
                    (boundParameter.Key == nameof(NewClientCommand.PersonalAccessToken) ||
                     boundParameter.Key == nameof(NewClientCommand.ClientSecret)))
                {
                    cmdlet.WriteVerbose($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fffK}] [{cmdlet.MyInvocation.MyCommand.Name}] Parameter: {boundParameter.Key} | Value: ***");
                }
                else
                {
                    if (boundParameter.Value is Array array)
                    {
                        IEnumerable<object> elements = array.Cast<object>();
                        string?[] data = elements.Select(element =>
                        {
                            return element != null && element.GetType().IsEnum ? Enum.GetName(element.GetType(), element) : (element?.ToString());
                        }).ToArray();

                        cmdlet.WriteVerbose($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fffK}] [{cmdlet.MyInvocation.MyCommand.Name}] Parameter: {boundParameter.Key} | Value: [{string.Join(", ", data)}]");
                    }
                    else
                    {
                        cmdlet.WriteVerbose($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fffK}] [{cmdlet.MyInvocation.MyCommand.Name}] Parameter: {boundParameter.Key} | Value: {boundParameter.Value}");
                    }
                }
            }
        }

        /// <summary>
        /// Logs the end of a cmdlet's execution and manages the trace listener if verbose mode is enabled.
        /// </summary>
        /// <param name="cmdlet">The instance of the cmdlet executing this method.</param>
        public static void EndProcessingFooter(this PSCmdlet cmdlet)
        {
            cmdlet.WriteVerbose($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fffK}] [{cmdlet.MyInvocation.MyCommand.Name}] End");
        }
    }
}
