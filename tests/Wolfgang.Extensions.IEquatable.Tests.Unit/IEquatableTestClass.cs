using System.Diagnostics.CodeAnalysis;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

[ExcludeFromCodeCoverage]
// ReSharper disable once InconsistentNaming
internal class IEquatableTestClass(int value) : IEquatable<IEquatableTestClass>
{
    private int Value { get; } = value;

#if NET5_0_OR_GREATER
    public bool Equals(IEquatableTestClass? other)
#else
    public bool Equals(IEquatableTestClass? other)
#endif
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