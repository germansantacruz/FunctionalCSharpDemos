namespace D05Functions.Validation;

public interface IDateTimeService
{
    DateTime UtcNow { get; }
}

public class DefaultDateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
