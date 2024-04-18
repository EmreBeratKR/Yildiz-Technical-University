using System;

namespace Numerical_Methods
{
    public readonly struct CosineFunction : IFunction
    {
        public double Evaluate(double x)
        {
            return Math.Cos(x);
        }

        public IFunction Derivate()
        {
            return new MultiplyFunction(new ConstantFunction(-1), new SineFunction());
        }


        public override string ToString()
        {
            return "cos(x)";
        }
    }
}