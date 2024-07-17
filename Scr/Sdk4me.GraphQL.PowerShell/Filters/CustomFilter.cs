namespace Sdk4me.GraphQL.PowerShell
{
    /// <summary>
    /// Represents a customizable filter for data operations, supporting various filter operations based on specified field names, operations, and values.
    /// </summary>
    public sealed class CustomFilter
    {
        /// <summary>
        /// Gets the name of the filter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the operator used in the filter.
        /// </summary>
        public FilterOperator Operator { get; set; }

        /// <summary>
        /// Gets the array of values that are used with the operator to determine if an element matches the filter.
        /// </summary>
        public string?[]? Values { get; set; }

        /// <summary>
        /// Initializes a new instance of the CustomFilter class with specified parameters for name, 
        /// operator, and filter values.
        /// </summary>
        /// <param name="name">The name of the filter, typically representing the attribute to filter on.</param>
        /// <param name="operator">The operator to apply in the filter.</param>
        /// <param name="values">The values used for filtering.</param>
        public CustomFilter(string name, FilterOperator @operator, string?[]? values)
        {
            Name = name;
            Operator = @operator;
            Values = values;
        }

        /// <summary>
        /// Validates the filter's configuration and determines whether it is set up correctly based on the
        /// specified operator and values. Provides an error message if the filter setup is incorrect.
        /// </summary>
        /// <param name="errorMessage">Outputs an error message describing the validation failure, if any.</param>
        /// <returns>True if the filter is valid; otherwise, false.</returns>
        public bool IsValid(out string? errorMessage)
        {
            errorMessage = null;

            if (Operator.IsNullableOperator())
            {
                return true;
            }
            else if (Operator.IsCommonOperator())
            {
                if (Values == null || Values.Length == 0)
                {
                    errorMessage = $"Unsupported custom filter, at least one value is required for Equals, NotEquals, In, NotIn.";
                    return false;
                }
                return true;
            }

            errorMessage = "Unsupported custom filter operator, use Present, Empty, Equals, NotEquals, In, NotIn.";
            return false;
        }
    }
}
