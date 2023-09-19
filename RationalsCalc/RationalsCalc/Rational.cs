namespace RationalCalculator;

public struct Rational
{
    private int _numerator;
    private int _denominator;

    public Rational(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new DivideByZeroException();
        
        _numerator = numerator;
        _denominator = denominator;
        Simplify();
    }

    #region Operations

    public static Rational operator +(Rational x, Rational y)
    {
        return new Rational(
            x._numerator * y._denominator + x._denominator * y._numerator,
            x._denominator * y._denominator
        );
    }
    public static Rational operator -(Rational x, Rational y)
    {
        return new Rational(
            x._numerator * y._denominator - x._denominator * y._numerator,
            x._denominator * y._denominator
        );
    }
    
    public static Rational operator *(Rational x, Rational y)
    {
        return new Rational(
            x._numerator * y._numerator,
            x._denominator * y._denominator
        );
    }
    public static Rational operator /(Rational x, Rational y)
    {
        return new Rational(
            x._numerator * y._denominator,
            x._denominator * y._numerator
        );
    }

    #endregion

    public override string ToString()
    {
        if (_numerator == 0)
            return "0";

        if (_denominator == 1)
            return _numerator.ToString();

        return $"{_numerator} / {_denominator}";
    }

    private void Simplify()
    {
        var sign = ComputeSignOfProduct(_numerator, _denominator);
        _numerator = Math.Abs(_numerator);
        _denominator = Math.Abs(_denominator);
        
        var gcd = Gcd(_numerator, _denominator);
        _numerator /= gcd;
        _denominator /= gcd;

        _numerator *= sign;
    }

    private static int ComputeSignOfProduct(int x, int y)
    {
        return x < 0 ^ y < 0 ? -1 : 1;
    }
    
    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
}