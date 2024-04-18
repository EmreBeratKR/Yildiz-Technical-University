namespace Numerical_Methods;

public readonly struct MaclaurinSeries
{
    private readonly TaylorSeries m_TaylorSeries;
    
    
    public MaclaurinSeries(IFunction function)
    {
        m_TaylorSeries = new TaylorSeries(function, 0);
    }


    public double Evaluate(double x, int n)
    {
        return m_TaylorSeries.Evaluate(x, n);
    }
}