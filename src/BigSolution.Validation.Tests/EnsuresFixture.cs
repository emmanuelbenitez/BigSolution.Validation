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
            Action action = () => Ensures.IsValid<Exception>(true);
            action.Should().NotThrow<Exception>();
        }

        [Fact]
        public void IsValidGenericSucceedsWhenConditionIsFalse()
        {
            Action action = () => Ensures.IsValid<Exception>(false);
            action.Should().ThrowExactly<Exception>();
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
            action.Should().ThrowExactly<InvalidOperationException>().WithMessage("It is an error");
        }

        [Fact]
        public void NotNullSucceedsWhitNullValue()
        {
            Action action = () => Ensures.NotNull((string)null, "The value is null");
            action.Should().ThrowExactly<InvalidOperationException>().WithMessage("The value is null");
        }

        [Fact]
        public void NotNullSucceedsWhitNotNullValue()
        {
            Action action = () => Ensures.NotNull(string.Empty, "The value is null");
            action.Should().NotThrow<InvalidOperationException>();
        }
    }
}
