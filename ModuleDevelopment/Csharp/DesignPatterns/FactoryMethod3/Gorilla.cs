namespace FactoryMethod3;

public class Gorilla(string? name) : Animal(nameof(Gorilla))
{
    private string Name { get; set; } = name ?? "NonName";

    public override string GetInfo()
    {
        return base.GetInfo() + " " + Name;
    }
    
}