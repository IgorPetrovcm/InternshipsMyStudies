namespace Adapter;

public class ConcreteTarget : Target
{
    public ConcreteTarget(int a, int b)
    {
        A = a;
        B = b;
    }
    
    public override int GetA()
    {
        return A;
    }

    public override int GetB()
    {
        return B;
    }

    public override int Request()
    {
        return checked(A + B);
    }
}