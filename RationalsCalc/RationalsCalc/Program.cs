using RationalCalculator;
using RationalCalculator.Parsers;

var app = new App(
    new ConsoleReader(),
    new Parser()
);
app.Run();