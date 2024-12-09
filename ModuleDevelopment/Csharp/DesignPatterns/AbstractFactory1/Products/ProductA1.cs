namespace AbstractFactory1.Products;

public class ProductA1(int info) : AbstractProductA(info)
{
    public override string GetInfo()
    {
        return Info;
    }

    public override void A()
    {
        checked
        {
            Info = (Convert.ToInt32(Info) * 2).ToString();
        }
    }
}