using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetAddress
{
    public string City { get; }
    
    public string Street { get; }
    
    public int HouseNumber { get; }

    private PetAddress(string city, string street, int houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }

    public static Result<PetAddress> Create(string city, string street, int houseNumber)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<PetAddress>("Укажите город");
        
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<PetAddress>("Укажите улицу");
        
        if (houseNumber <= 0)
            return Result.Failure<PetAddress>("Неправильный формат номера дома");
        
        var petAddress = new PetAddress(city, street, houseNumber);
        
        return Result.Success(petAddress);
    }
};