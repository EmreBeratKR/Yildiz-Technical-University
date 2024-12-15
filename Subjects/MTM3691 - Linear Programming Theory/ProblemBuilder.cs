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
        var slackCount = m_Constraints.Count(e => e.Item1 == "<=");
        var surplusCount = m_Constraints.Count(e => e.Item1 == ">=");
        var columnCount = m_ZCoefficients.Length + slackCount + 2 * surplusCount;
        var rowCount = 1 + m_Constraints.Count;
        var tableau = new List<double[]>();

        for (var i = 0; i < rowCount; i++)
        {
            tableau.Add(new double[columnCount]);
        }

        var extraVariableCount = 0;
        var rowIndex = 1;
        
        foreach (var (operation, coefficients) in m_Constraints)
        {
            if (operation == "<=")
            {
                for (var i = 0; i < coefficients.Length - 1; i++)
                {
                    tableau[rowIndex][i] = coefficients[i];
                }
                
                tableau[rowIndex][coefficients.Length + extraVariableCount - 1] = 1;
                tableau[rowIndex][^1] = coefficients[^1];
                extraVariableCount += 1;
            }
            
            else if (operation == ">=")
            {
                for (var i = 0; i < coefficients.Length - 1; i++)
                {
                    tableau[rowIndex][i] = coefficients[i];
                }
                
                tableau[rowIndex][coefficients.Length + extraVariableCount - 1] = -1;
                tableau[rowIndex][coefficients.Length + extraVariableCount] = 1;
                tableau[rowIndex][^1] = coefficients[^1];
                extraVariableCount += 2;
            }

            rowIndex += 1;
        }
        
        var outp = "";
        
        foreach (var row in tableau)
        {
            foreach (var value in row)
            {
                outp += value + ",";
            }

            outp += "\n";
        }
        
        Console.WriteLine(outp);
        
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