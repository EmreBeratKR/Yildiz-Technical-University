namespace MTM3691_LinearProgrammingTheory;

public class ProblemBuilder
{
    private bool m_IsMaximizing;
    private double[] m_ZCoefficients;
    private List<(string, double[])> m_Constraints = new();


    public ProblemBuilder Maximize(params double[] coefficients)
    {
        m_IsMaximizing = true;
        m_ZCoefficients = coefficients;
        return this;
    }

    public ProblemBuilder Minimize(params double[] coefficients)
    {
        m_IsMaximizing = false;
        m_ZCoefficients = coefficients;
        return this;
    }

    public ProblemBuilder AddLessEqualConstraint(params double[] coefficients)
    {
        m_Constraints.Add(("<=", coefficients));
        return this;
    }
    
    public ProblemBuilder AddGreaterEqualConstraint(params double[] coefficients)
    {
        m_Constraints.Add((">=", coefficients));
        return this;
    }

    public ProblemBuilder GetTableau()
    {
        var slackVariableCount = m_Constraints.Count(e => e.Item1 == "<=");
        var surplusVariableCount = m_Constraints.Count(e => e.Item1 == ">=");
        
        Console.WriteLine(slackVariableCount);
        Console.WriteLine(surplusVariableCount);
        
        return this;
    }


    public override string ToString()
    {
        var zPrefix = m_IsMaximizing ? "max" : "min";
        var z = $"{zPrefix} z = ";

        for (var i = 0; i < m_ZCoefficients.Length; i++)
        {
            if (m_ZCoefficients[i] == 0.0) continue;

            var name = i == m_ZCoefficients.Length - 1 ? "" : $"(x{i + 1})";
            var sign = Math.Sign(m_ZCoefficients[i]) > 0 ? "+" : "-";
            z += $"{sign}{Math.Abs(m_ZCoefficients[i])}{name}";
        }

        var constraints = "";

        foreach (var (operation, coefficients) in m_Constraints)
        {
            for (var i = 0; i < coefficients.Length - 1; i++)
            {
                if (coefficients[i] == 0.0) continue;
                
                var name = $"(x{i + 1})";
                var sign = Math.Sign(coefficients[i]) > 0 ? "+" : "-";
                constraints += $"{sign}{Math.Abs(coefficients[i])}{name}";
            }

            constraints += $"{operation}{coefficients[^1]}\n";
        }
        
        return $"{z}\nConstraints\n{constraints}";
    }
}