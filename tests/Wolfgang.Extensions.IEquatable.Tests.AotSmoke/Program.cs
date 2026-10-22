using System;
using System.Collections.Generic;
using System.Linq;
using Wolfgang.Extensions.IEquatable;
using Wolfgang.Extensions.IEquatable.Tests.AotSmoke;

// Native AOT smoke consumer. Calls every public overload on a value type (int), a nullable value
// type (int?), string and a user-defined IEquatable<T> record, so the trimmer keeps every generic
// instantiation the library needs, and a fault on any code path fails the workflow's run step.
// Each check prints the failing case before exiting with code 1, so the CI log shows what broke.

var failures = 0;

Check("IsInSet(t1) int", 3.IsInSet(3), true);
Check("IsInSet(t1, t2) int", 3.IsInSet(1, 2), false);
Check("IsInSet(t1, t2, t3) int", 3.IsInSet(1, 2, 3), true);
Check("IsInSet(params) int", 3.IsInSet(new[] { 1, 2, 3, 4 }), true);
Check("IsInSet(IEnumerable) int", 3.IsInSet(Enumerable.Range(10, 5)), false);
Check("IsInSet(ICollection) int", 3.IsInSet((ICollection<int>)new HashSet<int> { 1, 3 }), true);

Check("IsNotInSet(t1) int?", ((int?)null).IsNotInSet(1), true);
Check("IsNotInSet(t1, t2) int?", ((int?)null).IsNotInSet(1, null), false);
Check("IsNotInSet(t1, t2, t3) int?", ((int?)5).IsNotInSet(1, 2, 3), true);
Check("IsNotInSet(params) int?", ((int?)5).IsNotInSet(new int?[] { 5, null }), false);
Check("IsNotInSet(IEnumerable) int?", ((int?)5).IsNotInSet(new List<int?> { 1, 2 }.Select(x => x)), true);
Check("IsNotInSet(ICollection) int?", ((int?)5).IsNotInSet((ICollection<int?>)new List<int?> { 5 }), false);

Check("IsInSet(t1, t2, t3) string", "b".IsInSet("a", "b", "c"), true);
Check("IsInSet(ICollection) string", "z".IsInSet((ICollection<string?>)new HashSet<string?> { "a", null }), false);
Check("NotEqual string", "a".NotEqual("b"), true);
Check("NotEqual string null", ((string?)null).NotEqual(null), false);

Check("IsInSet(t1, t2) record", new Point(1, 2).IsInSet(new Point(0, 0), new Point(1, 2)), true);
Check("IsNotInSet(IEnumerable) record", new Point(1, 2).IsNotInSet(new[] { new Point(1, 2) }.AsEnumerable()), false);
Check("NotEqual record", new Point(1, 2).NotEqual(new Point(2, 1)), true);

// The argument-null path: constructing ArgumentNullException is a classic trim casualty, so force
// it once and check the parameter name survives.
try
{
    _ = 1.IsInSet((ICollection<int>)null!);
    Fail("IsInSet(null ICollection) did not throw");
}
catch (ArgumentNullException ex) when (string.Equals(ex.ParamName, "set", StringComparison.Ordinal))
{
    // expected
}

if (failures != 0)
{
    return 1;
}

Console.WriteLine("AOT smoke OK.");
return 0;



void Check(string label, bool actual, bool expected)
{
    if (actual != expected)
    {
        Fail($"{label}: expected {expected}, got {actual}");
    }
}



void Fail(string message)
{
    Console.Error.WriteLine($"AOT smoke FAILED: {message}");
    failures++;
}



namespace Wolfgang.Extensions.IEquatable.Tests.AotSmoke
{
    internal sealed record Point(int X, int Y);
}
