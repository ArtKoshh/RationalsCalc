namespace RationalCalculator.Expressions;

public class Mul : BinaryExpression
{
    public Mul(IRationalExpression leftHand, IRationalExpression rightHand)
        : base(leftHand,rightHand){ }

    public override Rational Evaluate() => LeftHand.Evaluate() * RightHand.Evaluate();
}