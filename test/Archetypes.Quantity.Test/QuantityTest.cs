using System.Collections.Generic;
using Xunit;

namespace Archetypes.Quantity.Test;

public class QuantityTest
{
    public static IEnumerable<object?[]> GetTestData()
    {
        var sou1 = new SystemOfUnits("b", "ar");
        var unitA = new Unit(sou1,"A", "a", "d");
        var unitB = new Unit(sou1,"B", "b", "d");

        var quantity = new Quantity(unitA, 1);
        yield return new object?[] {true, quantity, quantity};

        yield return new object?[] {true, new Quantity(unitB, 1), new Quantity(unitB, 1)};
        yield return new object?[] {false, new Quantity(unitB, 1), null};

        yield return new object?[] {false, new Quantity(unitB, 1), new Quantity(unitB, 1.1)};
        yield return new object?[] {false, new Quantity(unitA, 1), new Quantity(unitB, 1)};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestMetricEquability(bool expectedResult, Quantity a, Quantity? b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }
}
