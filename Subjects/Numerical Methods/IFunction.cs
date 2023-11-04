namespace Numerical_Methods
{
    public interface IFunction
    {
        double Evaluate(double x);
        IFunction Derivate();
    }
}