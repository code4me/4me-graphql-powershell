using System.Runtime.Serialization;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// The export data formats.
    /// </summary>
    public enum DataExportFormat
    {
        /// <summary>
        /// Export as CSV.
        /// </summary>
        [EnumMember(Value = "csv")]
        CSV,
        /// <summary>
        /// Export as Excel.
        /// </summary>
        [EnumMember(Value = "xlsx")]
        Excel
    }
}
