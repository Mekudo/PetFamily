using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetCastrated
{
    public bool IsCastrated { get; }

    private PetCastrated(bool isCastrated)
    {
        IsCastrated = isCastrated;
    }

    public static Result<PetCastrated> CreatePetCastrated(bool isCastrated)
    {
        var petCastrated = new PetCastrated(isCastrated);
        
        return Result.Success(petCastrated);
    }
}