namespace PetFamily.Domain.Models.ModelPet.Species.ValueObject;

public record SpecieId
{
    public Guid Id { get; }

    private SpecieId(Guid id)
    {
        Id = id;
    }

    public static SpecieId Create(Guid id)
    {
        var specieId = new SpecieId(id);
        
        return specieId;
    }
};