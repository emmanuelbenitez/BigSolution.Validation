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
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class NullableComparisonConstraintsFixture
    {
        [Theory]
        [InlineData(0, 1)]
        public void IsEqualToFailed(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsEqualTo(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value must be equal to '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(null, 1)]
        public void IsEqualToSucceeds(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsEqualTo(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(0, 1)]
        public void IsGreaterOrEqualThanFailed(int? param, int valueToCompare)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsGreaterOrEqualThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be greater or equal than '*'. (Parameter '{nameof(param)}')");
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void IsGreaterOrEqualThanSucceeds(int? param, int valueToCompare)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsGreaterOrEqualThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(0, 1)]
        public void IsGreaterThanFailed(int? param, int valueToCompare)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsGreaterThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be greater than '*'. (Parameter '{nameof(param)}')");
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(1, 0)]
        public void IsGreaterThanSucceeds(int? param, int valueToCompare)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsGreaterThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(1, 0)]
        public void IsLessOrEqualThanFailed(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessOrEqualThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be less or equal than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        public void IsLessOrEqualThanSucceeds(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessOrEqualThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void IsLessThanFailed(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessThan(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value '*' must be less than '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData(0, 1)]
        public void IsLessThanSucceeds(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsLessThan(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(1, 1)]
        public void IsNotEqualToFailed(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsNotEqualTo(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value must not be equal to '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(1, 0)]
        public void IsNotEqualToSucceeds(int? value, int valueToCompare)
        {
            Action act = () => Requires.Argument(1, nameof(value))
                .IsNotEqualTo(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }
    }
}
