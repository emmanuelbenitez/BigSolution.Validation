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
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class StringConstraintsFixture
    {
        [Theory]
        [InlineData(null)]
        [InlineData("ABC")]
        public void DoesMatchesSucceeds(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .DoesNotMatch(@"\d{3}")
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData("123")]
        public void DoesNotMatchFailed(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .DoesNotMatch(@"\d{3}")
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage(@"The value '*' must not match '\d{3}'.*")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("ABC")]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void MatchesFailed(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .Matches(@"\d{3}")
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage(@"The value 'ABC' must match '\d{3}'.*")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [InlineData("123")]
        [InlineData(null)]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void MatchesSucceeds(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .Matches(@"\d{3}")
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotEmptyFailed()
        {
            var act = () => Requires.Argument(string.Empty, "param")
                .IsNotEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value is empty.*")
                .Which.ParamName.Should().Be("param");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("value")]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotEmptySucceeds(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .IsNotEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotNullOrEmptyFailed(string? param)
        {
            var act = () => Requires.Argument(param, nameof(param))
                .IsNotNullOrEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value is null or empty.*")
                .Which.ParamName.Should().Be(nameof(param));
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotNullOrEmptySucceeds()
        {
            var act = () => Requires.Argument("this is a text", "param")
                .IsNotNullOrEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void NotNullOrWhiteSpaceFailed(string? value)
        {
            var act = () => Requires.Argument(value, nameof(value))
                .IsNotNullOrWhiteSpace()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value is null or empty or contains only white spaces.*")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotNullOrWhiteSpaceSucceeds()
        {
            var act = () => Requires.Argument("value", "param")
                .IsNotNullOrWhiteSpace()
                .Check();
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
