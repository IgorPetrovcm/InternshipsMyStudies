namespace AbstractFactory1.Products;

public class ProductB2(int info) : AbstractProductB(info)
{
    public override string GetInfo()
    {
        return Info;
    }

    public override void B(AbstractProductA productA)
    {
        Info += productA.GetInfo();
    }
}