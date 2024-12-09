namespace Adapter2;

public class Adaptee(int a, int b)
{
    public (int, int) GetAll() => (a, b);
    public int SpecificRequest() => checked(a * b);
}