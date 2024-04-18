namespace Numerical_Methods
{
    public readonly struct DivideFunction : IFunction
    {
        private readonly IFunction m_Numerator;
        private readonly IFunction m_Denominator;

        
        public DivideFunction(IFunction numerator, IFunction denominator)
        {
            m_Numerator = numerator;
            m_Denominator = denominator;
        }

        public double Evaluate(double x)
        {
            return m_Numerator.Evaluate(x) / m_Denominator.Evaluate(x);
        }

        public IFunction Derivate()
        {
            var numerator = new SubtractFunction(new MultiplyFunction(m_Numerator.Derivate(), m_Denominator), new MultiplyFunction(m_Numerator, m_Denominator.Derivate()));
            var denominator = new MultiplyFunction(m_Denominator, m_Denominator);

            return new DivideFunction(numerator, denominator);
        }


        public override string ToString()
        {
            return $"({m_Numerator} / {m_Denominator})";
        }
    }
}