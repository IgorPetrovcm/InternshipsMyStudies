namespace AbstractFactory2.Controls;

public class Label2(string? text) : AbstractLabel(
    text is null
    ? "\"non\""
    : "\"" + text.ToLower() + "\"")
{
}