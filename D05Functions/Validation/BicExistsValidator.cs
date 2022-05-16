using System.Text.RegularExpressions;

namespace D05Functions.Validation;

public class BicFormatValidator : IValidator<MakeTransfer>
{
    static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
    public bool IsValid(MakeTransfer transfer)
    => regex.IsMatch(transfer.Bic);
}
public class DateNotPastValidator : IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer transfer)
    => (DateTime.UtcNow.Date <= transfer.Date.Date);
}
