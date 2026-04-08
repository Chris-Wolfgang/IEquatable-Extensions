#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsNotInSet;

// ReSharper disable once InconsistentNaming
public class IsNotInSet_T_ICollection
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_set_is_null_throws_ArgumentNullException()
    {
        var sut = 12345678;
        ICollection<int> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_set_is_empty_returns_true()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_set_contains_T_returns_false()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 12345678 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_set_does_not_contain_T_returns_true()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 11111111, 22222222 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_int_and_set_contains_multiple_items_including_T_returns_false()
    {
        var sut = 12345678;
        ICollection<int> set = new List<int> { 11111111, 12345678, 22222222 };
        Assert.False(sut.IsNotInSet(set));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_set_is_null_throws_ArgumentNullException()
    {
        int? sut = 12345678;
        ICollection<int?> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_set_is_empty_returns_true()
    {
        int? sut = null;
        ICollection<int?> set = new List<int?>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_set_contains_null_returns_false()
    {
        int? sut = null;
        ICollection<int?> set = new List<int?> { null };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_null_and_set_does_not_contain_null_returns_true()
    {
        int? sut = null;
        ICollection<int?> set = new List<int?> { 11111, 22222 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_set_is_empty_returns_true()
    {
        int? sut = 12345678;
        ICollection<int?> set = new List<int?>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_set_contains_T_returns_false()
    {
        int? sut = 12345678;
        ICollection<int?> set = new List<int?> { 12345678 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_set_does_not_contain_T_returns_true()
    {
        int? sut = 12345678;
        ICollection<int?> set = new List<int?> { 11111111, 22222222 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_nullable_int_and_T_is_not_null_and_set_contains_null_and_T_returns_false()
    {
        int? sut = 12345678;
        ICollection<int?> set = new List<int?> { null, 12345678, 99999999 };
        Assert.False(sut.IsNotInSet(set));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_set_is_null_throws_ArgumentNullException()
    {
        string sut = "test string";
        ICollection<string> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_set_is_empty_returns_true()
    {
        string sut = null!;
        ICollection<string> set = new List<string>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_set_contains_null_returns_false()
    {
        string sut = null!;
        ICollection<string> set = new List<string> { null! };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_null_and_set_does_not_contain_null_returns_true()
    {
        string sut = null!;
        ICollection<string> set = new List<string> { "test1", "test2" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_empty_and_set_is_empty_returns_true()
    {
        string sut = string.Empty;
        ICollection<string> set = new List<string>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_empty_and_set_contains_empty_returns_false()
    {
        string sut = string.Empty;
        ICollection<string> set = new List<string> { string.Empty };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_is_empty_and_set_does_not_contain_empty_returns_true()
    {
        string sut = string.Empty;
        ICollection<string> set = new List<string> { "test1", "test2" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_set_is_empty_returns_true()
    {
        string sut = "test string";
        ICollection<string> set = new List<string>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_set_contains_T_returns_false()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { "test string" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_set_does_not_contain_T_returns_true()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { "other string", "another string" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_set_contains_multiple_items_including_T_returns_false()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { "other string", "test string", "another string" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_string_and_T_has_value_and_set_contains_null_and_empty_but_not_T_returns_true()
    {
        string sut = "test string";
        ICollection<string> set = new List<string> { null!, string.Empty, "other string" };
        Assert.True(sut.IsNotInSet(set));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_set_is_null_throws_ArgumentNullException()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_set_is_empty_returns_true()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_set_contains_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> { null! };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_null_and_set_does_not_contain_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> 
        { 
            new IEquatableTestClass(1111), 
            new IEquatableTestClass(2222) 
        };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_set_is_empty_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass>();
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_set_contains_equal_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> 
        { 
            new IEquatableTestClass(3333) 
        };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_set_does_not_contain_equal_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> 
        { 
            new IEquatableTestClass(1111), 
            new IEquatableTestClass(2222) 
        };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_set_contains_multiple_items_including_equal_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> 
        { 
            new IEquatableTestClass(1111), 
            new IEquatableTestClass(3333), 
            new IEquatableTestClass(2222) 
        };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ICollection_when_T_is_Class_and_T_is_not_null_and_set_contains_null_but_not_equal_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        ICollection<IEquatableTestClass> set = new List<IEquatableTestClass> 
        { 
            null!, 
            new IEquatableTestClass(1111), 
            new IEquatableTestClass(2222) 
        };
        Assert.True(sut.IsNotInSet(set));
    }
}
