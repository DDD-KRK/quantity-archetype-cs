using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.SystemOfUnit.SI;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base.Prefixed.Mass;
using Archetypes.Test.Quantity.AssertObject;
using Xunit;

namespace Archetypes.Test;

public class UnitTest1
{
    [Fact]
    public void MassConversionExample()
    {
        var oneKilogram = new Archetypes.Quantity.Quantity(new Kilogram(), 1);
        var expected = new Archetypes.Quantity.Quantity(new Gram(), 1000);
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(new SISystem().StandardConversions);

        var actual = subject.Convert(oneKilogram, new Gram());

        AssertThat(actual).IsEqualTo(expected);
    }
    
    private static AssertQuantity AssertThat(Archetypes.Quantity.Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
