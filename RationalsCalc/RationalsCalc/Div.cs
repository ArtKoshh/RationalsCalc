namespace RationalCalculator.Expressions;

public class Div : BinaryExpression
{
    public Div(IRationalExpression leftHand, IRationalExpression rightHand)
        : base(leftHand,rightHand){ }

    public override Rational Evaluate() => LeftHand.Evaluate() / RightHand.Evaluate();
}
