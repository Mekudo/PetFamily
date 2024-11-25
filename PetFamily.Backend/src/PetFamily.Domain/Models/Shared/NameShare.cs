using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.Shared;

public record NameShare
{
    public string Name { get; }

    private NameShare(string name)
    {
        Name = name;
    }

    public static Result<NameShare> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<NameShare>("Кличка не указана");
        
        var petName = new NameShare(name);
        
        return Result.Success(petName);
    }
}