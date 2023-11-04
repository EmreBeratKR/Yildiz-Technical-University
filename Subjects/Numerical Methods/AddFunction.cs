namespace Numerical_Methods
{
    public readonly struct AddFunction : IFunction
    {
        private readonly IFunction m_FunctionA;
        private readonly IFunction m_FunctionB;


        public AddFunction(IFunction functionA, IFunction functionB)
        {
            m_FunctionA = functionA;
            m_FunctionB = functionB;
        }


        public double Evaluate(double x)
        {
            return m_FunctionA.Evaluate(x) + m_FunctionB.Evaluate(x);
        }

        public IFunction Derivate()
        {
            var derivativeOfA = m_FunctionA.Derivate();
            var derivativeOfB = m_FunctionB.Derivate();

            return new AddFunction(derivativeOfA, derivativeOfB);
        }
        
        
        public override string ToString()
        {
            return $"{m_FunctionA} + {m_FunctionB}";
        }
    }
}