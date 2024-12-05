namespace FactoryMethod3;

public abstract class Animal(string? name)
{
    private string info { get; set; } = name ?? "NonInfo";

    public virtual string GetInfo()
    {
        return info;
    }
}