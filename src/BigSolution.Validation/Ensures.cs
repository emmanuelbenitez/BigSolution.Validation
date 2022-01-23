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

using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace BigSolution
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Ensures
    {
        [AssertionMethod]
        public static void IsValid(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string errorMessage)
        {
            if (!condition) throw new InvalidOperationException(errorMessage);
        }

        [AssertionMethod]
        public static void IsValid<TException>(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition)
            where TException : Exception, new()
        {
            if (!condition) throw new TException();
        }

        [AssertionMethod]
        public static void NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T value,
            string errorMessage)
        {
            if (value == null) throw new InvalidOperationException(errorMessage);
        }
    }
}
