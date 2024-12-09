namespace Adapter;

public class Adaptee(int a, int b)
{
    private int A { get; set; } = a;
    private int B { get; set; } = b;

    public (int, int) GetAll()
    {
        return (A, B);
    }

    public int SpecificRequest()
    {
        return checked(A * B);
    }
}