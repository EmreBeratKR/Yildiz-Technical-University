using System;

namespace Numerical_Methods
{
    public static class FunctionExceptions
    {
        public static void ThrowInputOutOfRangeException(IFunction function, double value)
        {
            throw new Exception($"Value [x: {value}] is out of range for [{function}].");
        }
    }
}