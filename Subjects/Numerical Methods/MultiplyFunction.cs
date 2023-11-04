namespace Numerical_Methods
{
    public readonly struct MultiplyFunction : IFunction
    {
        private readonly IFunction m_FunctionA;
        private readonly IFunction m_FunctionB;

        
        public MultiplyFunction(IFunction functionA, IFunction functionB)
        {
            m_FunctionA = functionA;
            m_FunctionB = functionB;
        }

        
        public double Evaluate(double x)
        {
            return m_FunctionA.Evaluate(x) * m_FunctionB.Evaluate(x);
        }

        public IFunction Derivate()
        {
            if (m_FunctionA is ConstantFunction && m_FunctionB is ConstantFunction)
            {
                return new ConstantFunction(0);
            }
            
            if (m_FunctionA is ConstantFunction)
            {
                return new MultiplyFunction(m_FunctionA, m_FunctionB.Derivate());
            }

            if (m_FunctionB is ConstantFunction)
            {
                return new MultiplyFunction(m_FunctionA.Derivate(), m_FunctionB);
            }
            
            var derivativeOfA = m_FunctionA.Derivate();
            var derivativeOfB = m_FunctionB.Derivate();
            var left = new MultiplyFunction(derivativeOfA, m_FunctionB);
            var right = new MultiplyFunction(m_FunctionA, derivativeOfB);

            return new AddFunction(left, right);
        }


        public override string ToString()
        {
            return $"{m_FunctionA} * {m_FunctionB}";
        }
    }
}