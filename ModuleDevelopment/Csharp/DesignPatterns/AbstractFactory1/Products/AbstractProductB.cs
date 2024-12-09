namespace AbstractFactory1.Products;

public abstract class AbstractProductB(int info)
{
    protected string Info { get; set; } = Convert.ToString(info);
    
    public abstract string GetInfo();
    
    public abstract void B(AbstractProductA productA);
}