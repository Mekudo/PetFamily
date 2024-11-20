using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record FIO
{
    public string Name { get; }

    public string MiddleName { get; }

    public string SurName { get; }

    private FIO(string name, string middleName, string surName)
    {
        Name = name;
        MiddleName = middleName;
        SurName = surName;
    }

    public static Result<FIO> Create(string name, string middleName, string surName)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<FIO>("Имя не указано");

        if (string.IsNullOrWhiteSpace(middleName))
            return Result.Failure<FIO>("Фамилия не указана");

        if (string.IsNullOrWhiteSpace(surName))
            return Result.Failure<FIO>("Отчество не указано");

        var fio = new FIO(name, middleName, surName);

        return Result.Success(fio);
    }
}