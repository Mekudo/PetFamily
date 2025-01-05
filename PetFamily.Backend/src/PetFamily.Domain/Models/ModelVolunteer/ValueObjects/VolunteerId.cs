namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record VolunteerId
{
    public VolunteerId(){}
    public Guid Id { get; }

    public VolunteerId(Guid id)
    {
        Id = id;
    }
};