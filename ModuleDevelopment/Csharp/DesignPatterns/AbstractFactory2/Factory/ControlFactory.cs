using AbstractFactory2.Controls;

namespace AbstractFactory2.Factory;

public abstract class ControlFactory
{
    public abstract AbstractButton CreateButton(string? text);
    public abstract AbstractLabel CreateLabel(string? text);
}