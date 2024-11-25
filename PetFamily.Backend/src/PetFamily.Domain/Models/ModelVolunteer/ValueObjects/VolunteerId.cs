namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record VolunteerId
{
    public Guid Id { get; }

    private VolunteerId(Guid id)
    {
        Id = id;
    }

    public static VolunteerId Create(Guid id)
    {
        var volunteerId = new VolunteerId(id);
        
        return volunteerId;
    }
};