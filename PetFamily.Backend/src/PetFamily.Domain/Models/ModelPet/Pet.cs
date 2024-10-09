using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ModelPet.Enum;
using PetFamily.Domain.Models.ModelPet.ValueObjects;

namespace PetFamily.Domain.Models.ModelPet;

public class Pet
{
    private Pet(){ }
    
    public Guid Id { get; private set; } = default!;
    
    public string Name { get; private set; } = default!;
    
    public string Species { get; private set; } = default!;
    
    public string Description { get; private set; } = default!;
    
    public string Breed { get; private set; } = default!;
    
    public string Color { get; private set; } = default!;

    public string HealthInfo { get; private set; } = default!;
    
    public string Address { get; private set; } = default!;
    
    public int Weight { get; private set; }
    
    public int Height { get; private set; }
    
    public string PhoneNumber { get; private set; } = default!;
    
    public bool IsCastrated { get; private set; }
    
    public DateOnly DateOfBirth { get; private set; } = default!;
    
    public bool IsVaccinated { get; private set; }
    
    public SupportStatus SupportStatus { get; private set; } = default!;
    
    public List<BankRequisites> BankRequisites { get; private set; } = [];
    
    public DateTime DateOfCreated { get; private set; } = default!;

    public Pet(
        Guid id, 
        string name, 
        string species, 
        string description,
        string breed,
        string color,
        string healthInfo,
        string address,
        int weight,
        int height,
        string phoneNumber,
        bool isCastrated,
        DateOnly dateOfBirth,
        bool isVaccinated,
        SupportStatus supportStatus,
        List<BankRequisites> bankRequisites,
        DateTime dateOfCreated)
    {
        Id = id;
        Name = name;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumber = phoneNumber;
        IsCastrated = isCastrated;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVaccinated;
        SupportStatus = supportStatus;
        BankRequisites = bankRequisites;
        DateOfCreated = dateOfCreated;
    }

    public static Result<Pet> Create(
        Guid id,
        string name,
        string species,
        string description,
        string breed,
        string color,
        string healthInfo,
        string address,
        int weight,
        int height,
        string phoneNumber,
        bool isCastrated,
        DateOnly dateOfBirth,
        bool isVaccinated,
        SupportStatus supportStatus,
        List<BankRequisites> bankRequisites,
        DateTime dateOfCreated)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Pet>("Кличка не указана");

        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Pet>("Описание не указано");
        
        if (string.IsNullOrWhiteSpace(species))
            return Result.Failure<Pet>("Вид не указан");
        
        if (string.IsNullOrWhiteSpace(breed))
            return Result.Failure<Pet>("Порода не указана");
        
        if (string.IsNullOrWhiteSpace(color))
            return Result.Failure<Pet>("Окрас не указан");
        
        if (string.IsNullOrWhiteSpace(healthInfo))
            return Result.Failure<Pet>("Информация о здоровье не указана");
        
        if (string.IsNullOrWhiteSpace(address))
            return Result.Failure<Pet>("Адрес не указан");
        
        if (weight <= 0)
            return Result.Failure<Pet>("Вес не может быть меньше нуля");
        
        if (height <= 0)
            return Result.Failure<Pet>("Рост не может быть меньше нуля");
        
        if(string.IsNullOrWhiteSpace(phoneNumber))
            return Result.Failure<Pet>("Номер телефона не указан");

        var pet = new Pet(
            id,
            name,
            species,
            description,
            breed,
            color,
            healthInfo,
            address,
            weight,
            height,
            phoneNumber,
            isCastrated,
            dateOfBirth,
            isVaccinated,
            supportStatus,
            bankRequisites,
            dateOfCreated
        );
        
        return Result.Success(pet);
    }
}