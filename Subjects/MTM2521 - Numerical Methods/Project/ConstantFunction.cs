namespace Numerical_Methods
{
    public readonly struct ConstantFunction : IFunction
    {
        private readonly double m_C;

        
        public ConstantFunction(double c)
        {
            m_C = c;
        }
        
        
        public double Evaluate()
        {
            return m_C;
        }
        
        public double Evaluate(double x)
        {
            return Evaluate();
        }

        public IFunction Derivate()
        {
            return new ConstantFunction(0);
        }


        public override string ToString()
        {
            return $"{m_C}";
        }
    }
}