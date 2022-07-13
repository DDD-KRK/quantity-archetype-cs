using System.Collections.Generic;
using Archetypes.Quantity;
using Xunit;

namespace Archetypes.Test.Quantity;

public class MetricTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var metricInstance = new MetricInstance("name", "symbol", "definition");
        yield return new object[] {true, metricInstance, metricInstance};
        yield return new object[] {true, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "symbol", "definition")};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("a name", "a symbol", "a definition")};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("b name", "symbol", "definition"),};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "b symbol", "definition"),};
        yield return new object[] {false, new MetricInstance("name", "symbol", "definition"), new MetricInstance("name", "symbol", "b definition"),};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestMetricEquability(bool expectedResult, Metric a, Metric b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }

    private sealed class MetricInstance : Metric
    {
        private string Name { get; }
        private string Symbol { get; }
        private string Definition { get; }

        public MetricInstance(string name, string symbol, string definition)
        {
            this.Name = name;
            this.Symbol = symbol;
            this.Definition = definition;
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
    }
}
