namespace Domain.ValueObject;

public abstract class ValueObject<T>
{
    public abstract T Value { get; }

    public override bool Equals(object? obj)
    {
        if (obj is not ValueObject<T> other) return false;
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }
    
    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
}