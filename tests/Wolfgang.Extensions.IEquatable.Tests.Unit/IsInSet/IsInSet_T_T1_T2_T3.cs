#pragma warning disable IDE0007
namespace Wolfgang.Extensions.IEquatable.Tests.Unit.IsInSet;

// ReSharper disable once InconsistentNaming
public class IsInSet_T_T1_T2_T3
{

    // ---------------------------------   Class   ----------------------------------



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T1_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = null!;
        IEquatableTestClass t2 = new IEquatableTestClass(2222);
        IEquatableTestClass t3 = new IEquatableTestClass(3333);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T2_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(1111);
        IEquatableTestClass t2 = null!;
        IEquatableTestClass t3 = new IEquatableTestClass(3333);
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T3_is_null_returns_true()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(1111);
        IEquatableTestClass t2 = new IEquatableTestClass(2222);
        IEquatableTestClass t3 = null!;
        Assert.True(sut.IsInSet(t1, t2, t3));
    }



    [Fact]
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_null_and_T1_T2_T3_are_not_null_returns_false()
    {
        IEquatableTestClass sut = null!;
        IEquatableTestClass t1 = new IEquatableTestClass(1111);
        IEquatableTestClass t2 = new IEquatableTestClass(2222);
        IEquatableTestClass t3 = new IEquatableTestClass(3333);
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
    public void IsInSet_T_T1_T2_T3_when_T_is_Class_and_T_is_not_null_and_T1_T2_T3_are_different_value_returns_false()
    {
        IEquatableTestClass sut = new IEquatableTestClass(3333);
        IEquatableTestClass t1 = new IEquatableTestClass(4444);
        IEquatableTestClass t2 = new IEquatableTestClass(5555);
        IEquatableTestClass t3 = new IEquatableTestClass(6666);
        Assert.False(sut.IsInSet(t1, t2, t3));
    }
}
