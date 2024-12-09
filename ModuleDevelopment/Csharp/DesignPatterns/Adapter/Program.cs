namespace Adapter;

public static class Program
{
    public static void Main()
    {
        (char, int, int)[] set =
        [
            ('+', 2, 3),
            ('*', 2, 3),
            ('+', 10, 10),
            ('*', 10, 10)
        ];

        var targets = new Target[4];

        for (var i = 0; i < set.Length; i++)
        {
            targets[i] = set[i].Item1 switch
            {
                '+' => new ConcreteTarget(set[i].Item2, set[i].Item3),
                '*' => new Adapter(set[i].Item2, set[i].Item3),
                _ => targets[i]
            };
        }

        foreach (var target in targets)
        {
            Console.WriteLine($"A: {target.GetA()}, B: {target.GetB()}. Operation: {target.Request()}");
        }
    }
}