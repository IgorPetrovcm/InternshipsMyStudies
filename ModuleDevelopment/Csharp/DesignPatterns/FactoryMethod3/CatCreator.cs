namespace FactoryMethod3;

public class CatCreator() : AnimalCreator(
    AnimalCreationRestriction.GetCreateRestrict(AnimalTypeEnum.Cat));