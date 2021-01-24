#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;

namespace BigSolution
{
    public static class ComparisonConstraints
    {
        public static IArgumentValidation<T> IsEqualTo<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsEqualTo(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsEqualTo<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result == 0,
                Resources.ComparisonConstraints.IsEqualToErrorMessage(valueToCompare));
        }

        public static IArgumentValidation<T> IsGreaterOrEqualThan<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsGreaterOrEqualThan(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsGreaterOrEqualThan<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result >= 0,
                Resources.ComparisonConstraints.IsGreaterOrEqualThanErrorMessage(value, valueToCompare));
        }

        public static IArgumentValidation<T> IsGreaterThan<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsGreaterThan(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsGreaterThan<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result > 0,
                Resources.ComparisonConstraints.IsGreaterThanErrorMessage(value, valueToCompare));
        }

        public static IArgumentValidation<T> IsLessOrEqualThan<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsLessOrEqualThan(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsLessOrEqualThan<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result <= 0,
                Resources.ComparisonConstraints.IsLessOrEqualThanErrorMessage(value, valueToCompare));
        }

        public static IArgumentValidation<T> IsLessThan<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsLessThan(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsLessThan<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result < 0,
                Resources.ComparisonConstraints.IsLessThanErrorMessage(value, valueToCompare));
        }

        public static IArgumentValidation<T> IsNotEqualTo<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.IsNotEqualTo(argumentValidation.GetValueOrDefault(), valueToCompare);
            return argumentValidation;
        }

        internal static void IsNotEqualTo<T>(this IArgumentValidation argumentValidation, T value, T valueToCompare)
            where T : IComparable<T>
        {
            argumentValidation.ValidateComparison(
                value,
                valueToCompare,
                result => result != 0,
                Resources.ComparisonConstraints.IsNotEqualToErrorMessage(valueToCompare));
        }

        private static void ValidateComparison<T>(
            this IArgumentValidation argumentValidation,
            T value,
            T valueToCompare,
            Func<int?, bool> validateComparisonResult,
            string errorMessage)
            where T : IComparable<T>
        {
            argumentValidation.Validate(
                () => validateComparisonResult(value?.CompareTo(valueToCompare)),
                paramName => new ArgumentException(errorMessage, paramName));
        }
    }
}
