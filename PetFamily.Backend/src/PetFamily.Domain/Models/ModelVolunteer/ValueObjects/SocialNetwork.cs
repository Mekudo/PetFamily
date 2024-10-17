using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.ModelVolunteer.ValueObjects;

public class SocialNetwork
{
    private string Title { get; }

    private string Link { get; }

    private SocialNetwork(string title, string link)
    {
        Title = title;
        Link = link;
    }

    public Result<SocialNetwork> Create(string title, string link)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Failure<SocialNetwork>("Название не указано");

        if (string.IsNullOrWhiteSpace(link))
            return Result.Failure<SocialNetwork>("Ссылка не указана");

        var socialNetwork = new SocialNetwork(title, link);

        return Result.Success(socialNetwork);
    }
}