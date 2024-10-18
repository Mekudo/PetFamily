using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetPhoto
{
    private string Path { get; }
    
    private bool IsMainPhoto { get; }

    private PetPhoto(string path, bool isMainPhoto)
    {
        Path = path;
        IsMainPhoto = isMainPhoto;
    }

    public static Result<PetPhoto> Create(string path, bool isMainPhoto)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Result.Failure<PetPhoto>("Путь к фото не указан");
        
        var petPhoto = new PetPhoto(path, isMainPhoto);
        
        return Result.Success(petPhoto);
    }
};