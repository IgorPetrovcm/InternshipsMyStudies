namespace AbstractFactory2.Controls;

public class Label1(string? text) : AbstractLabel(
    text is null
    ? "=NON="
    : "=" + text.ToUpper() + "=")
{
}