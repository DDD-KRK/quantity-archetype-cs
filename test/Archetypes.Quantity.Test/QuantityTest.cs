using System.Collections.Generic;
using Archetypes.Quantity.Test.MotherObject;
using Xunit;

namespace Archetypes.Quantity.Test;

public class QuantityTest
{
    public static IEnumerable<object?[]> GetTestData()
    {
        var unitA = UnitMother.GetUnique();
        var oneUnitA = new Quantity(unitA, 1);

        //same instance
        yield return new object?[] {true, oneUnitA, oneUnitA};
        yield return new object?[] {false, oneUnitA, null};

        //different instance, same values
        yield return new object?[] {true, oneUnitA, new Quantity(unitA, 1)};

        //different instance, different values
        yield return new object?[] {false, oneUnitA, new Quantity(unitA, 1.1)};
        yield return new object?[] {false, oneUnitA, new Quantity(UnitMother.GetUnique(), 1)};
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
