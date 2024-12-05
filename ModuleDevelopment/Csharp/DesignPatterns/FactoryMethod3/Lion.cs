namespace FactoryMethod3;

public class Lion(string? name) : Animal(nameof(Lion))
{
    private string Name { get; set; } = name ?? "NonName";

    public override string GetInfo()
    {
        return base.GetInfo() + " " + Name;
    }
}