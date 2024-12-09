using AbstractFactory2.Controls;

namespace AbstractFactory2.Factory;

public class Factory1 : ControlFactory
{
    public override AbstractButton CreateButton(string? text)
    {
        return new Button1(text);
    }

    public override AbstractLabel CreateLabel(string? text)
    {
        return new Label1(text);
    }
}