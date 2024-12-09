using AbstractFactory1.Products;

namespace AbstractFactory1.Factories;

public class ConcreteFactory2 : AbstractFactory
{
    public override AbstractProductA CreateProductA()
    {
        throw new NotImplementedException();
    }

    public override AbstractProductB CreateProductB()
    {
        throw new NotImplementedException();
    }
}