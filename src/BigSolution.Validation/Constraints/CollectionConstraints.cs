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


namespace BigSolution
{
    public static class CollectionConstraints
    {
        public static IArgumentValidation<ICollection<T?>> ContainsSingle<T>(this IArgumentValidation<ICollection<T?>> argumentValidation)
        {
            return argumentValidation.Validate(
                collection => collection?.Any() ?? true,
                parameterName => new ArgumentException(Resources.CollectionConstraints.ContainsSingleErrorMessage, parameterName));
        }

        public static IArgumentValidation<ICollection<T?>> DoesNotContainNullElement<T>(this IArgumentValidation<ICollection<T?>> argumentValidation)
        {
            return argumentValidation.Validate(
                collection => collection == null || !collection.Any() || collection.Any(element => !Equals(element, null)),
                parameterName => new ArgumentException(Resources.CollectionConstraints.DoesNotContainNullElementErrorMessage, parameterName));
        }

        public static IArgumentValidation<ICollection<T?>> IsEmpty<T>(this IArgumentValidation<ICollection<T?>> argumentValidation)
        {
            return argumentValidation.Validate(
                collection => collection == null || collection.Count == 0,
                parameterName => new ArgumentException(Resources.CollectionConstraints.IsEmptyErrorMessage, parameterName));
        }

        public static IArgumentValidation<ICollection<T?>> IsNotEmpty<T>(this IArgumentValidation<ICollection<T?>> argumentValidation)
        {
            return argumentValidation.Validate(
                collection => collection == null || collection.Count > 0,
                parameterName => new ArgumentException(Resources.CollectionConstraints.IsNotEmptyErrorMessage, parameterName));
        }

        public static IArgumentValidation<ICollection<T?>> IsNotNullOrEmpty<T>(this IArgumentValidation<ICollection<T?>> argumentValidation)
        {
            return argumentValidation.Validate(
                collection => collection is { Count: > 0 },
                parameterName => new ArgumentException(Resources.CollectionConstraints.IsNotNullOrEmptyErrorMessage, parameterName));
        }
    }
}
