using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.ModelPet.ModelBreed.ValueObject;
using PetFamily.Domain.Models.ModelPet.Species;
using PetFamily.Domain.Models.ModelPet.Species.ValueObject;
using PetFamily.Domain.Models.Shared;

namespace PetFamily.Domain.Models.ModelPet.ModelBreed;

public class Breed : Shared.Entity<BreedId>
{
    public NameShare Name { get; private set; } = default!;

    public DescriptionShare Description { get; private set; } = default!;
    
    public SpecieId SpecieId { get; private set; } = default!;
    
    public Specie Specie { get; private set; } = default!;
    
    private Breed(BreedId breedId) : base(breedId)
    {
        
    }

    private Breed(BreedId breedId, NameShare name, DescriptionShare description, SpecieId specieId) : base(breedId)
    {
        Name = name;
        Description = description;
        SpecieId = specieId;
    }

    public static Result<Breed> Create(BreedId id, NameShare nameShare, DescriptionShare description, SpecieId specieId)
    {
        var breed = new Breed(id, nameShare, description, specieId);
        
        return Result.Success(breed);
    }
}