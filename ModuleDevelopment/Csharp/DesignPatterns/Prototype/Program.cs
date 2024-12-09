namespace Prototype;

public static class Program
{
    public static void Main(string[] args)
    {
        const int prototypeNumber = 8;
        
        if (args.Length == 0 || args[0].Split().Equals(""))
        {
            throw new ArgumentException("Usage: dotnet run [data]");
        }
        
        var prototype1 = new ConcretePrototype1(0, args[0]);
        var prototype2 = new ConcretePrototype2(0, args[0]);

        var ids = new int[prototypeNumber] { 3, 5, 7, 2, 19, 1, 6, 9 };

        var client1 = new Client(prototype1);
        var client2 = new Client(prototype2);

        foreach (var id in ids)
        {
            client1.Operation(id);
            client2.Operation(id);
        }
        
        Console.WriteLine(client1.GetObjects());
        Console.WriteLine(client2.GetObjects());
    }
}