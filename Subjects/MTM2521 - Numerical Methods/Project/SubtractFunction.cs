namespace Numerical_Methods
{
    public readonly struct SubtractFunction : IFunction
    {
        private readonly IFunction m_FunctionA;
        private readonly IFunction m_FunctionB;

        
        public SubtractFunction(IFunction functionA, IFunction functionB)
        {
            m_FunctionA = functionA;
            m_FunctionB = functionB;
        }

        
        public double Evaluate(double x)
        {
            return m_FunctionA.Evaluate(x) - m_FunctionB.Evaluate(x);
        }

        public IFunction Derivate()
        {
            return new SubtractFunction(m_FunctionA.Derivate(), m_FunctionB.Derivate());
        }
        
        
        public override string ToString()
        {
            return $"{m_FunctionA} - {m_FunctionB}";
        }
    }
}