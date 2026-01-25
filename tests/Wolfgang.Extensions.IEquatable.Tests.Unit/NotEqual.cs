namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

public class NotEqual
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void NotEqual_T_when_T_is_int_and_both_values_are_equal_returns_false()
    {
        int sut = 11111;
        int other = 11111;
        Assert.False(sut.NotEqual(other));
    }




    [Fact]
    public void NotEqual_T_when_T_is_int_and_both_values_are_not_equal_returns_true()
    {
        int sut = 11111;
        int other = 88888;
        Assert.True(sut.NotEqual(other));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void NotEqual_T_when_T_is_Nullable_int_and_both_values_are_null_returns_false()
    {
        int? sut = null;
        int? other = null;
        Assert.False(sut.NotEqual(other));
    }

    

    [Fact]
    public void NotEqual_T_when_T_is_Nullable_int_and_left_is_null_and_right_is_not_null_returns_true()
    {
        int? sut = null;
        int? other = 88888;
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Nullable_int_and_left_is_not_null_and_right_is_null_returns_true()
    {
        int? sut = 88888;
        int? other = null;
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Nullable_int_and_left_is_not_null_and_right_is_different_not_null_returns_true()
    {
        int? sut = 11111;
        int? other = 99999;
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Nullable_int_and_left_is_not_null_and_right_is_not_null_and_left_and_right_are_same_returns_false()
    {
        int? sut = 11111;
        int? other = 11111;
        Assert.False(sut.NotEqual(other));
    }



    // ---------------------------------   string   ----------------------------------

    [Fact]
    public void NotEqual_T_when_T_is_string_and_both_values_are_equal_returns_false()
    {
        string sut = "Hello, World!";
        string other = "Hello, World!";
        Assert.False(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_string_and_both_values_are_not_equal_returns_true()
    {
        string sut = "Hello, World!";
        string other = "Goodbye, World!";
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_string_and_left_is_null_and_right_is_null_returns_false()
    {
        string sut = null!;
        string other = null!;
        Assert.False(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_string_and_left_is_null_and_right_is_not_null_returns_true()
    {
        string sut = null!;
        string other = "Hello, World!";
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_string_and_left_is_not_null_and_right_is_null_returns_true()
    {
        string sut = "Hello, World!";
        string other = null!;
        Assert.True(sut.NotEqual(other));
    }




    // ---------------------------------   Class   ----------------------------------


    [Fact]
    public void NotEqual_T_when_T_is_Class_and_left_is_null_and_right_is_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass other = null!;
        Assert.False(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Class_and_left_is_null_and_right_is_not_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass other = new IEquatableTestClass(3);
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Class_and_left_is_not_null_and_right_is_null_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3)!;
        IEquatableTestClass other = null!;
        Assert.True(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Class_and_left_is_not_null_and_right_is_not_null_and_are_equal_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(5);
        IEquatableTestClass other = new IEquatableTestClass(5);
        Assert.False(sut.NotEqual(other));
    }



    [Fact]
    public void NotEqual_T_when_T_is_Class_and_left_is_not_null_and_right_is_not_null_and_are_not_equal_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(111111);
        IEquatableTestClass other = new IEquatableTestClass(999999);
        Assert.True(sut.NotEqual(other));
    }



}
