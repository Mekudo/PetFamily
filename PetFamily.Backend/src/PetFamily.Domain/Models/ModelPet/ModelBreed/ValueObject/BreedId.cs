namespace PetFamily.Domain.Models.ModelPet.ModelBreed.ValueObject;

public record BreedId
{
    public BreedId(){}
    public Guid Id { get; }

    public BreedId(Guid id)
    {
        Id = id;
    }
};