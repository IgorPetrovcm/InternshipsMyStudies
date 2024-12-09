namespace Builder;

public class ConcreteBuilder1() : Builder("")
{
    public override void BuildPartA() => Product += "-1-";
    public override void BuildPartB() => Product += "-2-";
    public override void BuildPartC() => Product += "-3-";
    
    public override string GetResult()
    {
        return Product;
    }
}