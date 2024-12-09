using System.Runtime.InteropServices;

namespace Domain.ValueObjects;

public abstract class ValueObjects
{
    protected static bool EqualOperator(ValueObjects left, ValueObjects right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }
        return left?.Equals(right!) != false;
    }

    protected static bool NotEqualOperator(ValueObjects left, ValueObjects right)
    {
        return !EqualOperator(left, right);
    }
    protected abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObjects)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var component in GetEqualityComponents())
        {
            hash.Add(component);
        }
        return hash.ToHashCode();
    }
}