using System;

namespace Numerical_Methods;

public readonly struct PowerFunction : IFunction
{
    private readonly IFunction m_InnerFunction;
    private readonly double m_Power;

    
    public PowerFunction(double power)
    {
        m_InnerFunction = new UnitFunction();
        m_Power = power;
    }
    
    public PowerFunction(IFunction innerFunction, double power)
    {
        m_InnerFunction = innerFunction;
        m_Power = power;
    }

    public double Evaluate(double x)
    {
        var innerValue = m_InnerFunction.Evaluate(x);
        
        return Math.Pow(innerValue, m_Power);
    }

    public IFunction Derivate()
    {
        return new MultiplyFunction(new MultiplyFunction(new ConstantFunction(m_Power), m_InnerFunction.Derivate()), new PowerFunction(m_Power - 1));
    }


    public override string ToString()
    {
        return $"({m_InnerFunction})^({m_Power})";
    }
}