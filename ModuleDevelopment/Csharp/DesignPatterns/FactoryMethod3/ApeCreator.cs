namespace FactoryMethod3;

public class ApeCreator() : AnimalCreator(
    AnimalCreationRestriction.GetCreateRestrict(AnimalTypeEnum.Ape));