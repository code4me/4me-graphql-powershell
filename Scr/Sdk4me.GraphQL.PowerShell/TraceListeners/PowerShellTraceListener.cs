using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// A custom trace listener for PowerShell that captures trace output and directs it to the verbose stream of the currently active PowerShell cmdlet.
    /// </summary>
    public class PowerShellTraceListener : TraceListener
    {
        private static readonly ConcurrentQueue<(PSCmdlet Cmdlet, DateTime EventTime, string Message)> messageQueue = new();
        private static readonly Stack<PSCmdlet> cmdletStack = new();

        /// <summary>
        /// Registers the cmdlet instance which is currently being processed.
        /// This method should be called when a cmdlet starts processing.
        /// </summary>
        public static void RegisterCmdlet(PSCmdlet cmdlet)
        {
            if (cmdlet.MyInvocation.BoundParameters.TryGetValue("Verbose", out object? value) && value is SwitchParameter verbose && verbose.IsPresent)
            {
                cmdletStack.Push(cmdlet);
            }
        }

        /// <summary>
        /// Unregisters the most recently registered cmdlet instance.
        /// This method should be called when a cmdlet completes its processing.
        /// </summary>
        public static void UnregisterCmdlet()
        {
            if (cmdletStack.Count > 0)
            {
                cmdletStack.Pop();
            }
            FlushMessages();
        }

        /// <summary>
        /// Writes a message to the trace listener's queue without appending a newline.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void Write(string? message)
        {
            if (cmdletStack.Count > 0 && message != null)
            {
                messageQueue.Enqueue((cmdletStack.Peek(), DateTime.Now, message));
            }
        }

        /// <summary>
        /// Writes a message to the trace listener's queue and appends a newline.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public override void WriteLine(string? message)
        {
            Write(message);
        }

        /// <summary>
        /// Flushes all queued messages to the verbose stream of their respective cmdlets.
        /// This method should be called at the end of cmdlet processing to ensure all messages are displayed.
        /// </summary>
        private static void FlushMessages()
        {
            while (messageQueue.TryDequeue(out (PSCmdlet Cmdlet, DateTime EventTime, string Message) messagePair))
            {
                messagePair.Cmdlet.WriteVerbose($"[{messagePair.EventTime:yyyy-MM-ddTHH:mm:ss.fffK}] [{messagePair.Cmdlet.MyInvocation.MyCommand.Name}] {messagePair.Message}");
            }
        }
    }
}
