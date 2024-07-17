using System;

namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// Represents a filter for querying data based on a specified property, operator, and value(s) of type <typeparamref name="T"/>.
    /// The filter can handle different types of data including strings, dates, and booleans.
    /// </summary>
    /// <typeparam name="T">The type of the entity being filtered. Must be a class.</typeparam>
    public sealed class QueryFilter<T> where T : class
    {
        /// <summary>
        /// Gets or sets the property name to which the filter is applied.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the operator used for filtering.
        /// </summary>
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the array of string values used for string filtering.
        /// </summary>
        public string?[]? StringValues { get; set; }

        /// <summary>
        /// Gets or sets the array of DateTime values used for date filtering.
        /// </summary>
        public DateTime?[]? DateTimeValues { get; set; }

        /// <summary>
        /// Gets or sets the boolean value used for boolean filtering.
        /// </summary>
        public bool? BooleanValue { get; set; }

        /// <summary>
        /// Gets the type of the filter, which corresponds to the type of the entity being filtered.
        /// </summary>
        public Type FilterType { get; }

        /// <summary>
        /// Initializes a new instance of the QueryFilter class, specifying the property and operator for the filter.
        /// </summary>
        /// <param name="property">The name of the property to filter on.</param>
        /// <param name="operator">The operator that defines the comparison to be used in the filter.</param>
        public QueryFilter(string property, FilterOperator @operator)
        {
            Property = property;
            Operator = @operator;
            FilterType = typeof(T);
        }

        /// <summary>
        /// Validates the configuration of the filter based on the type of values provided and the specified operator.
        /// Outputs an error message if the configuration is invalid.
        /// </summary>
        /// <param name="errorMessage">Outputs an error message describing why the filter configuration is invalid, if applicable.</param>
        /// <returns>True if the filter configuration is valid; otherwise false.</returns>
        public bool IsValid(out string? errorMessage)
        {
            errorMessage = null;

            if (StringValues != null)
            {
                if (Operator.IsCommonOperator())
                    return true;

                errorMessage = $"Unsupported {nameof(String)} filter operator, use Present, Empty, Equals, NotEquals, In, NotIn.";
                return false;
            }
            else if (DateTimeValues != null)
            {
                if (Operator.IsCommonOperator() || (Operator.IsDateTimeSingleValueOperator() && DateTimeValues.Length == 1) || (Operator.IsDateTimeRangeOperator() && DateTimeValues.Length == 2))
                    return true;

                errorMessage = $"Unsupported {nameof(DateTime)} filter operator, use Equals, NotEquals, In, NotIn with one or multiple values, LessThan, LessThanOrEqualsTo, GreaterThan, GreaterThanOrEqualsTo with a single value, GreaterThanAndLessThan, GreaterThanOrEqualToAndLessThanOrEqualTo with two values.";
                return false;
            }
            else if (BooleanValue.HasValue)
            {
                if (Operator.IsCommonOperator())
                    return true;

                errorMessage = $"Unsupported {nameof(Boolean)} filter operator, use Equals, NotEquals, In, or NotIn.";
                return false;
            }
            else if (Operator.IsNullableOperator())
            {
                return true;
            }

            errorMessage = "Unsupported filter, use the filter operator Present or Empty or provide StringValues, DateTimeValues or BooleanValue.";
            return false;
        }
    }
}
