using AbstractFactory2.Factory;

namespace AbstractFactory2;

public static class Program
{
    public static void Main()
    {
        var factory1 = new Factory1();
        var factory2 = new Factory2();

        var client = new Client(factory1);
        
        client.AddButton("Test1B");
        client.AddLabel("Test1L");

        client.Factory = factory2;
        
        client.AddButton("Test2B");
        client.AddLabel("Test2L");

        Console.WriteLine(client.GetControls());
    }
}