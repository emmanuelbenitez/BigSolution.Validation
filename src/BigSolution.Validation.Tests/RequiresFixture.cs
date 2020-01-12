using System;
using FluentAssertions;
using Xunit;

namespace BigSolution
{
    public class RequiresFixture
    {
        [Fact]
        public void GreaterOrEqualThanFailed()
        {
            Action action = () => Requires.GreaterOrEqualThan(0, 1, "value");
            action.Should().ThrowExactly<ArgumentException>()
                .Where(exception => exception.ParamName == "value")
                .WithMessage("The value '0' must greater than '1' *");
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void GreaterOrEqualThanSucceeds(int value, int valueToCompare)
        {
            Action action = () => Requires.GreaterOrEqualThan(value, valueToCompare, nameof(value));
            action.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        public void GreaterThanNullableFailed(int? value, int? valueToCompare)
        {
            Action action = () => Requires.GreaterThan(value, valueToCompare, nameof(value));
            action.Should().ThrowExactly<ArgumentException>()
                .Where(exception => exception.ParamName == "value")
                .WithMessage("The value '*' must greater than '*'*");
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(0, null)]
        [InlineData(null, 0)]
        public void GreaterThanNullableSucceeds(int? value, int? valueToCompare)
        {
            Action action = () => Requires.GreaterThan(value, valueToCompare, nameof(value));
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void GreaterThanSucceeds()
        {
            Action action = () => Requires.GreaterThan(1, 0, "name");
            action.Should().NotThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        public void GreaterThenFailed(int value, int valueToCompare)
        {
            Action action = () => Requires.GreaterThan(value, valueToCompare, nameof(value));
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The value '*' must greater than '*'*")
                .Where(exception => exception.ParamName == "value");
        }

        [Fact]
        public void HasValidFormatFailed()
        {
            Action action = () => Requires.HasValidFormat("ABC", @"\d{3}", "name", "This is an error");
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("This is an error *")
                .Where(exception => exception.ParamName == "name");
        }

        [Fact]
        public void HasValidFormatSucceeds()
        {
            Action action = () => Requires.HasValidFormat("123", @"\d{3}", "name", "This is an error");
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void IsValidFailed()
        {
            Action action = () => Requires.IsValid(false, "name", "This is an error");
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("This is an error *")
                .Where(exception => exception.ParamName == "name");
        }

        [Fact]
        public void IsValidSucceeds()
        {
            Action action = () => Requires.IsValid(true, "name", string.Empty);
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void NotEmptyCollectionFailed()
        {
            Action action = () => Requires.NotEmpty(new string[0], "name");
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection is empty*")
                .Where(exception => exception.ParamName == "name");
        }

        [Fact]
        public void NotEmptyCollectionSucceeds()
        {
            Action action = () => Requires.NotEmpty(new[] { "hello" }, "name");
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void NotEmptyStringFailed()
        {
            Action action = () => Requires.NotEmpty(String.Empty, "name");
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The string is null or empty *")
                .Where(exception => exception.ParamName == "name");
        }

        [Fact]
        public void NotEmptyStringSucceeds()
        {
            Action action = () => Requires.NotEmpty("This is a sample", "name");
            action.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void NotNullElementFailed()
        {
            var collection = new int?[] { 1, null, 3 };
            Action action = () => Requires.NotNullElement(collection, nameof(collection));
            action.Should().ThrowExactly<ArgumentException>()
                .WithMessage("The collection contains null element*")
                .Where(exception => exception.ParamName == nameof(collection));
        }

        [Theory]
        [InlineData(null)]
        [InlineData(new[] { 1 })]
        public void NotNullElementSucceeds(int[] collection)
        {
            Action action = () => Requires.NotNullElement(collection, nameof(collection));
            action.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void NotNullFailed()
        {
            Action action = () => Requires.NotNull((string) null, "name");
            action.Should().ThrowExactly<ArgumentNullException>()
                .Where(exception => exception.ParamName == "name");
        }

        [Fact]
        public void NotNullSucceeds()
        {
            Action action = () => Requires.NotNull(1, "name");
            action.Should().NotThrow<ArgumentNullException>();
        }
    }
}
