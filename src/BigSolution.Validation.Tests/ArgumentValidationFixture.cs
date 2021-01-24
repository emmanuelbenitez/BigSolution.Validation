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

using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class ArgumentValidationFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void AddExceptionFailed()
        {
            Action act = () => Requires.Argument((object) null, "param").AddException(null);

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("exception");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void AddExceptionSucceeds()
        {
            var argumentValidation = Requires.Argument((object) null, "param");
            var exception = new ArgumentException();

            argumentValidation.AddException(exception);

            argumentValidation.Exceptions.Should().BeEquivalentTo(exception);
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void CheckThrowsAggregateArgumentException()
        {
            Action act = () => Requires.Argument("value", "param")
                .IsNotEqualTo("value")
                .IsNotEqualTo("value")
                .Check();

            act.Should().ThrowExactly<AggregateArgumentException>().Which.Exceptions.Should().HaveCount(2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreationFailedForInvalidParameterName(string parameterName)
        {
            Action act = () => Requires.Argument((object) null, parameterName);

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value is null or empty. (Parameter 'name')");
        }
    }
}
