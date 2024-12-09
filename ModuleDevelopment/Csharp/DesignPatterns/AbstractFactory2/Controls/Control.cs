namespace AbstractFactory2.Controls;

public abstract class Control(string text)
{
    public string Text { get; set; } = text;

    public virtual string GetControl()
    {
        return Text;
    }
}