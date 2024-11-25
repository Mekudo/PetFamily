namespace PetFamily.Domain.Models.ModelPet.ModelBreed.ValueObject;

public record BreedId
{
    public Guid Id { get; }

    private BreedId(Guid id)
    {
        Id = id;
    }

    public static BreedId Create(Guid id)
    {
        var breedId = new BreedId(id);
        
        return breedId;
    }
};