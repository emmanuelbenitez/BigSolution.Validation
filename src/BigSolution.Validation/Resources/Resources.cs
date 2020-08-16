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

using System.Globalization;
using System.Resources;

namespace BigSolution
{
    internal static partial class Resources
    {
        private static string GetFormattedString(string key, CultureInfo culture = null, params object[] arguments)
        {
            return string.Format(
                culture ?? CultureInfo.CurrentCulture,
                _resourceManager.GetString(key, culture ?? CultureInfo.CurrentCulture) ?? string.Empty,
                arguments);
        }

        private static string GetString(string key, CultureInfo culture = null)
        {
            return _resourceManager.GetString(key, culture ?? CultureInfo.CurrentCulture);
        }

        private static readonly ResourceManager _resourceManager = new ResourceManager("BigSolution.Properties.Resources", typeof(Resources).Assembly);
    }
}
