using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetWeight
{
    public int Weight { get; }

    private PetWeight(int weight)
    {
        Weight = weight;
    }

    public static Result<PetWeight> Create(int weight)
    {
        if (weight < 0)
            return Result.Failure<PetWeight>("Вес не может быть отрицательным");
        
        var petWeight = new PetWeight(weight);
        
        return Result.Success(petWeight);
    }
};