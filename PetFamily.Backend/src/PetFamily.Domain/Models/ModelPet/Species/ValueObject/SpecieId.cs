namespace PetFamily.Domain.Models.ModelPet.Species.ValueObject;

public record SpecieId
{
    public Guid Id { get; }

    public SpecieId(Guid id)
    {
        Id = id;
    }
};