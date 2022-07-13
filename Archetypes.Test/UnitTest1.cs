using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base;
using Xunit;

namespace Archetypes.Test;

public class UnitTest1
{
    [Fact]
    public void TestMassConversion()
    {
        var oneKilogram = new Archetypes.Quantity.Quantity(new Kilogram(), 1);
        var expected = new Archetypes.Quantity.Quantity(new Gram(), 1000);
        var subject = new UnitConverter();

        var actual = subject.Convert(oneKilogram, new Gram());

        //todo research the obj equality topic
        //Assert.Equal(expected, actual);

        Assert.Equal(expected.GetAmount(), actual.GetAmount());
        Assert.Equal(expected.GetMetric().GetSymbol(), actual.GetMetric().GetSymbol());
    }
}
