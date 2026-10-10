using Xunit;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

/// <summary>
/// Exercises every member of the <see cref="IEquatableTestClass"/> test double, so the
/// equality the IsInSet / IsNotInSet tests rely on is itself verified.
/// </summary>
// ReSharper disable once InconsistentNaming
public class IEquatableTestClassTests
{
    // The null arrives as theory data so the analyzers' flow analysis cannot fold the
    // call to a constant (CA1508) - the point is to run the null branch of Equals.
    [Theory]
    [InlineData(null)]
    public void Equals_IEquatableTestClass_when_other_is_null_returns_false(object? other)
    {
        var sut = new IEquatableTestClass(3333);

        Assert.False(sut.Equals(other as IEquatableTestClass));
    }



    [Fact]
    public void Equals_IEquatableTestClass_when_other_is_same_instance_returns_true()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.True(sut.Equals(sut));
    }



    [Fact]
    public void Equals_IEquatableTestClass_when_other_has_same_value_returns_true()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.True(sut.Equals(new IEquatableTestClass(3333)));
    }



    [Fact]
    public void Equals_IEquatableTestClass_when_other_has_different_value_returns_false()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.False(sut.Equals(new IEquatableTestClass(1111)));
    }



    [Theory]
    [InlineData(null)]
    public void Equals_object_when_obj_is_null_returns_false(object? obj)
    {
        var sut = new IEquatableTestClass(3333);

        Assert.False(sut.Equals(obj));
    }



    [Fact]
    public void Equals_object_when_obj_is_same_instance_returns_true()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.True(sut.Equals((object)sut));
    }



    [Fact]
    public void Equals_object_when_obj_is_equal_instance_returns_true()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.True(sut.Equals((object)new IEquatableTestClass(3333)));
    }



    [Fact]
    public void Equals_object_when_obj_is_different_type_returns_false()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.False(sut.Equals((object)3333));
    }



    [Fact]
    public void GetHashCode_returns_the_wrapped_value()
    {
        var sut = new IEquatableTestClass(3333);

        Assert.Equal(3333, sut.GetHashCode());
    }
}
