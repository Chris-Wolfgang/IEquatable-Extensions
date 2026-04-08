#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsNotInSet;

// ReSharper disable once InconsistentNaming
public class IsNotInSet_T_ParamsArray
{

    // ---------------------------------   int   ----------------------------------


    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_T_is_found_at_first_position_returns_false()
    {
        var sut = 12345678;
        var set = new[] { 12345678, 99999999, 88888888, 77777777 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_T_is_found_at_middle_position_returns_false()
    {
        var sut = 12345678;
        var set = new[] { 99999999, 12345678, 88888888, 77777777 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_T_is_found_at_last_position_returns_false()
    {
        var sut = 12345678;
        var set = new[] { 99999999, 88888888, 77777777, 12345678 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_T_is_not_found_in_array_returns_true()
    {
        var sut = 12345678;
        var set = new[] { 99999999, 88888888, 77777777, 66666666 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_array_is_empty_returns_true()
    {
        var sut = 12345678;
        var set = new int[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_no_arguments_passed_returns_true()
    {
        var sut = 12345678;
        Assert.True(sut.IsNotInSet());
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_values_passed_as_individual_params_returns_false()
    {
        var sut = 12345678;
        Assert.False(sut.IsNotInSet(99999999, 12345678, 88888888, 77777777));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_int_and_values_passed_as_individual_params_returns_true()
    {
        var sut = 12345678;
        Assert.True(sut.IsNotInSet(99999999, 88888888, 77777777, 66666666));
    }



    // ---------------------------------   Nullable<int>   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_T_is_null_and_array_contains_null_returns_false()
    {
        int? sut = null!;
        var set = new int?[] { 11111, null, 22222, 33333 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_T_is_null_and_array_does_not_contain_null_returns_true()
    {
        int? sut = null!;
        var set = new int?[] { 11111, 22222, 33333 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_T_is_null_and_array_is_empty_returns_true()
    {
        int? sut = null!;
        var set = new int?[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_T_is_not_null_and_found_in_array_returns_false()
    {
        int? sut = 5;
        var set = new int?[] { 10, 5, 20, 30 };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_T_is_not_null_and_not_found_in_array_returns_true()
    {
        int? sut = 5;
        var set = new int?[] { 10, 20, 30, 40 };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_values_passed_as_individual_params_with_null_returns_false()
    {
        int? sut = null!;
        Assert.False(sut.IsNotInSet(11111, null, 22222, 33333));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_nullable_int_and_values_passed_as_individual_params_returns_false()
    {
        int? sut = 5;
        Assert.False(sut.IsNotInSet(10, 5, 20, 30));
    }



    // ---------------------------------   string   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_is_null_and_array_contains_null_returns_false()
    {
        string sut = null!;
        var set = new string[] { "test1", null!, "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_is_null_and_array_does_not_contain_null_returns_true()
    {
        string sut = null!;
        var set = new string[] { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_is_null_and_array_is_empty_returns_true()
    {
        string sut = null!;
        var set = new string[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_is_empty_and_array_contains_empty_returns_false()
    {
        string sut = string.Empty;
        var set = new string[] { "test1", string.Empty, "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_is_empty_and_array_does_not_contain_empty_returns_true()
    {
        string sut = string.Empty;
        var set = new string[] { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_has_value_and_found_in_array_returns_false()
    {
        string sut = "test string";
        var set = new string[] { "test1", "test string", "test2", "test3" };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_has_value_and_not_found_in_array_returns_true()
    {
        string sut = "test string";
        var set = new string[] { "test1", "test2", "test3" };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_T_has_value_and_array_is_empty_returns_true()
    {
        string sut = "test string";
        var set = new string[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_values_passed_as_individual_params_with_null_returns_false()
    {
        string sut = null!;
        Assert.False(sut.IsNotInSet("test1", null!, "test2", "test3"));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_string_and_values_passed_as_individual_params_returns_false()
    {
        string sut = "test string";
        Assert.False(sut.IsNotInSet("test1", "test string", "test2", "test3"));
    }



    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_null_and_array_contains_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        var set = new IEquatableTestClass[] { new IEquatableTestClass(1111), null!, new IEquatableTestClass(2222) };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_null_and_array_does_not_contain_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        var set = new IEquatableTestClass[] { new IEquatableTestClass(1111), new IEquatableTestClass(2222), new IEquatableTestClass(3333) };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_null_and_array_is_empty_returns_true()
    {
        IEquatableTestClass sut = null!;
        var set = new IEquatableTestClass[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_not_null_and_found_by_value_equality_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        var set = new IEquatableTestClass[] { new IEquatableTestClass(1111), new IEquatableTestClass(3333), new IEquatableTestClass(2222) };
        Assert.False(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_not_null_and_not_found_in_array_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        var set = new IEquatableTestClass[] { new IEquatableTestClass(1111), new IEquatableTestClass(2222), new IEquatableTestClass(4444) };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_T_is_not_null_and_array_is_empty_returns_true()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        var set = new IEquatableTestClass[] { };
        Assert.True(sut.IsNotInSet(set));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_values_passed_as_individual_params_with_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        Assert.False(sut.IsNotInSet(new IEquatableTestClass(1111), null!, new IEquatableTestClass(2222), new IEquatableTestClass(4444)));
    }



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_T_is_Class_and_values_passed_as_individual_params_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        Assert.False(sut.IsNotInSet(new IEquatableTestClass(1111), new IEquatableTestClass(3333), new IEquatableTestClass(2222), new IEquatableTestClass(4444)));
    }



    // ---------------------------------   ArgumentNullException   ----------------------------------



    [Fact]
    public void IsNotInSet_T_ParamsArray_when_set_is_null_throws_ArgumentNullException()
    {
        var sut = 12345678;
        int[] set = null!;
        Assert.Throws<ArgumentNullException>(() => sut.IsNotInSet(set));
    }
}
