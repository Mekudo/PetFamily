using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetHeight
{
    public int Height { get; }

    private PetHeight(int height)
    {
        Height = height;
    }

    public static Result<PetHeight> Create(int height)
    {
        if (height < 0)
            return Result.Failure<PetHeight>("Рост не может быть отрицательным");
        
        var petHeight = new PetHeight(height);
        
        return Result.Success(petHeight);
    }
};