namespace AbstractFactory2.Controls;

public class Button2(string? text) : AbstractButton(
    text is null
    ? "<non>"
    : "<" + text.ToLower() + ">")
{
}