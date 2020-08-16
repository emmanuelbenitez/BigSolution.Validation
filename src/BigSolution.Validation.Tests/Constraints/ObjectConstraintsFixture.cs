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
    public class ObjectConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotNullFailed()
        {
            Action act = () => Requires.Argument((object) null, "param")
                .IsNotNull()
                .Check();

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotNullFailedForNullable()
        {
            Action act = () => Requires.Argument((int?) null, "param")
                .IsNotNull()
                .Check();

            act.Should().ThrowExactly<ArgumentNullException>().Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void NotNullSucceeds()
        {
            Action act = () => Requires.Argument(new object(), "param")
                .IsNotNull()
                .Check();

            act.Should().NotThrow();
        }
    }
}
