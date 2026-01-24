#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsInSet;

// ReSharper disable once InconsistentNaming
public class IsInSet_T_T1_T2_T2
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_int_and_T_and_T1_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 12345678;
        var t2 = 99999999;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_int_and_T_and_T2_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 12345678;
        var t2 = 99999999;
        Assert.True(sut.IsInSet(t1,t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_int_and_T_and_T1_and_T2_are_different_values_returns_false()
    {
        var sut = 12345678;
        var t1 = 0;
        var t2 = 6;
        Assert.False(sut.IsInSet(t1, t2));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_and_T1_are_both_null_returns_true()
    {
        int? sut = null!;
        int? t1 = null!;
        int? t2 = 1111;
        Assert.True(sut.IsInSet(t1,t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_and_T2_are_both_null_returns_true()
    {
        int? sut = null!;
        int? t1 = 1111;
        int? t2 = null!;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_is_null_and_T1_and_T2_are_not_null_returns_false()
    {
        int? sut = null!;
        int? t1 = 11111;
        int? t2 = 88888;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_is_not_null_and_T1_and_T2_are_null_returns_false()
    {
        int? sut = 55555;
        int? t1 = null;
        int? t2 = null;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_is_not_null_and_T1_is_same_value_returns_true()
    {
        int? sut = 5;
        int? t1 = 5;
        int? t2 = 10;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_is_not_null_and_T2_is_same_value_returns_true()
    {
        int? sut = 1111;
        int? t1 = 9999;
        int? t2 = 1111;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_nullable_int_and_T_is_not_null_and_T1_and_T2_are_different_value_returns_false()
    {
        int? sut = 1111;
        int? t1 = 10;
        int? t2 = 20;
        Assert.False(sut.IsInSet(t1, t2));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_null_and_T1_is_null_returns_true()
    {
        string sut = null!;
        string t1 = null!;
        string t2 = "Test string";
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_null_and_T2_is_null_returns_true()
    {
        string sut = null!;
        string t1 = null!;
        string t2 = null!;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_null_and_T1_and_T2_are_empty_returns_false()
    {
        string sut = null!;
        string t1 = string.Empty;
        string t2 = string.Empty;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_null_and_T1_and_T2_have_value_returns_false()
    {
        string sut = null!;
        string t1 = "test value";
        string t2 = "different value";
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_empty_and_T1_and_T2_are_null_returns_false()
    {
        string sut = string.Empty;
        string t1 = null!;
        string t2 = null!;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_empty_and_T1_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = string.Empty;
        string t2 = "test string";
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_empty_and_T2_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = "test string";
        string t2 = string.Empty;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_is_empty_and_T1_and_T2_are_not_empty_returns_false()
    {
        string sut = string.Empty;
        string t1 = "test value";
        string t2 = "different value";
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_has_value_and_T1_and_T2_are_null_returns_false()
    {
        string sut = "test string";
        string t1 = null!;
        string t2 = null!;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_has_value_and_T1_and_T2_are_empty_returns_false()
    {
        string sut = "test string";
        string t1 = string.Empty;
        string t2 = string.Empty;
        Assert.False(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_has_value_and_T1_has_same_value_returns_true()
    {
        string sut = "test string";
        string t1 = "test string";
        string t2 = "different string";
        Assert.True(sut.IsInSet(t1,t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_string_and_T_has_value_and_T1_and_T2_have_different_values_returns_false()
    {
        string sut = "test string";
        string t1 = "different string";
        string t2 = "another different string";
        Assert.False(sut.IsInSet(t1, t2));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_null_and_T1_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = null!;
        IEquatableTestClass t2 = new IEquatableTestClass(4444);
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_null_and_T2_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = null!;
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_null_and_T1_and_T2_are_not_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        IEquatableTestClass t2 = new IEquatableTestClass(6666);
        Assert.False(sut.IsInSet(t1,t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_not_null_and_T1_T2_are_null_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3);
        IEquatableTestClass t1 = null!;
        IEquatableTestClass t2 = null!;
        Assert.False(sut.IsInSet(t1,t2));
    }

    

    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_not_null_and_T1_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        IEquatableTestClass t2 = new IEquatableTestClass(9999);
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_not_null_and_T2_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(9999);
        IEquatableTestClass t2 = new IEquatableTestClass(3333);
        Assert.True(sut.IsInSet(t1, t2));
    }



    [Fact]
    public void IsInSet_T_T1_T2_when_T_is_Class_and_T_is_not_null_and_T1_and_T2_are_different_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = new IEquatableTestClass(5555);
        Assert.False(sut.IsInSet(t1, t2));
    }










}