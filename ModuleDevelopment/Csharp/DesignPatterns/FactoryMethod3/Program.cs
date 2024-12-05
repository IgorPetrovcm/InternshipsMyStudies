namespace FactoryMethod3;

public static class Program
{
    public static void Main()
    {
        int[] inds = { 0, 0, 0, 0 };
        string[] names = { "A", "B", "C", "D" };

        var catCreator = new CatCreator();

        var animals = catCreator.GetZoo(inds, names);

        for (int i = 0; i < animals.Length; i++)
        {
            Console.WriteLine(animals[i].GetInfo());
        }
    }
}