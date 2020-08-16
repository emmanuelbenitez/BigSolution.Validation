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
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class ComparisonConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsEqualToFailed()
        {
            Action act = () => Requires.Argument(1, "param")
                .IsEqualTo(0)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value must be equal to '0'. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsEqualToSucceeds()
        {
            Action act = () => Requires.Argument(1, "param")
                .IsEqualTo(1)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("a", "z")]
        public void IsGreaterOrEqualThanFailed(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsGreaterOrEqualThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be greater or equal than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("z", "a")]
        [InlineData("z", "z")]
        [InlineData("z", null)]
        public void IsGreaterOrEqualThanSucceeds(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsGreaterOrEqualThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("a", "z")]
        [InlineData("z", "z")]
        public void IsGreaterThanFailed(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsGreaterThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be greater than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("z", "a")]
        [InlineData("z", null)]
        public void IsGreaterThanSucceeds(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsGreaterThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("z", "a")]
        [InlineData("z", null)]
        public void IsLessOrEqualThanFailed(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessOrEqualThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be less or equal than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("a", "z")]
        [InlineData("z", "z")]
        public void IsLessOrEqualThanSucceeds(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessOrEqualThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("z", "a")]
        [InlineData("z", "z")]
        [InlineData("z", null)]
        public void IsLessThanFailed(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be less than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("a", "z")]
        public void IsLessThanSucceeds(string value, string valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEqualToFailed()
        {
            Action act = () => Requires.Argument(1, "param")
                .IsNotEqualTo(1)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value must not be equal to '1'. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEqualToSucceeds()
        {
            Action act = () => Requires.Argument(1, "param")
                .IsNotEqualTo(0)
                .Check();

            act.Should().NotThrow();
        }
    }
}
