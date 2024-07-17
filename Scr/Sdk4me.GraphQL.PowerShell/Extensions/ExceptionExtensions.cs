using System;
using System.Management.Automation;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// Provides extension methods for the <see cref="Exception"/> class to handle terminating errors in PowerShell cmdlets.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Throws the specified exception as a terminating error in the given <see cref="PSCmdlet"/>.
        /// </summary>
        /// <param name="exception">The exception to be thrown as a terminating error.</param>
        /// <param name="cmdlet">The cmdlet in which the error occurred.</param>
        /// <param name="errorId">A unique identifier for the error.</param>
        /// <param name="errorCategory">The category of the error.</param>
        /// <param name="targetObject">The target object related to the error. This parameter is optional.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="exception"/> or <paramref name="cmdlet"/> is null.</exception>
        public static void ThrowAsTerminatingError(this Exception exception, PSCmdlet cmdlet, string errorId, ErrorCategory errorCategory, object? targetObject = null)
        {
            cmdlet.ThrowTerminatingError(new ErrorRecord(exception, errorId, errorCategory, targetObject));
        }
    }
}
