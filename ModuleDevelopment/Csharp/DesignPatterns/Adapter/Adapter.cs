namespace Adapter;

public class Adapter(int a, int b) : Target
{
    private readonly Adaptee _ad = new(a, b);
    
    public override int GetA()
    {
        return _ad.GetAll().Item1;
    }

    public override int GetB()
    {
        return _ad.GetAll().Item2;
    }

    public override int Request()
    {
        return _ad.SpecificRequest();
    }
}