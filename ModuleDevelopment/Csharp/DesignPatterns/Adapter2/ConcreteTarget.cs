namespace Adapter2;

public class ConcreteTarget(int a, int b) : ITarget
{
    public int GetA() => a;
    public int GetB() => b;
    public int Request() => checked(a + b);
}