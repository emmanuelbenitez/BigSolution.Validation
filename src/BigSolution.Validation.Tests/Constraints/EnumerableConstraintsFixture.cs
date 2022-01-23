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

namespace BigSolution;

public class EnumerableConstraintsFixture
{
    [SuppressMessage("ReSharper", "NotResolvedInText")]
    [Fact]
    public void NotEmptyFailed()
    {
        var act = () => Requires.Argument(Enumerable.Empty<object>(), "param")
            .IsNotEmpty()
            .Check();

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The enumerable is empty.*")
            .And.ParamName.Should().Be("param");
    }

    [SuppressMessage("ReSharper", "NotResolvedInText")]
    [Fact]
    public void NotEmptySucceeds()
    {
        var act = () => Requires.Argument((IEnumerable<object?>)new List<object?> { new() }, "param")
            .IsNotEmpty()
            .Check();

        act.Should().NotThrow();
    }

    [SuppressMessage("ReSharper", "NotResolvedInText")]
    [Fact]
    public void NotEmptySucceedsWhenNull()
    {
        var act = () => Requires.Argument((IEnumerable<object?>?)null, "param")
            .IsNotEmpty()
            .Check();

        act.Should().NotThrow();
    }
}
