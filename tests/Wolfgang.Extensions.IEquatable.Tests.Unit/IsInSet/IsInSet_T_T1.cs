#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsInSet;

// ReSharper disable once InconsistentNaming
public class IsInSet_T_T1
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsInSet_T_T1_when_T_is_int_and_T_and_T1_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 12345678;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_int_and_T_and_T1_are_different_values_returns_false()
    {
        var sut = 12345678;
        var t1 = 0;
        Assert.False(sut.IsInSet(t1));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_when_T_is_nullable_int_and_T_and_T1_are_both_null_returns_true()
    {
        int? sut = null!;
        int? t1 = null!;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_nullable_int_and_T_is_null_and_T1_is_not_null_returns_false()
    {
        int? sut = null!;
        int? t1 = 5;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_nullable_int_and_T_is_not_null_and_T1_is_null_returns_false()
    {
        int? sut = 5;
        int? t1 = null;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_nullable_int_and_T_is_not_null_and_T1_is_same_value_returns_true()
    {
        int? sut = 5;
        int? t1 = 5;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_nullable_int_and_T_is_not_null_and_T1_has_different_value_returns_false()
    {
        int? sut = 5;
        int? t1 = 10;
        Assert.False(sut.IsInSet(t1));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_null_and_T1_is_null_returns_true()
    {
        string sut = null!;
        string t1 = null!;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_null_and_T1_is_empty_returns_false()
    {
        string sut = null!;
        string t1 = string.Empty;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_null_and_T1_has_value_returns_false()
    {
        string sut = null!;
        string t1 = "test value";
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_empty_and_T1_is_null_returns_false()
    {
        string sut = string.Empty;
        string t1 = null!;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_empty_and_T1_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = string.Empty;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_is_empty_and_T1_has_value_returns_false()
    {
        string sut = string.Empty;
        string t1 = "test value";
        Assert.False(sut.IsInSet(t1));
    }




    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_has_value_and_T1_is_null_returns_false()
    {
        string sut = "test string";
        string t1 = null!;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_has_value_and_T1_is_empty_returns_false()
    {
        string sut = "test string";
        string t1 = string.Empty;
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_has_value_and_T1_has_same_value_returns_true()
    {
        string sut = "test string";
        string t1 = "test string";
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_string_and_T_has_value_and_T1_has_different_value_returns_false()
    {
        string sut = "test string";
        string t1 = "different string";
        Assert.False(sut.IsInSet(t1));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_and_T_is_null_and_T1_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = null!;
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_and_T_is_null_and_T1_is_not_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        Assert.False(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_and_T_is_not_null_and_T1_is_null_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3);
        IEquatableTestClass t1 = null!;
        Assert.False(sut.IsInSet(t1));
    }




    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_and_T_is_not_null_and_T1_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        Assert.True(sut.IsInSet(t1));
    }



    [Fact]
    public void IsInSet_T_T1_when_T_is_Class_and_T_is_not_null_and_T1_is_different_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        Assert.False(sut.IsInSet(t1));
    }
}