using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace BigSolution
{
    public static class Requires
    {
        [AssertionMethod]
        public static void GreaterOrEqualThan<T>(T value, T valueToCompare, [InvokerParameterName] string name)
            where T : IComparable<T>
        {
            if (value == null) return;

            if (value.CompareTo(valueToCompare) < 0)
                throw new ArgumentException($"The value '{value}' must greater than '{valueToCompare}'", name);
        }

        [AssertionMethod]
        public static void IsValid(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string name,
            string message)
        {
            if (!condition) throw new ArgumentException(message, name);
        }

        [AssertionMethod]
        public static void NotEmpty(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            string value,
            [InvokerParameterName] string name)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("The string is null or empty", name);
        }

        [AssertionMethod]
        public static void NotEmpty<T>(ICollection<T> value, [InvokerParameterName] string name)
        {
            if (value?.Count == 0) throw new ArgumentException("The collection is empty", name);
        }

        [AssertionMethod]
        public static void NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T value,
            [InvokerParameterName] string name)
        {
            if (value == null) throw new ArgumentNullException(name);
        }

        [AssertionMethod]
        public static void NotNullElement<T>(ICollection<T> value, [InvokerParameterName] string name)
        {
            if (value?.Any(x => x == null) ?? false)
                throw new ArgumentException("The collection contains null element", name);
        }

        [AssertionMethod]
        public static void GreaterThan<T>(T value, T valueToCompare, [InvokerParameterName] string name)
            where T : IComparable<T>
        {
            if (value == null) return; 

            if (value.CompareTo(valueToCompare) <= 0)
                throw new ArgumentException($"The value '{value}' must greater than '{valueToCompare}'", name);
        }

        [AssertionMethod]
        public static void GreaterThan<T>(T? value, T? valueToCompare, [InvokerParameterName] string name)
            where T : struct, IComparable
        {
            if (!value.HasValue || !valueToCompare.HasValue) return;

            if (value.Value.CompareTo(valueToCompare) <= 0)
                throw new ArgumentException($"The value '{value}' must greater than '{valueToCompare}'", name);
        }

        [AssertionMethod]
        public static void HasValidFormat(
            string value,
            [RegexPattern] string pattern,
            [InvokerParameterName] string name,
            string message)
        {
            NotEmpty(pattern, nameof(pattern));

            if (value != null && !Regex.IsMatch(value, pattern)) throw new ArgumentException(message, name);
        }
    }
}
