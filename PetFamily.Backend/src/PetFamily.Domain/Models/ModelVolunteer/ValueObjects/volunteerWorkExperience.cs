using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record VolunteerWorkExperience
{
    public int WorkExperience { get; }

    private VolunteerWorkExperience(int workExperience)
    {
        WorkExperience = workExperience;
    }

    public static Result<VolunteerWorkExperience> Create(int workExperience)
    {
        if (workExperience <= 0)
            return Result.Failure<VolunteerWorkExperience>("Опыт не может быть отрицательным");
        
        var volunteerWorkExperience = new VolunteerWorkExperience(workExperience);
        
        return Result.Success(volunteerWorkExperience);
    }
};