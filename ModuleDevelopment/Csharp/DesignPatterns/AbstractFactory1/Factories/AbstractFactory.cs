using AbstractFactory1.Products;

namespace AbstractFactory1.Factories;

public abstract class AbstractFactory
{
    public abstract AbstractProductA CreateProductA();
    public abstract AbstractProductB CreateProductB();
}