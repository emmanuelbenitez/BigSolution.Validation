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
    public static class EqualityConstraints
    {
        public static IArgumentValidation<T> DoesNotEqualTo<T>(this IArgumentValidation<T> argumentValidation, IEquatable<T> valueToCompare)
            where T : IEquatable<T>
        {
            return argumentValidation.Validate(
                value => value == null || !value.Equals(valueToCompare),
                parameterName => new ArgumentException(Resources.ComparisonConstraints.IsNotEqualToErrorMessage(valueToCompare), parameterName));
        }

        public static IArgumentValidation<T> EqualsTo<T>(this IArgumentValidation<T> argumentValidation, T valueToCompare)
            where T : IEquatable<T>
        {
            return argumentValidation.Validate(
                value => value == null || value.Equals(valueToCompare),
                parameterName => new ArgumentException(Resources.ComparisonConstraints.IsEqualToErrorMessage(valueToCompare), parameterName));
        }
    }
}
