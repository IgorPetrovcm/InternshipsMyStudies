namespace Prototype;

public abstract class Prototype(int? id, string? data)
{
    protected int Id { get; set; } = id ?? default;
    protected string Data { get; set; } = data ?? string.Empty;
    
    public abstract Prototype Clone();
    public abstract string GetInfo();
    public abstract void ChangeId(int id);

}