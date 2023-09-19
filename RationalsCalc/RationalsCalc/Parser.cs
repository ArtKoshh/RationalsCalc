using System.Text;
using RationalCalculator.Expressions;
using RationalCalculator.Statements;

namespace RationalCalculator.Parsers;

public class Parser : IParser
{
    private string expression;
    private int i;
    
    public IStatement Parse(string input)
    {
        expression = input;
        i = 0;
        return Parse();
    }
    private IStatement Parse()
    {
        var stmt = 
            TryParseQuit() ??
            ParseEvalStatement();
        
        return End ? stmt : throw new FormatException();
    }
    private IStatement? TryParseQuit()
    {
        var isQuit = expression
            .Trim()
            .Equals("quit", StringComparison.InvariantCultureIgnoreCase);

        if (!isQuit)
            return null;

        i = expression.Length;
        return new QuitStatement();
    }
    private IStatement ParseEvalStatement()
    {
        var operand1 = ParseOperand();
        return new EvalStatement(ParseOptionalOperation(operand1));
    }
    
    private bool IsOperator()
    {
        return "+-:*".Contains(CurrentChar);
    }
    private IRationalExpression ParseOptionalOperation(IRationalExpression operand1)
    {
        SkipBlanks();
        return IsOperator()
            ? ParseOperation(operand1)
            : operand1;
    }
    
    private IRationalExpression ParseOperand()
    {
        SkipBlanks();
        var intPart = ReadInteger();

        if (CurrentChar == '.')
            return FromDecimalNumber(intPart, ReadDecimalPart());

        SkipBlanks();
        if (CurrentChar == '/')
            return FromFraction(intPart, ReadDenominator());

        return FromInteger(intPart);
    }
    
    private IRationalExpression ParseOperation(IRationalExpression operand1)
    {
        var op = ReadChar();
        var operand2 = ParseOperand();
        
        switch (op)
        {
            case '+': return new Add(operand1, operand2);
            case '-': return new Sub(operand1, operand2);
            case ':': return new Div(operand1, operand2);
            case '*': return new Mul(operand1, operand2);
            default: throw new Exception();
        }
        
    }
    
    #region Helpers

    private string ReadInteger()
    {
        var sign = "";
        if (CurrentChar == '-')
            sign = ReadChar().ToString();

        var digits = ReadDigitsSequence();
        if (digits.Length == 0)
            throw new FormatException();

        return sign + digits;
    }
    
    private string ReadDecimalPart()
    {
        ReadChar(); // skip .
        var decimalPart = ReadDigitsSequence();
        if (decimalPart.Length == 0)
            throw new FormatException();
        return decimalPart;
    }
    private string ReadDenominator()
    {
        ReadChar(); // skip /
        SkipBlanks();
        return ReadInteger();
    }
    
    private string ReadDigitsSequence()
    {
        var sb = new StringBuilder();
        
        while (!End && char.IsDigit(CurrentChar))
            sb.Append(ReadChar());

        return sb.ToString();
    }


    private IRationalExpression FromDecimalNumber(string intPart, string decimalPart)
    {
        var numerator = int.Parse(intPart + decimalPart);
        var denominator = (int)Math.Pow(10, decimalPart.Length);
        return new Operand(new Rational(numerator, denominator));
    }
    private IRationalExpression FromFraction(string numerator, string denominator)
    {
        return new Operand(
            new Rational(
                int.Parse(numerator), 
                int.Parse(denominator)
            )
        );
    }
    private IRationalExpression FromInteger(string numerator)
    {
        return new Operand(
            new Rational(
                int.Parse(numerator), 
                1
            )
        );
    }

    private char CurrentChar => End ? '\0' : expression[i];
    private bool End => i >= expression.Length;
    private char ReadChar() => expression[i++];

    private void SkipBlanks()
    {
        while (char.IsWhiteSpace(CurrentChar))
            ReadChar();
    }
    
    #endregion
}
