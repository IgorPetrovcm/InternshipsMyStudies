namespace FactoryMethod3;

public abstract class AnimalCreator(Dictionary<int, Func<string?, Animal>> restriction)
{
    public Animal CreateAnimal(int ind, string? name)
    {
        return restriction[ind].Invoke(name);
    }

    public Animal[] GetZoo(int[] inds, string[] names)
    {
        var animalFeatures = inds.Zip(names, Tuple.Create).ToList();

        return animalFeatures.Aggregate(new List<Animal>(),
            (animals, tuple) =>
            {
                animals.Add(restriction[tuple.Item1].Invoke(tuple.Item2));
                return animals;
            }).ToArray();

    }
    
}