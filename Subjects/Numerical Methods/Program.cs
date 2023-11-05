using System;

namespace Numerical_Methods
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var a = new PowerFunction(3);
            var b = new MultiplyFunction(new ConstantFunction(7), new PowerFunction(2));
            var c = new LinearFunction(14, 0);
            var d = new ConstantFunction(6);
            var f = new AddFunction(new SubtractFunction(a, b), new SubtractFunction(c, d));
            var approximateX = NonLinearSolver.Bisection(f, 0, 1, 1E-50);
            
            Console.WriteLine($"[f(x) = {f}] at [x = {approximateX}, y = {f.Evaluate(approximateX)}]");
            
            return;
            
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