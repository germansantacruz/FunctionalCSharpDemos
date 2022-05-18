using System.Text.RegularExpressions;

namespace D05Functions.Validation;

public class BicFormatValidator : IValidator<MakeTransfer>
{
    static readonly Regex regex = new Regex("^[A-Z]{6}[A-Z1-9]{5}$");
    public bool IsValid(MakeTransfer transfer)
    => regex.IsMatch(transfer.Bic);
}
public class DateNotPastValidatorOld : IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer transfer)
    => (DateTime.UtcNow.Date <= transfer.Date.Date);
}

public class DateNotPastValidatorOld2 : IValidator<MakeTransfer>
{
    private readonly IDateTimeService dateService;

    public DateNotPastValidatorOld2(IDateTimeService dateService)
    {
        this.dateService = dateService;
    }
    public bool IsValid(MakeTransfer transfer)
    => dateService.UtcNow.Date <= transfer.Date.Date;
}

public record DateNotPastValidator(DateTime Today) : IValidator<MakeTransfer>
{
    public bool IsValid(MakeTransfer transfer)
    => Today <= transfer.Date.Date;
}