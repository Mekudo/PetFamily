using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.Shared;

public record Phone
{
    public string PhoneNumber { get; }

    private Phone(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public static Result<Phone> Create(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length < 5)
            return Result.Failure<Phone>("Неправильный номер телефона");
            
        var phone = new Phone(phoneNumber);
            
        return Result.Success(phone);
        }
};