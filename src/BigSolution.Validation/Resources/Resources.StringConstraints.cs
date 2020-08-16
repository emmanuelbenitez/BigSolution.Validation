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
        #region Nested Type: StringConstraints

        public static class StringConstraints
        {
            public static string IsNotEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotEmptyErrorMessage)}");

            public static string IsNotNullOrEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrEmptyErrorMessage)}");

            public static string IsNotNullOrWhiteSpaceErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrWhiteSpaceErrorMessage)}");

            public static string DoesNotMatchErrorMessage(string value, string pattern)
            {
                return GetFormattedString($"{nameof(StringConstraints)}_{nameof(DoesNotMatchErrorMessage)}", null, value, pattern);
            }

            public static string MatchesErrorMessage(string value, string pattern)
            {
                return GetFormattedString($"{nameof(StringConstraints)}_{nameof(MatchesErrorMessage)}", null, value, pattern);
            }
        }

        #endregion
    }
}
