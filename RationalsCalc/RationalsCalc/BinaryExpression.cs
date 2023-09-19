namespace RationalCalculator.Expressions;

public abstract class BinaryExpression : IRationalExpression
{
    public IRationalExpression LeftHand { get; }
    public IRationalExpression RightHand { get; }

    public BinaryExpression(IRationalExpression leftHand, IRationalExpression rightHand)
    {
        LeftHand = leftHand;
        RightHand = rightHand;
    }

    public abstract Rational Evaluate();
}
