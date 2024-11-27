using CSharpFunctionalExtensions;
using PetFamily.Domain.Models.Shared;
using PetFamily.Domain.Models.ModelPet.ModelBreed;
using PetFamily.Domain.Models.ModelPet.Species.ValueObject;

namespace PetFamily.Domain.Models.ModelPet.Species;

public class Specie : Shared.Entity<SpecieId>
{
    private Specie(SpecieId specieId) : base(specieId)
    {
        
    }
    
    public NameShare Name { get; } = default!;
    
    public IReadOnlyList<Breed> Breeds { get; private set; } = [];

    private Specie(SpecieId specieId, NameShare name, IReadOnlyList<Breed> breeds) : base(specieId)
    {
        Name = name;
        Breeds = breeds;
    }
}