#region Copyright & License

// Copyright © 2020 - 2020 Emmanuel Benitez
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
    public static class NullableComparisonConstraints
    {
        public static IArgumentValidation<T?> IsEqualTo<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsEqualTo(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }

        public static IArgumentValidation<T?> IsGreaterOrEqualThan<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsGreaterOrEqualThan(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }

        public static IArgumentValidation<T?> IsGreaterThan<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsGreaterThan(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }

        public static IArgumentValidation<T?> IsLessOrEqualThan<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsLessOrEqualThan(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }

        public static IArgumentValidation<T?> IsLessThan<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsLessThan(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }

        public static IArgumentValidation<T?> IsNotEqualTo<T>(this IArgumentValidation<T?> argumentValidation, T valueToCompare)
            where T : struct, IComparable<T>
        {
            if (argumentValidation?.Value != null) argumentValidation.IsNotEqualTo(argumentValidation.Value.Value, valueToCompare);
            return argumentValidation;
        }
    }
}
