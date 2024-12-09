namespace Builder;

public static class Program
{
    public static void Main()
    {
        var b1 = new ConcreteBuilder1();
        var b2 = new ConcreteBuilder2();

        var d1 = new Director(b1);
        var d2 = new Director(b2);

        var commands = new string[5]
        {
            "AABC",
            "BCACCA",
            "ABC",
            "BC",
            "AAA"
        };

        foreach (var command in commands)
        {
            d1.Construct(command);
            Console.WriteLine(d1.GetResult());
        }
        Console.WriteLine();
        foreach (var command in commands)
        {
            d2.Construct(command);
            Console.WriteLine(d2.GetResult());
        }
    }
}