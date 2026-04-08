#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsInSet;

// ReSharper disable once InconsistentNaming
public class IsInSet_T_IEnumerable
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_int_and_set_is_null_throws_ArgumentNullException()
    {
        var sut = 12345678;
        IEnumerable<int> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_int_and_set_is_empty_returns_false()
    {
        var sut = 12345678;
        IEnumerable<int> set = Enumerable.Empty<int>();
        Assert.False(sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_int_and_set_contains_T_returns_true()
    {
        var sut = 12345678;
        IEnumerable<int> set = new[] { 12345678 };
        Assert.True(sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_int_and_set_does_not_contain_T_returns_false()
    {
        var sut = 12345678;
        IEnumerable<int> set = new[] { 11111111, 22222222 };
        Assert.False(sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_int_and_set_contains_multiple_items_including_T_returns_true()
    {
        var sut = 12345678;
        IEnumerable<int> set = new[] { 11111111, 12345678, 22222222 };
        Assert.True(sut.IsInSet(set));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_string_and_set_is_null_throws_ArgumentNullException()
    {
        string sut = "test string";
        IEnumerable<string> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_string_and_set_contains_T_returns_true()
    {
        string sut = "test string";
        IEnumerable<string> set = new[] { "test string" };
        Assert.True(sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_string_and_set_does_not_contain_T_returns_false()
    {
        string sut = "test string";
        IEnumerable<string> set = new[] { "other string", "another string" };
        Assert.False(sut.IsInSet(set));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_Class_and_set_is_null_throws_ArgumentNullException()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEnumerable<IEquatableTestClass> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_Class_and_set_contains_equal_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEnumerable<IEquatableTestClass> set = new[] { new IEquatableTestClass(3333) };
        Assert.True(sut.IsInSet(set));
    }



    [Fact]
    public void IsInSet_T_IEnumerable_when_T_is_Class_and_set_does_not_contain_equal_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEnumerable<IEquatableTestClass> set = new[]
        {
            new IEquatableTestClass(1111),
            new IEquatableTestClass(2222)
        };
        Assert.False(sut.IsInSet(set));
    }
}
