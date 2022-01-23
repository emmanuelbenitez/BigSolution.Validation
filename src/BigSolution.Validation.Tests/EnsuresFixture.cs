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

using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class EnsuresFixture
    {
        [Fact]
        public void NotNullSucceedsWhitNotNullValue()
        {
            var action = () => Ensures.NotNull(string.Empty, "The value is null");
            action.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void NotNullSucceedsWhitNullValue()
        {
            var action = () => Ensures.NotNull((string?)null, "The value is null");
            action.Should().ThrowExactly<InvalidOperationException>().WithMessage("The value is null");
        }

        [Fact]
        public void ValidGenericSucceedsWhenConditionIsFalse()
        {
            var action = () => Ensures.IsValid<Exception>(false);
            action.Should().ThrowExactly<Exception>();
        }

        [Fact]
        public void ValidGenericSucceedsWhenConditionIsTrue()
        {
            var action = () => Ensures.IsValid<Exception>(true);
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void ValidSucceedsWhenConditionIsFalse()
        {
            var action = () => Ensures.IsValid(false, "It is an error");
            action.Should().ThrowExactly<InvalidOperationException>().WithMessage("It is an error");
        }

        [Fact]
        public void ValidSucceedsWhenConditionIsTrue()
        {
            var action = () => Ensures.IsValid(true, string.Empty);
            action.Should().NotThrow<InvalidOperationException>();
        }
    }
}
