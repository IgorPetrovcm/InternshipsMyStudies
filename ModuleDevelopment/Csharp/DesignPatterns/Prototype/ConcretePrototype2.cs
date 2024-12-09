namespace Prototype;

public class ConcretePrototype2(int? id, string? data) : Prototype(id, data)
{
    private const string Info = "CP2";

    public override Prototype Clone()
    {
        return new ConcretePrototype2(Id, Data);
    }

    public override string GetInfo()
    {
        return Info + "=" + Data + "=" + Id;
    }

    public override void ChangeId(int id)
    {
        Id = id;
    }
}