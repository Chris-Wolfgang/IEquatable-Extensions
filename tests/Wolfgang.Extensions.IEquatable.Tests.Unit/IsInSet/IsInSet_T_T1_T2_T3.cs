#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsInSet;

// ReSharper disable once InconsistentNaming
public class IsInSet_T_T1_T2_T3
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_int_and_T_and_T1_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 12345678;
        var t2 = 99999999;
        var t3 = 88888888;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_int_and_T_and_T2_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 99999999;
        var t2 = 12345678;
        var t3 = 88888888;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_int_and_T_and_T3_are_the_same_value_returns_true()
    {
        var sut = 12345678;
        var t1 = 99999999;
        var t2 = 88888888;
        var t3 = 12345678;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_int_and_T_and_T1_and_T2_and_T3_are_different_values_returns_false()
    {
        var sut = 12345678;
        var t1 = 0;
        var t2 = 6;
        var t3 = 7;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_null_and_T1_is_null_returns_true()
    {
        string sut = null!;
        string t1 = null!;
        string t2 = "Test string";
        string t3 = "Another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_null_and_T2_is_null_returns_true()
    {
        string sut = null!;
        string t1 = "Test string";
        string t2 = null!;
        string t3 = "Another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_null_and_T3_is_null_returns_true()
    {
        string sut = null!;
        string t1 = "Test string";
        string t2 = "Another string";
        string t3 = null!;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_null_and_T1_and_T2_and_T3_are_empty_returns_false()
    {
        string sut = null!;
        string t1 = string.Empty;
        string t2 = string.Empty;
        string t3 = string.Empty;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_null_and_T1_and_T2_and_T3_have_value_returns_false()
    {
        string sut = null!;
        string t1 = "test value";
        string t2 = "different value";
        string t3 = "another value";
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_empty_and_T1_and_T2_and_T3_are_null_returns_false()
    {
        string sut = string.Empty;
        string t1 = null!;
        string t2 = null!;
        string t3 = null!;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_empty_and_T1_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = string.Empty;
        string t2 = "test string";
        string t3 = "another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_empty_and_T2_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = "test string";
        string t2 = string.Empty;
        string t3 = "another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_empty_and_T3_is_empty_returns_true()
    {
        string sut = string.Empty;
        string t1 = "test string";
        string t2 = "another string";
        string t3 = string.Empty;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_is_empty_and_T1_and_T2_and_T3_are_not_empty_returns_false()
    {
        string sut = string.Empty;
        string t1 = "test value";
        string t2 = "different value";
        string t3 = "another value";
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T1_and_T2_and_T3_are_null_returns_false()
    {
        string sut = "test string";
        string t1 = null!;
        string t2 = null!;
        string t3 = null!;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T1_and_T2_and_T3_are_empty_returns_false()
    {
        string sut = "test string";
        string t1 = string.Empty;
        string t2 = string.Empty;
        string t3 = string.Empty;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T1_has_same_value_returns_true()
    {
        string sut = "test string";
        string t1 = "test string";
        string t2 = "different string";
        string t3 = "another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T2_has_same_value_returns_true()
    {
        string sut = "test string";
        string t1 = "different string";
        string t2 = "test string";
        string t3 = "another string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T3_has_same_value_returns_true()
    {
        string sut = "test string";
        string t1 = "different string";
        string t2 = "another string";
        string t3 = "test string";
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_string_and_T_has_value_and_T1_and_T2_and_T3_have_different_values_returns_false()
    {
        string sut = "test string";
        string t1 = "different string";
        string t2 = "another different string";
        string t3 = "yet another string";
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T1_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = null!;
        IEquatableTestClass t2 = new IEquatableTestClass(4444);
        IEquatableTestClass t3 = new IEquatableTestClass(5555);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T2_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = null!;
        IEquatableTestClass t3 = new IEquatableTestClass(5555);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T3_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = new IEquatableTestClass(5555);
        IEquatableTestClass t3 = null!;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T1_and_T2_and_T3_are_not_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        IEquatableTestClass t2 = new IEquatableTestClass(6666);
        IEquatableTestClass t3 = new IEquatableTestClass(7777);
        Assert.False(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T1_T2_T3_are_null_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3);
        IEquatableTestClass t1 = null!;
        IEquatableTestClass t2 = null!;
        IEquatableTestClass t3 = null!;
        Assert.False(sut.IsInSet(t1, t2, t3));
    }

    

    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T1_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(3333);
        IEquatableTestClass t2 = new IEquatableTestClass(9999);
        IEquatableTestClass t3 = new IEquatableTestClass(8888);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T2_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(9999);
        IEquatableTestClass t2 = new IEquatableTestClass(3333);
        IEquatableTestClass t3 = new IEquatableTestClass(8888);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T3_is_same_value_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(9999);
        IEquatableTestClass t2 = new IEquatableTestClass(8888);
        IEquatableTestClass t3 = new IEquatableTestClass(3333);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T1_and_T2_and_T3_are_different_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = new IEquatableTestClass(5555);
        IEquatableTestClass t3 = new IEquatableTestClass(6666);
        Assert.False(sut.IsInSet(t1, t2, t3));
    }









}
