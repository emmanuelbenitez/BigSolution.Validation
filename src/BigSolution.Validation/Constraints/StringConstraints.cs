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
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace BigSolution
{
    public static class StringConstraints
    {
        public static IArgumentValidation<string> DoesNotMatch(
            this IArgumentValidation<string> argumentValidation,
            [RegexPattern] string pattern,
            RegexOptions options = RegexOptions.None)
        {
            Requires.Argument(pattern, nameof(pattern))
                .IsNotNullOrEmpty()
                .Check();

            return argumentValidation.DoesNotMatch(new Regex(pattern, options));
        }

        public static IArgumentValidation<string> DoesNotMatch(this IArgumentValidation<string> argumentValidation, Regex regularExpression)
        {
            Requires.Argument(regularExpression, nameof(regularExpression))
                .IsNotNull()
                .Check();

            return argumentValidation.Validate(
                value => !regularExpression.IsMatch(value),
                parameterName => new ArgumentException(
                    Resources.StringConstraints.DoesNotMatchErrorMessage(argumentValidation?.Value, regularExpression.ToString()),
                    parameterName));
        }

        public static IArgumentValidation<string> IsNotEmpty(this IArgumentValidation<string> argumentValidation)
        {
            return argumentValidation.Validate(
                value => value == null || value.Length > 0,
                parameterName => new ArgumentException(Resources.StringConstraints.IsNotEmptyErrorMessage, parameterName));
        }

        public static IArgumentValidation<string> IsNotNullOrEmpty(this IArgumentValidation<string> argumentValidation)
        {
            return argumentValidation.Validate(
                value => !string.IsNullOrEmpty(value),
                parameterName => new ArgumentException(Resources.StringConstraints.IsNotNullOrEmptyErrorMessage, parameterName));
        }

        public static IArgumentValidation<string> IsNotNullOrWhiteSpace(this IArgumentValidation<string> argumentValidation)
        {
            return argumentValidation.Validate(
                value => !string.IsNullOrWhiteSpace(value),
                parameterName => new ArgumentException(Resources.StringConstraints.IsNotNullOrWhiteSpaceErrorMessage, parameterName));
        }

        public static IArgumentValidation<string> Matches(
            this IArgumentValidation<string> argumentValidation,
            [RegexPattern] string pattern,
            RegexOptions options = RegexOptions.None)
        {
            Requires.Argument(pattern, nameof(pattern))
                .IsNotNullOrEmpty()
                .Check();

            return argumentValidation.Matches(new Regex(pattern, options));
        }

        public static IArgumentValidation<string> Matches(this IArgumentValidation<string> argumentValidation, Regex regularExpression)
        {
            Requires.Argument(regularExpression, nameof(regularExpression))
                .IsNotNull()
                .Check();

            return argumentValidation.Validate(
                value => value == null || regularExpression.IsMatch(value),
                parameterName => new ArgumentException(
                    Resources.StringConstraints.MatchesErrorMessage(argumentValidation?.Value, regularExpression.ToString()),
                    parameterName));
        }
    }
}
