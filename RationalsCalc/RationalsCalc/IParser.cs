namespace RationalCalculator;

public interface IParser
{
    IStatement Parse(string input);
}