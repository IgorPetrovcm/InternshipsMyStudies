namespace AbstractFactory1.Products;

public class ProductA2(int info) : AbstractProductA(info)
{
    public override string GetInfo()
    {
        return Info;
    }

    public override void A()
    {
        Info += Info;
    }
}