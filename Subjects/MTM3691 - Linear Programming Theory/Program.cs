using MTM3691_LinearProgrammingTheory;

var problem = new ProblemBuilder()
    .Minimize(-3, 4, 0)
    .AddLessEqualConstraint(1, 1, 4)
    .AddGreaterEqualConstraint(2, 3, 18);
    
    
problem.GetTableau();