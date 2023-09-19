namespace RationalCalculator.Statements;

public class EvalStatement : IStatement
{
    private IRationalExpression expr;

    public EvalStatement(IRationalExpression expr) => this.expr = expr;
    
    public void Execute(App app)
    {
        var result = expr.Evaluate();
        Console.WriteLine(result.ToString());
    }
}