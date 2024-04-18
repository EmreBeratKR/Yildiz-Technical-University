namespace Numerical_Methods;

public readonly struct UnitFunction : IFunction
{
    public double Evaluate(double x)
    {
        return x;
    }

    public IFunction Derivate()
    {
        return new ConstantFunction(1);
    }


    public override string ToString()
    {
        return "x";
    }
}