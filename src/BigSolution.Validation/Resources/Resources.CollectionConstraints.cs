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

namespace BigSolution
{
    internal static partial class Resources
    {
        #region Nested Type: CollectionConstraints

        public static class CollectionConstraints
        {
            public static string ContainsSingleErrorMessage => GetString($"{nameof(CollectionConstraints)}_{nameof(ContainsSingleErrorMessage)}");

            public static string DoesNotContainNullElementErrorMessage => GetString($"{nameof(CollectionConstraints)}_{nameof(DoesNotContainNullElementErrorMessage)}");

            public static string IsEmptyErrorMessage => GetString($"{nameof(CollectionConstraints)}_{nameof(IsEmptyErrorMessage)}");

            public static string IsNotEmptyErrorMessage => GetString($"{nameof(CollectionConstraints)}_{nameof(IsNotEmptyErrorMessage)}");

            public static string IsNotNullOrEmptyErrorMessage => GetString($"{nameof(CollectionConstraints)}_{nameof(IsNotNullOrEmptyErrorMessage)}");
        }

        #endregion
    }
}
