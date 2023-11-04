using System;

namespace Numerical_Methods;

public readonly struct NaturalExponentialFunction : IFunction
{
    public double Evaluate(double x)
    {
        return Math.Exp(x);
    }

    public IFunction Derivate()
    {
        return this;
    }
}