using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record VolunteerEmail
{
    public string Email { get; }

    private VolunteerEmail(string email)
    {
        Email = email;
    }

    public static Result<VolunteerEmail> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<VolunteerEmail>("Укажите email");

        var volunteerEmail = new VolunteerEmail(email);
        
        return Result.Success(volunteerEmail);
    }
};