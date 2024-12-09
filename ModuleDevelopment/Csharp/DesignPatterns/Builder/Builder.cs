namespace Builder;

public abstract class Builder(string product)
{
    protected string Product { get; set; } = product;

    public virtual void BuildStart() => Product = "";
    public virtual void BuildPartA(){}
    public virtual void BuildPartB(){}
    public virtual void BuildPartC(){}

    public abstract string GetResult();
}