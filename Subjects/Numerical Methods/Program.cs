using System;

namespace Numerical_Methods
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var sine = new TaylorSeries(new SineFunction(), 0);
            var cosine = new TaylorSeries(new CosineFunction(), 0);
            var euler = new MaclaurinSeries(new NaturalExponentialFunction());
            
            Console.WriteLine("sine ------------------");
            sine.Evaluate(Math.PI * 0.5, 30);
            Console.WriteLine("cosine ----------------");
            cosine.Evaluate(Math.PI, 30);
            Console.WriteLine("e^x -------------------");
            euler.Evaluate(1, 30);
        }
    }
}