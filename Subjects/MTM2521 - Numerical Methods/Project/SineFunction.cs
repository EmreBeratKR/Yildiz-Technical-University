using System;

namespace Numerical_Methods
{
    public readonly struct SineFunction : IFunction
    {
        public double Evaluate(double x)
        {
            return Math.Sin(x);
        }

        public IFunction Derivate()
        {
            return new CosineFunction();
        }


        public override string ToString()
        {
            return "sin(x)";
        }
    }
}