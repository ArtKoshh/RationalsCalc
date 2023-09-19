namespace RationalCalculator.Expressions;

public class Add : BinaryExpression
{
    public Add(IRationalExpression leftHand, IRationalExpression rightHand)
        : base(leftHand,rightHand){ }

    public override Rational Evaluate() => LeftHand.Evaluate() + RightHand.Evaluate();
}
