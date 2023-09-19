namespace RationalCalculator;

public class App
{
    private IInputReader reader;
    private IParser parser;

    public App(IInputReader reader, IParser parser)
    {
        this.reader = reader;
        this.parser = parser;
    }
    
    public bool HaltRequested { get; private set; }

    public void Run()
    {
        while (!HaltRequested)
        {
            try
            {
                var input = reader.Read();
                var stmt = parser.Parse(input);
                stmt.Execute(this);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division by zero is undefined");
            }
            catch (Exception e)
            {
                Console.WriteLine("Syntax Error");
            }
        }
    }

    public void RequestHalt() => HaltRequested = true;
}