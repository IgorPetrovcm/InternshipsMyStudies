namespace AbstractFactory2.Controls;

public class Button1(string? text) : AbstractButton(
    text is null
        ? "[NON]"
        : "[" + text.ToUpper() + "]")
{
}