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
    public class CollectionConstraintsFixture
    {
        [SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Testing purpose")]
        [SuppressMessage("ReSharper", "NotResolvedInText", Justification = "Testing purpose")]
        [Fact]
        public void ContainsSingleFailed()
        {
            var act = () => Requires.Argument(Array.Empty<object?>(), "param")!
                .ContainsSingle()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection must contain only one element.*")
                .And.ParamName.Should().Be("param");
        }

        [Theory]
        [MemberData(nameof(NullOrSingleElementCollections))]
        public void ContainsSingleSucceeds(object?[] param)
        {
            var act = () => Requires.Argument(param, nameof(param))!
                .ContainsSingle()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void DoesNotContainNullElementFailed()
        {
            var act = () => Requires.Argument(new object?[] { null }, "param")!
                .DoesNotContainNullElement()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection contains at least one null element.*")
                .Which.ParamName.Should().Be("param");
        }

        [Theory]
        [MemberData(nameof(NullOrSingleElementCollections))]
        [MemberData(nameof(NullOrEmptyCollections))]
        public void DoesNotContainNullElementSucceeds(object[]? value)
        {
            var act = () => Requires.Argument(value, nameof(value))!
                .DoesNotContainNullElement()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void EmptyFailed()
        {
            var act = () => Requires.Argument(new List<object> { new() }, "param")!
                .IsEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is not empty.*")
                .And.ParamName.Should().Be("param");
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void EmptySucceeds()
        {
            var act = () => Requires.Argument(new List<object>(), "param")!
                .IsEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void NotEmptyFailed()
        {
            var act = () => Requires.Argument(new List<object>(), "param")!
                .IsNotEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is empty.*")
                .And.ParamName.Should().Be("param");
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void NotEmptySucceeds()
        {
            var act = () => Requires.Argument(new List<object> { new() }, "param")!
                .IsNotEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void NotEmptySucceedsWhenCollectionIsNull()
        {
            var act = () => Requires.Argument((ICollection<object>?)null, "param")!
                .IsNotEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(NullOrEmptyCollections))]
        public void NotNullOrEmptyFailed(object[] param)
        {
            var act = () => Requires.Argument(param, nameof(param))!
                .IsNotNullOrEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is null or empty.*")
                .And.ParamName.Should().Be(nameof(param));
        }

        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [Fact]
        public void NotNullOrEmptySucceeds()
        {
            var act = () => Requires.Argument(new List<object> { new() }, "param")!
                .IsNotNullOrEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Testing purpose")]
        public static IEnumerable<object[]> NullOrEmptyCollections
        {
            get { yield return new object[] { Array.Empty<object>() }; }
        }

        public static IEnumerable<object[]> NullOrSingleElementCollections
        {
            get { yield return new object[] { new[] { new object() } }; }
        }
    }
}
