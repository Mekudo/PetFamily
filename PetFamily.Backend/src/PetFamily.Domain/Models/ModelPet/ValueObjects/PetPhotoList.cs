namespace PetFamily.Domain.Models.ModelPet.ValueObjects;

public record PetPhotoList
{
    public IReadOnlyList<PetPhoto> PetPhotos { get; } = new List<PetPhoto>();
    
    private PetPhotoList() { }

    public PetPhotoList(IReadOnlyList<PetPhoto> petPhotos)
    {
        PetPhotos = petPhotos.ToList();
    }
};