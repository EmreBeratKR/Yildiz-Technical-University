using System;

namespace Numerical_Methods
{
    public readonly struct LogarithmFunction : IFunction
    {
        private readonly double m_Base;

        
        public LogarithmFunction(double @base)
        {
            m_Base = @base;
        }

        public double Evaluate(double x)
        {
            return Math.Log(x, m_Base);
        }

        public IFunction Derivate()
        {
            return new PowerFunction(new MultiplyFunction(new UnitFunction(), new LogarithmFunction(m_Base)), -1);
        }
        
        
        public override string ToString()
        {
            return $"log{m_Base}(x)";
        }


        public static ConstantFunction AsConstant(double @base, double x)
        {
            return new ConstantFunction(new LogarithmFunction(@base).Evaluate(x));
        }
    }
}