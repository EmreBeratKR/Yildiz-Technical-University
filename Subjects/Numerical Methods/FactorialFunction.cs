namespace Numerical_Methods
{
    public readonly struct FactorialFunction : IFunction
    {
        public double Evaluate(double x)
        {
            if (x < 0)
            {
                FunctionExceptions.ThrowInputOutOfRangeException(this, x);
            }

            if (x <= 1) return 1;

            var result = 1.0;
            
            for (var i = 2; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }

        public IFunction Derivate()
        {
            return this;
        }

        public override string ToString()
        {
            return "x!";
        }
        
        
        public static ConstantFunction AsConstant(int x)
        {
            return new ConstantFunction(new FactorialFunction().Evaluate(x));
        }
    }
}