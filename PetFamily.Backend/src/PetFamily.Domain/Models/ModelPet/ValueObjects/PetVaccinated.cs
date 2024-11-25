using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetVaccinated
{
    public bool IsVaccinated { get; }

    private PetVaccinated(bool isVaccinated)
    {
        IsVaccinated = isVaccinated;
    }

    public static Result<PetVaccinated> Create(bool isVaccinated)
    {
        var petVaccinated = new PetVaccinated(isVaccinated);
        
        return Result.Success(petVaccinated);
    }
};