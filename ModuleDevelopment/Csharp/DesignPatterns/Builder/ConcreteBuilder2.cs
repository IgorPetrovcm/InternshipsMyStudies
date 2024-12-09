namespace Builder;

public class ConcreteBuilder2() : Builder("")
{
    public override void BuildPartA() => Product += "=*=";
    public override void BuildPartB() => Product += "=**=";
    public override void BuildPartC() => Product += "=***=";
    
    public override string GetResult()
    {
        return Product;
    }
}