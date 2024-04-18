using System;

namespace Numerical_Methods
{
    public readonly struct ExponentialFunction : IFunction
    {
        private readonly double m_Base;

        
        public ExponentialFunction(double @base)
        {
            m_Base = @base;
        }


        public double Evaluate(double x)
        {
            return Math.Pow(m_Base, x);
        }

        public IFunction Derivate()
        {
            return new MultiplyFunction(new ExponentialFunction(m_Base), LogarithmFunction.AsConstant(Math.E, m_Base));
        }
        
        
        public override string ToString()
        {
            return $"({m_Base})^x";
        }
    }
}