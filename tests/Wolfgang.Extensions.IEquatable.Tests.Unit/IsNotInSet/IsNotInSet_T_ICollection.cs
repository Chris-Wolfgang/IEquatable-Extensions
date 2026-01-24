#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsNotInSet;

// ReSharper disable once InconsistentNaming
public class IsNotInSet_T_ICollection
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_T_is_found_at_first_position_returns_false()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 12345678, 99999999, 88888888, 77777777 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_T_is_found_at_middle_position_returns_false()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 99999999, 12345678, 88888888, 77777777 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_T_is_found_at_last_position_returns_false()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 99999999, 88888888, 77777777, 12345678 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_T_is_not_found_in_collection_returns_true()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 99999999, 88888888, 77777777, 66666666 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_collection_is_empty_returns_true()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int>();
        Assert.True(sut.IsNotInSet(set));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_collection_contains_null_returns_false()
    {
        int? sut = null!;
        ICollection<int?> set = new List<int?> { 11111, null, 22222, 33333 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_collection_does_not_contain_null_returns_true()
    {
        int? sut = null!;
        ICollection<int?> set = new List<int?> { 11111, 22222, 33333 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_collection_is_empty_returns_true()
    {
        int? sut = null!;
        ICollection<int?> set = new List<int?>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_found_in_collection_returns_false()
    {
        int? sut = 5;
        ICollection<int?> set = new List<int?> { 10, 5, 20, 30 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_not_found_in_collection_returns_true()
    {
        int? sut = 5;
        ICollection<int?> set = new List<int?> { 10, 20, 30, 40 };
        Assert.True(sut.IsNotInSet(set));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_collection_contains_null_returns_false()
    {
        string sut = null!;
        ICollection<string> set = new List<string> { "test1", null!, "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_collection_does_not_contain_null_returns_true()
    {
        string sut = null!;
        ICollection<string> set = new List<string> { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_collection_is_empty_returns_true()
    {
        string sut = null!;
        ICollection<string> set = new List<string>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_empty_and_collection_contains_empty_returns_false()
    {
        string sut = string.Empty;
        ICollection<string> set = new List<string> { "test1", string.Empty, "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_empty_and_collection_does_not_contain_empty_returns_true()
    {
        string sut = string.Empty;
        ICollection<string> set = new List<string> { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_found_in_collection_returns_false()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { "test1", "test string", "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_not_found_in_collection_returns_true()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_collection_is_empty_returns_true()
    {
        string sut = "test string";
        ICollection<string> set = new List<string>();
        Assert.True(sut.IsNotInSet(set));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_collection_contains_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> { new IEquatableTestClass(1111), null!, new IEquatableTestClass(2222) };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_collection_does_not_contain_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> { new IEquatableTestClass(1111), new IEquatableTestClass(2222), new IEquatableTestClass(3333) };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_collection_is_empty_returns_true()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_found_by_value_equality_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> { new IEquatableTestClass(1111), new IEquatableTestClass(3333), new IEquatableTestClass(2222) };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_not_found_in_collection_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> { new IEquatableTestClass(1111), new IEquatableTestClass(2222), new IEquatableTestClass(4444) };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_collection_is_empty_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass>();
        Assert.True(sut.IsNotInSet(set));
    }



    // ---------------------------------   ArgumentNullException   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_set_is_null_throws_ArgumentNullException()
    {
        var sut = 12345678;
        ICollection<int> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }
}
