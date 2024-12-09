namespace DesignPatterns.FactoryMethod;

public class ConcreteCreator1 : Creator
{
    public override Product FactoryMethod(string info)
    {
        return new ConcreteProduct1(info);
    }
}