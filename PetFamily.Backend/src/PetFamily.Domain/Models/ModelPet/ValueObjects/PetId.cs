namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetId
{
    public Guid Id { get; }

    private PetId(Guid id)
    {
        Id = id;
    }

    public static PetId Create(Guid id)
    {
        var petId = new PetId(id);
        
        return petId;
    }
};