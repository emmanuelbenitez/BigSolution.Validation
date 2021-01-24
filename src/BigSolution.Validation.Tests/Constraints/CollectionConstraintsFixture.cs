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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class CollectionConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        [SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Testing purpose")]
        public void ContainsSingleFailed()
        {
            Action act = () => Requires.Argument(new object[0], "param")
                .ContainsSingle()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The collection must contain only one element. (Parameter 'param')")
                .And.ParamName.Should().Be("param");
        }

        [Theory]
        [MemberData(nameof(NullOrSingleElementCollections))]
        public void ContainsSingleSucceeds(object[] param)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .ContainsSingle()
                .Check();

            act.Should().NotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void DoesNotContainNullElementFailed()
        {
            Action act = () => Requires.Argument(new object[] { null }, "param")
                .DoesNotContainNullElement()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection contains at least one null element. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Theory]
        [MemberData(nameof(NullOrSingleElementCollections))]
        [MemberData(nameof(NullOrEmptyCollections))]
        public void DoesNotContainNullElementSucceeds(object[] value)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .DoesNotContainNullElement()
                .Check();

            act.Should().NotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsEmptyFailed()
        {
            Action act = () => Requires.Argument(new List<object> { new object() }, "param")
                .IsEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is not empty. (Parameter 'param')")
                .And.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsEmptySucceeds()
        {
            Action act = () => Requires.Argument(new List<object>(), "param")
                .IsEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEmptyFailed()
        {
            Action act = () => Requires.Argument(new List<object>(), "param")
                .IsNotEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is empty. (Parameter 'param')")
                .And.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotEmptySucceeds()
        {
            Action act = () => Requires.Argument(new List<object> { new object() }, "param")
                .IsNotEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(NullOrEmptyCollections))]
        public void IsNotNullOrEmptyFailed(object[] param)
        {
            Action act = () => Requires.Argument(param, nameof(param))
                .IsNotNullOrEmpty()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The collection is null or empty. (Parameter '{nameof(param)}')")
                .And.ParamName.Should().Be(nameof(param));
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsNotNullOrEmptySucceeds()
        {
            Action act = () => Requires.Argument(new List<object> { new object() }, "param")
                .IsNotNullOrEmpty()
                .Check();

            act.Should().NotThrow();
        }

        [SuppressMessage("Performance", "CA1825:Avoid zero-length array allocations", Justification = "Testing purpose")]
        public static IEnumerable<object[]> NullOrEmptyCollections
        {
            get
            {
                yield return new object[] { null };
                yield return new object[] { new object[0] };
            }
        }

        public static IEnumerable<object[]> NullOrSingleElementCollections
        {
            get
            {
                yield return new object[] { null };
                yield return new object[] { new[] { new object() } };
            }
        }
    }
}
