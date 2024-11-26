namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetId
{
    public Guid Id { get; }

    public PetId(Guid id)
    {
        Id = id;
    }
};