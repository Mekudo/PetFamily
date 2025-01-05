namespace PetFamily.Domain.Models.Shared;

public record BankRequisitesList
{
    public IReadOnlyList<BankRequisites> BankRequisites { get; } = new List<BankRequisites>();
    
    private BankRequisitesList() { }

    public BankRequisitesList(IReadOnlyList<BankRequisites> bankRequisites)
    {
        BankRequisites = bankRequisites.ToList();
    }
};