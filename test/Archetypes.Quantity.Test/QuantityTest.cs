using System.Collections.Generic;
using Xunit;

namespace Archetypes.Quantity.Test;

// todo rememebr to include in build process
public class QuantityTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var sou1 = new SystemOfUnits("b", "ar");
        var unitA = new UnitInstance("A", "a", "d", sou1);
        var unitB = new UnitInstance("B", "b", "d", sou1);

        var quantityInstance = new Quantity(unitA, 1);

        yield return new object[] {true, quantityInstance, quantityInstance};
        
        yield return new object[] {true, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "symbol", "definition")};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("a name", "a symbol", "a definition")};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("b name", "symbol", "definition"),};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "b symbol", "definition"),};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "symbol", "b definition"),};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestMetricEquability(bool expectedResult, Quantity a, Quantity b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }
}
