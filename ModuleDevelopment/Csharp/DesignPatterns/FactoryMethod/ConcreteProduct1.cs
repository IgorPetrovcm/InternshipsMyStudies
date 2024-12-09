namespace DesignPatterns.FactoryMethod;

public class ConcreteProduct1(string info) : Product
{
    private string info { get; set; } = info.ToLower();

    public override string GetInfo()
    {
        return info;
    }

    public override void Transform()
    {
        if (info is null)
        {
            throw new NullReferenceException("Product info is null");
        }

        var sorted = info
            .Where(x => x != ' ')
            .ToList();
        
        info = sorted
            .Aggregate("", (current, c) => current + c + " ");
    }
}