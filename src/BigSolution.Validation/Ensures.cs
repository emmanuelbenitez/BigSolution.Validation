using System;
using JetBrains.Annotations;

namespace BigSolution
{
    public static class Ensures
    {
        [AssertionMethod]
        public static void IsValid(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string errorMessage)
        {
            if (!condition) throw new InvalidOperationException(errorMessage);
        }

        [AssertionMethod]
        public static void IsValid<TException>(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition)
            where TException : Exception, new()
        {
            if (!condition) throw new TException();
        }

        [AssertionMethod]
        public static void NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
            T value,
            string errorMessage)
        {
            if (value == null) throw new InvalidOperationException(errorMessage);
        }
    }
}
