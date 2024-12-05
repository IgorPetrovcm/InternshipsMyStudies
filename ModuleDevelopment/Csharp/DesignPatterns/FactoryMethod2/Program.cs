namespace DesignPatterns.FactoryMethod2;

public static class Program
{
    public static void Main()
    {
        var strings = new List<string>(){
            "Hello",
            "_developer",
            "gENDER"
        };

        foreach (var str in strings){
            Console.WriteLine(new ConcreteProduct1().AnOperation(str));
            Console.WriteLine(new ConcreteProduct2().AnOperation(str));
        }
    }
}