#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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

namespace BigSolution;

internal static partial class Resources
{
    #region Nested Type: ComparisonConstraints

    public static class ComparisonConstraints
    {
        public static string IsEqualToErrorMessage(object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsEqualToErrorMessage)}", null, valueToCompare);
        }

        public static string IsGreaterOrEqualThanErrorMessage(object? value, object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsGreaterOrEqualThanErrorMessage)}", null, value, valueToCompare);
        }

        public static string IsGreaterThanErrorMessage(object? value, object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsGreaterThanErrorMessage)}", null, value, valueToCompare);
        }

        public static string IsLessOrEqualThanErrorMessage(object? value, object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsLessOrEqualThanErrorMessage)}", null, value, valueToCompare);
        }

        public static string IsLessThanErrorMessage(object? value, object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsLessThanErrorMessage)}", null, value, valueToCompare);
        }

        public static string IsNotEqualToErrorMessage(object? valueToCompare)
        {
            return GetFormattedString($"{nameof(ComparisonConstraints)}_{nameof(IsNotEqualToErrorMessage)}", null, valueToCompare);
        }
    }

    #endregion
}