using System;

namespace Numerical_Methods;

public static class NonLinearSolver
{
    public static double Bisection(IFunction function, double a, double b, double maxError)
    {
        if (function.Evaluate(a) * function.Evaluate(b) > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), nameof(b), $"Bisection method won't be applied in range [{a},{b}].");
        }
        
        var i = 0;
        
        while (true)
        {
            var c = (a + b) * 0.5;
            var error = function.Evaluate(c);
            
            Console.WriteLine($"[{i}]: {c}");
            if (Math.Abs(error) < maxError) return c;

            i += 1;

            var value = function.Evaluate(c);
            var fA = function.Evaluate(a);

            if (value * fA < 0)
            {
                b = c;
                continue;
            }
            
            var fB = function.Evaluate(b);

            if (value * fB < 0)
            {
                a = c;
                continue;
            }

            return c;
        }
    }

    public static double FalsePosition(IFunction function, double a, double b, double maxError)
    {
        if (function.Evaluate(a) * function.Evaluate(b) > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), nameof(b), $"False Position method won't be applied in range [{a},{b}].");
        }
        
        var i = 0;
        
        while (true)
        {
            var fA = function.Evaluate(a);
            var fB = function.Evaluate(b);
            var c = (a * fB - b * fA) / (fB - fA);
            var error = function.Evaluate(c);

            Console.WriteLine($"[{i}]: {c}");
            if (Math.Abs(error) < maxError) return c;

            i += 1;

            var value = function.Evaluate(c);

            if (value * fA < 0)
            {
                b = c;
                continue;
            }

            if (value * fB < 0)
            {
                a = c;
                continue;
            }

            return c;
        }
    }

    public static double NewtonRaphson(IFunction function, double a, double b, double maxError)
    {
        if (function.Evaluate(a) * function.Evaluate(b) > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), nameof(b), $"Newton Raphson method won't be applied in range [{a},{b}].");
        }
        
        var derivative = function.Derivate();
        var c = a;
        var i = 0;

        while (true)
        {
            var delta = function.Evaluate(c) / derivative.Evaluate(c); 
            c -= delta;
            Console.WriteLine($"[{i}]: {c}");

            if (Math.Abs(delta) < maxError) return c;

            i += 1;
        }
    }

    public static double Secant(IFunction function, double a, double b, double maxError)
    {
        if (function.Evaluate(a) * function.Evaluate(b) > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(a), nameof(b), $"Secant method won't be applied in range [{a},{b}].");
        }
        
        var previousC = a;
        var c = b;
        var i = 0;

        while (true)
        {
            var fC = function.Evaluate(c);
            var delta = fC * (previousC - c) / (function.Evaluate(previousC) - fC); 
            previousC = c;
            c -= delta;
            Console.WriteLine($"[{i}]: {c}");

            if (Math.Abs(delta) < maxError) return c;

            i += 1;
        }
    }
}