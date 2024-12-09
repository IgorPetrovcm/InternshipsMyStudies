namespace Prototype;

public class ConcretePrototype1(int? id, string? data) : Prototype(id, data)
{
    private const string Info = "CP1";
    
    public override Prototype Clone()
    {
        return new ConcretePrototype1(Id, Data);
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