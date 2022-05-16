namespace D05Functions.Validation;

public interface IValidator<T>
{
    bool IsValid(T t);
}
