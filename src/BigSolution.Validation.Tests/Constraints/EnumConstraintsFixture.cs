﻿#region Copyright & License

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
    public class EnumConstraintsFixture
    {
        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsFlagFailed()
        {
            Action act = () => Requires.Argument(Enum.None, "param")
                .IsFlag()
                .Check();

            act.Should().ThrowExactly<ArgumentException>()
                .WithMessage($"The enum 'BigSolution.EnumConstraintsFixture+Enum' is not a flag. (Parameter 'param')")
                .Which.ParamName.Should().Be("param");
        }

        [Fact]
        [SuppressMessage("ReSharper", "NotResolvedInText")]
        public void IsFlagSucceeds()
        {
            Action act = () => Requires.Argument(FlagEnum.None, "param")
                .IsFlag()
                .Check();

            act.Should().NotThrow();
        }

        [Flags]
        private enum FlagEnum
        {
            None
        }

        private enum Enum
        {
            None
        }
    }
}
