namespace Adapter;

public abstract class Target
{
    protected int A { get; set; }
    protected int B { get; set; }
    
    public abstract int GetA();
    public abstract int GetB();
    public abstract int Request();
}