using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetColor
{
    public string Color { get; }

    private PetColor(string color)
    {
        Color = color;
    }

    public static Result<PetColor> Create(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<PetColor>("Напишите цвет");

        var petColor = new PetColor(color);
        
        return Result.Success(petColor);
    }
};