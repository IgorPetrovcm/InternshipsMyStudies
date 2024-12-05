namespace DesignPatterns.FactoryMethod;

public static class Program
{
    public static void Main()
    {
        var creator1 = new ConcreteCreator1();
        var creator2 = new ConcreteCreator2();

        var testValues = new List<string>{
            "Hello",
            "Bye",
            "True",
            "False",
            "Notes" 
        };

        testValues.ForEach(x => {
            Console.WriteLine(creator1.AnOperation(x));
            Console.WriteLine(creator2.AnOperation(x));
        });
    }
}