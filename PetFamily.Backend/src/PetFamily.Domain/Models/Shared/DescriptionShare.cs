using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.Shared;

public record DescriptionShare
{
    public string Description { get; }

    private DescriptionShare(string description)
    {
        Description = description;
    }

    public static Result<DescriptionShare> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<DescriptionShare>("Описание не должно быть пустым");

        var descriptionShare = new DescriptionShare(description);
        
        return Result.Success(descriptionShare);
    }
};