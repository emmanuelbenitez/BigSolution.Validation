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

using System.Diagnostics.CodeAnalysis;

namespace BigSolution
{
    internal static partial class Resources
    {
        #region Nested Type: StringConstraints

        public static class StringConstraints
        {
            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Resource")]
            public static string IsNotEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotEmptyErrorMessage)}");

            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Resource")]
            public static string IsNotNullOrEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrEmptyErrorMessage)}");

            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Resource")]
            public static string IsNotNullOrWhiteSpaceErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrWhiteSpaceErrorMessage)}");

            public static string DoesNotMatchErrorMessage(string value, string pattern)
            {
                return GetFormattedString($"{nameof(StringConstraints)}_{nameof(DoesNotMatchErrorMessage)}", null, value, pattern);
            }

            public static string MatchesErrorMessage(string value, string pattern)
            {
                return GetFormattedString($"{nameof(StringConstraints)}_{nameof(MatchesErrorMessage)}", null, value, pattern);
            }
#pragma warning disable IDE0079 // Remove unnecessary suppression
            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Error message generation")]
            public static string IsNotEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotEmptyErrorMessage)}");

            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Error message generation")]
            public static string IsNotNullOrEmptyErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrEmptyErrorMessage)}");

            [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Error message generation")]
            public static string IsNotNullOrWhiteSpaceErrorMessage => GetString($"{nameof(StringConstraints)}_{nameof(IsNotNullOrWhiteSpaceErrorMessage)}");
#pragma warning restore IDE0079 // Remove unnecessary suppression
        }

        #endregion
    }
}
