namespace FactoryMethod3;

internal static class AnimalCreationRestriction
{
    private static Dictionary<AnimalTypeEnum, Dictionary<int, Func<string?, Animal>>>? restrictions;

    private static Object lockObj = new ();

    public static Dictionary<int, Func<string?, Animal>> GetCreateRestrict(AnimalTypeEnum type)
    {
        if (restrictions is not null) return restrictions[type];
        lock (lockObj)
        {
            restrictions ??= new Dictionary<AnimalTypeEnum, Dictionary<int, Func<string?, Animal>>>()
            {
                {
                    AnimalTypeEnum.Ape, new Dictionary<int, Func<string?, Animal>>()
                    {
                        { 0, (string? name) => new Gorilla(name) },
                    }
                },
                {
                    AnimalTypeEnum.Cat, new Dictionary<int, Func<string?, Animal>>()
                    {
                        { 0, (string? name) => new Lion(name) }
                    }
                }
            };
        }

        return restrictions[type];
    }
}