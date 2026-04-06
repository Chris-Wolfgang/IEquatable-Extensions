using System.Diagnostics.CodeAnalysis;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

[ExcludeFromCodeCoverage]
// ReSharper disable once InconsistentNaming
internal class IEquatableTestClass(int value) : IEquatable<IEquatableTestClass>
{
    private int Value { get; } = value;

    public bool Equals(IEquatableTestClass other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((IEquatableTestClass)obj);
    }

    public override int GetHashCode() => Value;
}