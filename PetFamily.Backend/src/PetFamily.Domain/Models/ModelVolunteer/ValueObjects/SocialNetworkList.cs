namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public record SocialNetworkList
{
    public IReadOnlyList<SocialNetwork> SocialNetworks { get; } = new List<SocialNetwork>();
    
    private SocialNetworkList(){ }

    public SocialNetworkList(IReadOnlyList<SocialNetwork> socialNetworks)
    {
        SocialNetworks = socialNetworks.ToList();
    }
};