namespace Adapter2;

public class Adapter(int a, int b) : Adaptee(a, b), ITarget
{
    public int GetA() => a;
    public int GetB() => b;
    public int Request() => SpecificRequest();
}