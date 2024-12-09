using AbstractFactory2.Controls;
using AbstractFactory2.Factory;

namespace AbstractFactory2;

public class Client(ControlFactory? factory)
{
    private ControlFactory _factory = factory ?? throw new NullReferenceException();
    public ControlFactory Factory
    {
        get => _factory;
        set => _factory = value ?? _factory;
    }

    private readonly List<Control> _controls = [];
    
    public void AddButton(string? text)
    {
        _controls.Add(Factory.CreateButton(text));
    }

    public void AddLabel(string? text)
    {
        _controls.Add(Factory.CreateLabel(text));
    }

    public string GetControls()
    {
        return string.Join(' ', _controls
            .Select(x => x.Text)
            .ToArray());
    }
}