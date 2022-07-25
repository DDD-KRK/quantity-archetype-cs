using System.Collections.Generic;
using Archetypes.Quantity;
using Xunit;

namespace Archetypes.Test.Quantity;

public class UnitTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var sou1 = new SystemOfUnits("b", "ar");
        var unitInstance = new UnitInstance("n", "s", "d", sou1);
        yield return new object[] {true, unitInstance, unitInstance};
        yield return new object[] {true, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "s", "d", sou1)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("x", "x", "x", sou1)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("x", "s", "d", sou1)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "x", "d", sou1)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "s", "x", sou1)};
        var sou2 = new SystemOfUnits("f", "oo");
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "s", "d", sou2)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("x", "x", "x", sou2)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("x", "s", "d", sou2)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "x", "d", sou2)};
        yield return new object[] {false, new UnitInstance("n", "s", "d", sou1), new UnitInstance("n", "s", "x", sou2)};
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
