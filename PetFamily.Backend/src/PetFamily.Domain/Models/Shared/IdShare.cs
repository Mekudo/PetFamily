namespace PetFamily.Domain.Models.Shared;

public record IdShare
{
    public Guid Id { get; }

    private IdShare(Guid id)
    {
        Id = id;
    }

    public static IdShare Create(Guid id)
    {
        var petId = new IdShare(id);
        
        return petId;
    }
};