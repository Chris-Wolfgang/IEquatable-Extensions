using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;

namespace Wolfgang.Extensions.IEquatable.Tests.Unit;

/// <summary>
/// Verifies the library adds no culture sensitivity of its own. Every overload decides equality
/// through <see cref="object.Equals(object, object)"/> or <see cref="EqualityComparer{T}.Default"/>,
/// and for <see cref="string"/> both of those are ordinal. So the answer must be the same under
/// every culture, and must agree with <see cref="string.Equals(string, string)"/>, even for pairs
/// that a culture-aware comparison treats as equal or a culture-aware case mapping changes.
/// </summary>
/// <remarks>
/// Each test runs under Invariant, en-US and the hostile cultures from the fleet matrix: tr-TR
/// (dotted and dotless I), de-DE (sharp s), zh-CN (collation), ar-SA (right-to-left, Arabic-Indic
/// digits) and ja-JP (full-width forms). <see cref="CultureScope"/> swaps both
/// <see cref="CultureInfo.CurrentCulture"/> and <see cref="CultureInfo.CurrentUICulture"/> and
/// restores them afterwards, so a culture never leaks into a later test. No public method is
/// intentionally culture-sensitive, so the allowlist of culture-sensitive methods is empty.
/// </remarks>
public class CultureInvarianceTests
{
    public static readonly TheoryData<string> Cultures = new()
    {
        "",
        "en-US",
        "tr-TR",
        "de-DE",
        "zh-CN",
        "ar-SA",
        "ja-JP",
    };



    // Pairs that are different strings ordinally. Several of them compare equal, or map onto each
    // other, under some culture: i/I/İ/ı under tr-TR, ß/ss under a linguistic comparison, a
    // precomposed and a decomposed å, ASCII and full-width digits, ASCII and Arabic-Indic digits.
    private static readonly string[] Values =
    {
        "i",
        "I",
        "\u0130",
        "\u0131",
        "\u00DF",
        "ss",
        "\u00E5",
        "a\u030A",
        "1",
        "\uFF11",
        "\u0661",
        "",
    };



    [Theory]
    [MemberData(nameof(Cultures))]
    public void IsInSet_T_T1_when_T_is_string_agrees_with_ordinal_string_Equals_under_every_culture(string cultureName)
    {
        using var scope = new CultureScope(cultureName);

        foreach (var item in Values)
        {
            foreach (var other in Values)
            {
                Assert.Equal
                (
                    string.Equals(item, other, StringComparison.Ordinal),
                    item.IsInSet(other)
                );
            }
        }
    }



    [Theory]
    [MemberData(nameof(Cultures))]
    public void NotEqual_when_T_is_string_agrees_with_ordinal_string_Equals_under_every_culture(string cultureName)
    {
        using var scope = new CultureScope(cultureName);

        foreach (var item in Values)
        {
            foreach (var other in Values)
            {
                Assert.Equal
                (
                    !string.Equals(item, other, StringComparison.Ordinal),
                    item.NotEqual(other)
                );
            }
        }
    }



    [Theory]
    [MemberData(nameof(Cultures))]
    public void IsInSet_collection_overloads_when_T_is_string_match_only_the_ordinal_value_under_every_culture(string cultureName)
    {
        using var scope = new CultureScope(cultureName);

        foreach (var item in Values)
        {
            var others = Values.Where(v => !string.Equals(v, item, StringComparison.Ordinal)).ToArray();

            Assert.False(item.IsInSet(others));
            Assert.False(item.IsInSet((IEnumerable<string>)others.ToList()));
            Assert.False(item.IsInSet((ICollection<string?>)new HashSet<string?>(others)));

            Assert.True(item.IsNotInSet(others));
            Assert.True(item.IsNotInSet((IEnumerable<string>)others.ToList()));
            Assert.True(item.IsNotInSet((ICollection<string?>)new HashSet<string?>(others)));

            var withItem = others.Concat(new[] { item }).ToArray();

            Assert.True(item.IsInSet(withItem));
            Assert.True(item.IsInSet((IEnumerable<string>)withItem.ToList()));
            Assert.True(item.IsInSet((ICollection<string?>)new HashSet<string?>(withItem)));
        }
    }



    [Theory]
    [InlineData("en-US")]
    [InlineData("tr-TR")]
    public void IsInSet_when_T_is_string_does_not_apply_turkish_case_mapping(string cultureName)
    {
        using var scope = new CultureScope(cultureName);

        Assert.False("i".IsInSet("I", "\u0130"));
        Assert.False("\u0131".IsInSet("I", "i"));
        Assert.True("i".IsNotInSet("I", "\u0130", "\u0131"));
    }



    [Theory]
    [MemberData(nameof(Cultures))]
    public void IsInSet_when_T_is_double_is_culture_invariant(string cultureName)
    {
        using var scope = new CultureScope(cultureName);

        Assert.True(1.5d.IsInSet(0.5d, 1.5d, 2.5d));
        Assert.False(1.5d.IsInSet(15d, 0.15d));
        Assert.True(1.5d.NotEqual(1.50001d));
    }



    [Fact]
    public void CultureScope_restores_the_original_cultures()
    {
        var culture = CultureInfo.CurrentCulture;
        var uiCulture = CultureInfo.CurrentUICulture;

        using (new CultureScope("tr-TR"))
        {
            Assert.Equal("tr-TR", CultureInfo.CurrentCulture.Name);
            Assert.Equal("tr-TR", CultureInfo.CurrentUICulture.Name);
        }

        Assert.Equal(culture, CultureInfo.CurrentCulture);
        Assert.Equal(uiCulture, CultureInfo.CurrentUICulture);
    }



    private sealed class CultureScope : IDisposable
    {
        private readonly CultureInfo _culture;
        private readonly CultureInfo _uiCulture;



        public CultureScope(string cultureName)
        {
            _culture = Thread.CurrentThread.CurrentCulture;
            _uiCulture = Thread.CurrentThread.CurrentUICulture;

            var culture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }



        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _culture;
            Thread.CurrentThread.CurrentUICulture = _uiCulture;
        }
    }
}
