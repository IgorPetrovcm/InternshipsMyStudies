namespace DesignPatterns.FactoryMethod2;

public class ConcreteProduct2 : ConcreteProduct1
{
    public ConcreteProduct2() {}
    
    public ConcreteProduct2(string info) : base(info)
    {
        this.info = Char.ToUpper(this.info[0]) + this.info.Remove(0, 1);
    }

    public override void Transform()
    {
        base.Transform();

        info = "==" + info + "==";
    }

    public override ConcreteProduct1 FactoryMethod(string info)
    {
        return new ConcreteProduct2(info);
    }
}