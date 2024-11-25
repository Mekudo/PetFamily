using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetHealth
{
    public string HealthInfo { get; }

    private PetHealth(string healthInfo)
    {
        HealthInfo = healthInfo;
    }

    public static Result<PetHealth> Create(string healthInfo)
    {
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Result.Failure<PetHealth>("Укажите здоровье питомца");
        
        var petHealth = new PetHealth(healthInfo);
        
        return Result.Success(petHealth);
    }
};