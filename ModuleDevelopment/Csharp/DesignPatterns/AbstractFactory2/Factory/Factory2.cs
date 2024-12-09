using AbstractFactory2.Controls;

namespace AbstractFactory2.Factory;

public class Factory2 : ControlFactory
{
    public override AbstractButton CreateButton(string? text)
    {
        return new Button2(text);
    }

    public override AbstractLabel CreateLabel(string? text)
    {
        return new Label2(text);
    }
}