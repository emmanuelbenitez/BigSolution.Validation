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
    public class StringConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void DoesMatchesSucceeds()
        {
            Action act = () => Requires.Argument("ABC", "param")
                .DoesNotMatch(@"\d{3}")
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void DoesNotMatchFailed()
        {
            Action act = () => Requires.Argument("123", "param")
                .DoesNotMatch(@"\d{3}")
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage(@"The value '123' must not match '\d{3}'. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEmptyFailed()
        {
            Action act = () => Requires.Argument(string.Empty, "param")
                .IsNotEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value is empty. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEmptySucceeds()
        {
            Action act = () => Requires.Argument("this is a text", "param")
                .IsNotEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsNotNullOrEmptyFailed(string param)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsNotNullOrEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value is null or empty. (Parameter '{nameof(param)}')")
                .Which.ParamName.Should().Be(nameof(param));
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotNullOrEmptySucceeds()
        {
            Action act = () => Requires.Argument("this is a text", "param")
                .IsNotNullOrEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void MatchesFailed()
        {
            Action act = () => Requires.Argument("ABC", "param")
                .Matches(@"\d{3}")
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage(@"The value 'ABC' must match '\d{3}'. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void MatchesSucceeds()
        {
            Action act = () => Requires.Argument("123", "param")
                .Matches(@"\d{3}")
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void IsNotNullOrWhiteSpaceFailed(string value)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .IsNotNullOrWhiteSpace()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value is null or empty or contains only white spaces. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotNullOrWhiteSpaceSucceeds()
        {
            Action act = () => Requires.Argument("value", "param")
                .IsNotNullOrWhiteSpace()
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }

    }
}
