namespace RationalCalculator.Statements;

public class QuitStatement : IStatement
{
    public void Execute(App app) => app.RequestHalt();
}