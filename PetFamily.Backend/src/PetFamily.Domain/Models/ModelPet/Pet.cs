using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ModelPet.Enum;
using PetFamily.Domain.Models.ModelPet.ValueObjects;
using PetFamily.Domain.Models.Shared;

namespace PetFamily.Domain.Models.ModelPet;

public class Pet : Shared.Entity<PetId>
{
    private Pet(PetId petId) : base(petId)
    {
        
    }
    
    public NameShare NameShare { get; private set; } = default!;
    
    public string Species { get; private set; } = default!;
    
    public DescriptionShare Description { get; private set; } = default!;
    
    public string Breed { get; private set; } = default!;
    
    public PetColor Color { get; private set; } = default!;

    public PetHealth HealthInfo { get; private set; } = default!;
    
    public PetAddress Address { get; private set; } = default!;
    
    public PetWeight Weight { get; private set; }
    
    public PetHeight Height { get; private set; }
    
    public Phone PhoneNumberNumber { get; private set; } = default!;
    
    public PetCastrated IsCastrated { get; private set; }
    
    public DateOnly DateOfBirth { get; private set; } = default!;
    
    public PetVaccinated IsVaccinated { get; private set; }
    
    public SupportStatus SupportStatus { get; private set; } = default!;
    
    public IReadOnlyList<BankRequisites> BankRequisites { get; private set; } = [];
    
    public DateTime DateOfCreated { get; private set; } = default!;

    public IReadOnlyList<PetPhoto> PetPhotos { get; private set; } = [];
    
    public Pet(
        PetId petId, 
        NameShare nameShare, 
        string species, 
        DescriptionShare description,
        string breed,
        PetColor color,
        PetHealth healthInfo,
        PetAddress address,
        PetWeight weight,
        PetHeight height,
        Phone phoneNumberNumber,
        PetCastrated isCastrated,
        DateOnly dateOfBirth,
        PetVaccinated isVaccinated,
        SupportStatus supportStatus,
        IReadOnlyList<BankRequisites> bankRequisites,
        DateTime dateOfCreated,
        IReadOnlyList<PetPhoto> petPhotos) : base(petId)
    {
        NameShare = nameShare;
        Species = species;
        Description = description;
        Breed = breed;
        Color = color;
        HealthInfo = healthInfo;
        Address = address;
        Weight = weight;
        Height = height;
        PhoneNumberNumber = phoneNumberNumber;
        IsCastrated = isCastrated;
        DateOfBirth = dateOfBirth;
        IsVaccinated = isVaccinated;
        SupportStatus = supportStatus;
        BankRequisites = bankRequisites;
        DateOfCreated = dateOfCreated;
        PetPhotos = petPhotos;
    }

    public static Result<Pet> Create(
        PetId petId,
        NameShare nameShare,
        string species,
        DescriptionShare description,
        string breed,
        PetColor color,
        PetHealth healthInfo,
        PetAddress address,
        PetWeight weight,
        PetHeight height,
        Phone phoneNumberNumber,
        PetCastrated isCastrated,
        DateOnly dateOfBirth,
        PetVaccinated isVaccinated,
        SupportStatus supportStatus,
        IReadOnlyList<BankRequisites> bankRequisites,
        DateTime dateOfCreated,
        IReadOnlyList<PetPhoto> petPhotos)
    {
        var pet = new Pet(
            petId,
            nameShare,
            species,
            description,
            breed,
            color,
            healthInfo,
            address,
            weight,
            height,
            phoneNumberNumber,
            isCastrated,
            dateOfBirth,
            isVaccinated,
            supportStatus,
            bankRequisites,
            dateOfCreated,
            petPhotos
        );
        
        return Result.Success(pet);
    }
}