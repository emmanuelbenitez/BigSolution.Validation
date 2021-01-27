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
    public class TypeConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText", Justification = "Testing purpose")]
        public void IsInterfaceFailed()
        {
            Action act = () => Requires.Argument(typeof(object), "param")
                .IsInterface()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The type '*' is not an interface.*")
                .Which.ParamName.Should().Be("param");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(typeof(IArgumentValidation))]
        public void IsInterfaceSucceeds(Type type)
        {
            Action act = () => Requires.Argument(type, nameof(type))
                .IsInterface()
                .Check();

            act.Should().NotThrow();
        }
    }
}
