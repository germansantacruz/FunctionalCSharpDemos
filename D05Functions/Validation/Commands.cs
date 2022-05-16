namespace D05Functions.Validation;
public abstract record Command(DateTime Timestamp);

public record MakeTransfer
    (
    Guid DebitedAccountId,

    string Beneficiary,
    string Iban,
    string Bic,

    DateTime Date,
    decimal Amount,
    string Reference,

    DateTime Timestamp = default
    ) : Command(Timestamp)
{
    internal static MakeTransfer Dummy
        => new(default, default, default, default, default, default, default);
}
