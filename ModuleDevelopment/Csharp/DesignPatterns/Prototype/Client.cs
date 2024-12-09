namespace Prototype;

public class Client(Prototype prototype)
{
    private Prototype _prototype = prototype;
    private List<Prototype> _prototypes = [];

    public Prototype Prototype
    {
        get => _prototype;
        set => _prototype = value ?? _prototype;
    }

    public void Operation(int id)
    {
        var prototype = _prototype.Clone();
        prototype.ChangeId(id);
        _prototypes.Add(prototype);
    }

    public string GetObjects()
    {
        return string.Join(' ', _prototypes
            .Select(x => x.GetInfo())
            .ToArray());
    }
}