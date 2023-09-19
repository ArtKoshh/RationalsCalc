namespace RationalCalculator.Expressions;

public class Operand : IRationalExpression
{
    private Rational operand;

    public Operand(Rational operand) => this.operand = operand;

    public Rational Evaluate() => operand;
}
