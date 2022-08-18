using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Test.AssertObject;
using Xunit;

namespace Archetypes.Quantity.Test;

public class Example
{
    [Fact]
    public void MassConversionExample()
    {
        var systemOfUnits = new SystemOfUnits("si","");
        var kilogramUnit = new Unit(systemOfUnits, "kilogram", "kg", "...");
        var gramUnit = new Unit(systemOfUnits, "gram", "g", "...");
        
        var oneKilogram = new Quantity(kilogramUnit, 1);
        var oneThousandGrams = new Quantity(gramUnit, 1000);
        
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(new StandardConversion(kilogramUnit, gramUnit, 1000.0));

        AssertThat(subject.Convert(oneKilogram, gramUnit)).IsEqualTo(oneThousandGrams);
        AssertThat(subject.Convert(oneThousandGrams, kilogramUnit)).IsEqualTo(oneKilogram);
        AssertThat(subject.Convert(new Quantity(gramUnit, 27), kilogramUnit)).IsEqualTo(new Quantity(kilogramUnit, 0.027));
        AssertThat(subject.Convert(new Quantity(kilogramUnit, 0.5), gramUnit)).IsEqualTo(new Quantity(gramUnit, 500));
    }
    
    private static AssertQuantity AssertThat(Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
