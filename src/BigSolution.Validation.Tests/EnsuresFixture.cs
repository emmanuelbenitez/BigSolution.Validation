using System;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class EnsuresFixture
    {
        [Fact]
        public void IsValidGenericSucceedsWhenConditionIsTrue()
        {
            Action action = () => Ensures.IsValid<InvalidOperationException>(true);
            action.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void IsValidGenericSucceedsWhenConditionIsFalse()
        {
            Action action = () => Ensures.IsValid<InvalidOperationException>(false);
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void IsValidSucceedsWhenConditionIsTrue()
        {
            Action action = () => Ensures.IsValid(true, string.Empty);
            action.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void IsValidSucceedsWhenConditionIsFalse()
        {
            Action action = () => Ensures.IsValid(false, "It is an error" );
            action.Should().Throw<InvalidOperationException>().WithMessage("It is an error");
        }
    }
}
