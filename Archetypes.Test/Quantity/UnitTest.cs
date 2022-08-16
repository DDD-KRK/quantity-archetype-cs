using System.Collections.Generic;
using Archetypes.Quantity;
using Xunit;

namespace Archetypes.Test.Quantity;

public class UnitTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var sou1 = new SystemOfUnits("b", "ar");
        var unit = new Unit(sou1, "n", "s", "d");
        yield return new object[] {true, unit, unit};
        yield return new object[] {true, new Unit(sou1, "n", "s", "d"), new Unit(sou1, "n", "s", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou1, "x", "x", "x")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou1, "x", "s", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou1, "n", "x", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou1, "n", "s", "x")};
        var sou2 = new SystemOfUnits("f", "oo");
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou2, "n", "s", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou2, "x", "x", "x")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou2, "x", "s", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou2, "n", "x", "d")};
        yield return new object[] {false, new Unit(sou1, "n", "s", "d"), new Unit(sou2, "n", "s", "x")};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestUnitEquability(bool expectedResult, Unit a, Unit b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }
}
