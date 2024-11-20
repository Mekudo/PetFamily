using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Models.Shared;

public record BankRequisites
{
    public string NameOfBank { get; }

    public string BankIdentificationCode { get; }

    public string CorrespondentAccount { get; }

    private BankRequisites(string nameOfBank, string bankIdentificationCode, string correspondentAccount)
    {
        NameOfBank = nameOfBank;
        BankIdentificationCode = bankIdentificationCode;
        CorrespondentAccount = correspondentAccount;
    }

    public static Result<BankRequisites> Create(string nameOfBank, string bankIdentificationCode, string correspondentAccount)
    {
        if (string.IsNullOrWhiteSpace(nameOfBank))
            return Result.Failure<BankRequisites>("Название банка не указано");

        if (string.IsNullOrWhiteSpace(bankIdentificationCode))
            return Result.Failure<BankRequisites>("Бик не указан");

        if (bankIdentificationCode.Length is not 9)
            return Result.Failure<BankRequisites>("Неправильное количество цифр в БИК");

        if (string.IsNullOrWhiteSpace(correspondentAccount))
            return Result.Failure<BankRequisites>("Не указан корреспондентский счет");

        if (correspondentAccount.Length is not 20)
            return Result.Failure<BankRequisites>("Неправильное количество цифр в корреспондентском счету");

        var requisite = new BankRequisites(nameOfBank, bankIdentificationCode, correspondentAccount);

        return Result.Success(requisite);
    }
};