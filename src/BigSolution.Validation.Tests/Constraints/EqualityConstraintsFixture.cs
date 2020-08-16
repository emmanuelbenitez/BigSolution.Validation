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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class EqualityConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void DoesNotEqualToFailed()
        {
            Action act = () => Requires.Argument(new EquatableObject(0), "param")
                .DoesNotEqualTo(new EquatableObject(0))
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value must not be equal to '*'. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Theory]
        [MemberData(nameof(InvalidObjectEqualities))]
        public void DoesNotEqualToSucceeds(EquatableObject value, EquatableObject valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .DoesNotEqualTo(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        [Theory]
        [MemberData(nameof(InvalidObjectEqualities))]
        public void EqualsToFailed(EquatableObject value, EquatableObject valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .EqualsTo(valueToCompare)
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The value must be equal to '*'. (Parameter '{nameof(value)}')")
                .Which.ParamName.Should().Be(nameof(value));
        }

        [Theory]
        [MemberData(nameof(ValidObjectEqualities))]
        public void EqualsToSucceeds(EquatableObject value, EquatableObject valueToCompare)
        {
            Action act = () => Requires.Argument(value, nameof(value))
                .EqualsTo(valueToCompare)
                .Check();

            act.Should().NotThrow();
        }

        public static IEnumerable<object[]> InvalidObjectEqualities
        {
            get
            {
                yield return new object[] { null, new EquatableObject(0) };
                yield return new object[] { new EquatableObject(0), null };
                yield return new object[] { new EquatableObject(0), new EquatableObject(1) };
            }
        }

        public static IEnumerable<object[]> ValidObjectEqualities
        {
            get
            {
                yield return new object[] { new EquatableObject(0), new EquatableObject(0) };
                yield return new object[] { null, null };
            }
        }

        public sealed class EquatableObject : IEquatable<EquatableObject>
        {
            public EquatableObject(int id)
            {
                Id = id;
            }

            #region IEquatable<EquatableObject> Members

            public bool Equals(EquatableObject other)
            {
                return Id == other?.Id;
            }

            #endregion

            #region Base Class Member Overrides

            public override bool Equals(object obj)
            {
                return ReferenceEquals(this, obj) || obj is EquatableObject other && Equals(other);
            }

            public override int GetHashCode() => Id.GetHashCode();

            #endregion

            [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
            public int Id { get; }
        }
    }
}
