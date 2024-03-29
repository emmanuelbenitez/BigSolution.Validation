﻿#region Copyright & License

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

namespace BigSolution;

public class ArgumentValidationFixture
{
    [SuppressMessage("ReSharper", "NotResolvedInText")]
    [Fact]
    public void AddExceptionSucceeds()
    {
        var argumentValidation = Requires.Argument(string.Empty, "param");
        var exception = new ArgumentException();

        argumentValidation.AddException(exception);

        argumentValidation.Exceptions.Should().BeEquivalentTo(new[] { exception });
    }

    [SuppressMessage("ReSharper", "NotResolvedInText")]
    [Fact]
    public void CheckThrowsAggregateArgumentException()
    {
        var act = () => Requires.Argument("value", "param")
            .IsNotEqualTo("value")
            .IsNotEqualTo("value")
            .Check();

        act.Should().ThrowExactly<AggregateArgumentException>().Which.Exceptions.Should().HaveCount(2);
    }
#pragma warning restore IDE0079 // Remove unnecessary suppression

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void CreationFailedForInvalidParameterName(string parameterName)
    {
        Action act = () => Requires.Argument(string.Empty, parameterName);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The value is null or empty.*");
    }
}