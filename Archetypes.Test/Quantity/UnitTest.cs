using System.Collections.Generic;
using Archetypes.Quantity;
using Xunit;

namespace Archetypes.Test.Quantity;

public class UnitTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var sou1 = new SystemOfUnits("b", "ar");
        var metricInstance = new UnitInstance("n", "s", "d", sou1);
        yield return new object[] {true, metricInstance, metricInstance};
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

    // [Theory]
    // [MemberData(nameof(GetTestData))]
    // public void WTH(bool expectedResult, Metric a, Metric b)
    // {
    //     //returns false positive. a & b both objects are Unit, but when Metric(base class) type used it calls Metric.Equals and never Unit.Equals
    //     Assert.Equal(expectedResult, a.Equals(b)); //if removed, it's successful
    //     Assert.Equal(expectedResult, a == b);
    //     Assert.Equal(!expectedResult, a != b);
    // }

    private sealed class UnitInstance : Unit
    {
        private string Name { get; }
        private string Symbol { get; }
        private string Definition { get; }
        private SystemOfUnits SystemOfUnits { get; }

        public UnitInstance(string name, string symbol, string definition, SystemOfUnits systemOfUnits)
        {
            Name = name;
            Symbol = symbol;
            Definition = definition;
            SystemOfUnits = systemOfUnits;
        }

        public override string GetName()
        {
            return Name;
        }

        public override string GetSymbol()
        {
            return Symbol;
        }

        public override string GetDefinition()
        {
            return Definition;
        }

        public override SystemOfUnits GetSystemOfUnits()
        {
            return SystemOfUnits;
        }
    }
}
