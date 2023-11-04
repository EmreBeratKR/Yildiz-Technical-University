namespace Numerical_Methods
{
    public readonly struct LinearFunction : IFunction
    {
        private readonly double m_A;
        private readonly double m_B;

        
        public LinearFunction(double a, double b)
        {
            m_A = a;
            m_B = b;
        }


        public double Evaluate(double x)
        {
            return m_A * x + m_B;
        }

        public IFunction Derivate()
        {
            return new ConstantFunction(m_A);
        }
        
        
        public override string ToString()
        {
            return m_B switch
            {
                < 0 => $"{m_A}x {m_B}",
                > 0 => $"{m_A}x + {m_B}",
                _ => $"{m_A}x"
            };
        }
    }
}