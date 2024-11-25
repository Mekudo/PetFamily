using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ModelPet;
using PetFamily.Domain.Models.ModelPet.Enum;
using PetFamily.Domain.Models.ModelVolunteer.ValueObjects;
using PetFamily.Domain.Models.Shared;

namespace PetFamily.Domain.Models.ModelVolunteer;

public  class Volunteer : Shared.Entity<VolunteerId>
{
    private Volunteer(VolunteerId id) : base(id)
    {
        
    }
    
    public FIO FIO { get; private set; } = default!;

    public VolunteerEmail Email { get; private set; } = default!;

    public DescriptionShare Description { get; private set; } = default!;

    public VolunteerWorkExperience WorkExperience { get; private set; } = default!;

    public Phone PhoneNumber { get; private set; } = default!;

    public IReadOnlyList<SocialNetwork> SocialNetwork { get; private set; } = [];

    public IReadOnlyList<BankRequisites> BankRequisites { get; private set; } = [];

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
        VolunteerId id,
        FIO fIO,
        VolunteerEmail email,
        DescriptionShare description,
        VolunteerWorkExperience workExpirience,
        Phone phoneNumber,
        IReadOnlyList<SocialNetwork> socialNetworks,
        IReadOnlyList<BankRequisites> bankRequisites,
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
        VolunteerId idShare,
        FIO fIO,
        VolunteerEmail email,
        DescriptionShare description,
        VolunteerWorkExperience workExpirience,
        Phone phoneNumber,
        IReadOnlyList<SocialNetwork> socialNetworks,
        IReadOnlyList<BankRequisites> bankRequisites,
        IReadOnlyList<Pet> pets)
    {
        var volunteer = new Volunteer(
            idShare,
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
