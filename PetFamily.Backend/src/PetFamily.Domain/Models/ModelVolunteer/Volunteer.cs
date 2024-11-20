using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ModelPet;
using PetFamily.Domain.Models.ModelPet.Enum;
using PetFamily.Domain.Models.ModelVolunteer.ValueObjects;
using PetFamily.Domain.Models.Shared;

namespace PetFamily.Domain.Models.ModelVolunteer;

public  class Volunteer : Shared.Entity<Guid>
{
    private Volunteer(Guid id) : base(id)
    {
        
    }
    
    public FIO FIO { get; private set; } = default!;

    public string Email { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public int WorkExperience { get; private set; } = default!;

    public string PhoneNumber { get; private set; } = default!;

    public List<SocialNetwork> SocialNetwork { get; private set; } = [];

    public List<BankRequisites> BankRequisites { get; private set; } = [];

    public IReadOnlyList<Pet> Pets { get; private set; } = default!;

    public int AmountOfPetsFoundHome()
    {
        return Pets.Count(pet => pet.SupportStatus == SupportStatus.FoundHome);
    }

    public int AmountOfPetsSearchingHome()
    {
        return Pets.Count(pet => pet.SupportStatus == SupportStatus.SearchingHome);
    }

    public int AmountOfPetsNeedHelp()
    {
        return Pets.Count(pet => pet.SupportStatus == SupportStatus.NeedHelp);
    }

    public Volunteer(
        Guid id,
        FIO fIO,
        string email,
        string description,
        int workExpirience,
        string phoneNumber,
        List<SocialNetwork> socialNetworks,
        List<BankRequisites> bankRequisites,
        IReadOnlyList<Pet> pets
        ) : base(id)
    {
        FIO = fIO;
        Email = email;
        Description = description;
        WorkExperience = workExpirience;
        PhoneNumber = phoneNumber;
        SocialNetwork = socialNetworks;
        BankRequisites = bankRequisites;
        Pets = pets;
    }

    public static Result<Volunteer> Create(
        Guid id,
        FIO fIO,
        string email,
        string description,
        int workExpirience,
        string phoneNumber,
        List<SocialNetwork> socialNetworks,
        List<BankRequisites> bankRequisites,
        IReadOnlyList<Pet> pets)
    {
        if (fIO == null)
            Result.Failure<Volunteer>("ФИО не указано");

        if (string.IsNullOrWhiteSpace(email))
            Result.Failure<Volunteer>("Электронна почта не указана");

        if (string.IsNullOrWhiteSpace(description))
            Result.Failure<Volunteer>("Описание не указано");

        if (workExpirience > 100 || workExpirience < 0)
            Result.Failure<Volunteer>("Некорректно указан опыт работы");

        if (string.IsNullOrWhiteSpace(phoneNumber))
            Result.Failure<Volunteer>("Номер телефона не указан");

        var volunteer = new Volunteer(
            id,
            fIO,
            email,
            description,
            workExpirience,
            phoneNumber,
            socialNetworks,
            bankRequisites,
            pets);

        return Result.Success(volunteer);
    }
}
