namespace Domain.ValueObject;

public abstract class ValueObject<T>
{
    public abstract T Value { get; }
}