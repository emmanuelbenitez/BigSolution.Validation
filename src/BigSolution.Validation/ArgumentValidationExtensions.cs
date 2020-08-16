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
using System.Linq;

namespace BigSolution
{
    public static class ArgumentValidationExtensions
    {
        public static void Check<T>(this IArgumentValidation<T> argumentValidation)
        {
            if (argumentValidation == null) return;

            var exceptions = argumentValidation.Exceptions;

            switch (exceptions.Count)
            {
                case 0:
                    return;
                case 1:
                    throw exceptions.Single();
                default:
                    throw new AggregateArgumentException(Resources.AggregateArgumentException.DefaultErrorMessage, argumentValidation.Name, exceptions);
            }
        }

        internal static T GetValueOrDefault<T>(this IArgumentValidation<T> argumentValidation)
        {
            return argumentValidation == null ? default : argumentValidation.Value;
        }

        internal static IArgumentValidation<T> Validate<T>(
            this IArgumentValidation<T> argumentValidation,
            Func<T, bool> condition,
            Func<string, ArgumentException> exceptionFactory)
        {
            if (argumentValidation != null && !condition(argumentValidation.Value)) argumentValidation.AddException(exceptionFactory(argumentValidation.Name));

            return argumentValidation;
        }

        internal static void Validate(
            this IArgumentValidation argumentValidation,
            Func<bool> condition,
            Func<string, ArgumentException> exceptionFactory)
        {
            if (argumentValidation != null && !condition()) argumentValidation.AddException(exceptionFactory(argumentValidation.Name));
        }
    }
}
