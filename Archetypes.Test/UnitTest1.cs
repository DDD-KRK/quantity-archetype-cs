using Archetypes.Quantity;
using Archetypes.SI.Units.Base;
using Xunit;

namespace Archetypes.Test;

public class UnitTest1
{
    [Fact]
    public void TestMassConversion()
    {
        var oneKilogram = new Quantity.Quantity(new Kilogram(), 1);
        var expected = new Quantity.Quantity(new Gram(), 1000);
        var subject = new UnitConverter();

        var actual = subject.Convert(oneKilogram, new Gram());
        
        //todo research the obj equality topic
        //Assert.Equal(expected, actual);
        
        Assert.Equal(expected.GetAmount(), actual.GetAmount());
        Assert.Equal(expected.GetMetric().GetSymbol(), actual.GetMetric().GetSymbol());
    }
}
