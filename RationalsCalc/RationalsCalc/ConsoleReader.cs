namespace RationalCalculator;

public class ConsoleReader : IInputReader
{
    public string Read() => Console.ReadLine() ?? string.Empty;
}
