namespace AbstractFactory1.Products;

public class ProductB1(int info) : AbstractProductB(info)
{
    public override string GetInfo()
    {
        return Info;
    }

    public override void B(AbstractProductA productA)
    {
        Info = (Convert.ToInt32(Info) + Convert.ToInt32(productA.GetInfo())).ToString();
    }
}