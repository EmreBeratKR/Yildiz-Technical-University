using System;

namespace Numerical_Methods
{
    public readonly struct TaylorSeries
    {
        private readonly IFunction m_Function;
        private readonly double m_A;

        
        public TaylorSeries(IFunction function, double a)
        {
            m_Function = function;
            m_A = a;
        }


        public double Evaluate(double x, int n)
        {
            var derivative = m_Function;
            var factor = 1.0;
            var value = derivative.Evaluate(m_A);
            Console.WriteLine(value);
            //Console.WriteLine(derivative);

            for (var i = 1; i < n; i++)
            {
                derivative = derivative.Derivate();
                //Console.WriteLine(derivative);
                factor *= (x - m_A) / i;

                value += derivative.Evaluate(m_A) * factor;
                Console.WriteLine(value);
            }

            return value;
        }
    }
}