namespace RationalCalculator.Expressions;

public class Sub : BinaryExpression
{
    public Sub(IRationalExpression leftHand, IRationalExpression rightHand)
        : base(leftHand,rightHand){ }

    public override Rational Evaluate() => LeftHand.Evaluate() - RightHand.Evaluate();
}