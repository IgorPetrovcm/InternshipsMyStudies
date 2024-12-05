namespace DesignPatterns.FactoryMethod2;

public class ConcreteProduct1
{
    protected string? info { get; set; }

    public ConcreteProduct1() {}

    public ConcreteProduct1(string info)
    {
        this.info = info;
    }

    public string GetInfo()
    {
        return info ?? "";
    }

    public virtual void Transform()
    {
        if (info is null)
        {
            throw new NullReferenceException("Info in product is null");
        }
        
        List<char> sortedInfo = info.Where(x => x != '*').ToList();

        info = sortedInfo.Aggregate("", (current, x) => current += "*" + x);
    }

    public virtual ConcreteProduct1 FactoryMethod(string info)
    {
        return new ConcreteProduct1(info);
    }

    public string AnOperation(string info)
    {
        ConcreteProduct1 product = FactoryMethod(info);

        product.Transform();
        product.Transform();

        return product.GetInfo();
    }
}