using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Rounding;
using Archetypes.Quantity.Test.AssertObject;
using Archetypes.Quantity.Test.MotherObject;
using Xunit;

namespace Archetypes.Quantity.Test;

public class Example
{
    [Fact]
    public void MassConversionExample()
    {
        var systemOfUnits = new SystemOfUnits("si", "");
        var kilogramUnit = new Unit(systemOfUnits, "kilogram", "kg", "...");
        var gramUnit = new Unit(systemOfUnits, "gram", "g", "...");

        var oneKilogram = new Quantity(kilogramUnit, 1);
        var oneThousandGrams = new Quantity(gramUnit, 1000);

        var subject = new UnitConverter();
        // subject.RegisterStandardConversions(new StandardConversion(kilogramUnit, gramUnit, 1000.0,false));
        subject.RegisterStandardConversions(new StandardConversion(kilogramUnit, gramUnit, 1000.0,true));
        subject.RegisterStandardConversions(new StandardConversion(gramUnit, kilogramUnit, 1/1000.0,true));

        AssertThat(subject.Convert(oneKilogram, gramUnit)).IsEqualTo(oneThousandGrams);
        AssertThat(subject.Convert(oneThousandGrams, kilogramUnit)).IsEqualTo(oneKilogram);
        AssertThat(subject.Convert(new Quantity(gramUnit, 27), kilogramUnit)).IsEqualTo(new Quantity(kilogramUnit, 0.027));
        AssertThat(subject.Convert(new Quantity(kilogramUnit, 0.5), gramUnit)).IsEqualTo(new Quantity(gramUnit, 500));
    }

    [Fact]
    public void CurrencyExchangeExample()
    {
        var systemOfUnits = SystemOfUnitMother.GetUnique();

        var PLN = new Unit(systemOfUnits, "PLN", "PLN", "");
        var GBP = new Unit(systemOfUnits, "GBP", "GBP", "");

        var unitConverter = new UnitConverter();
        var buy = new StandardConversion(GBP, PLN, 5.5704, true); //17,952032170041649 -> 100 pln
        var sell = new StandardConversion(PLN, GBP, 1 / 5.6154, true); //17,808170388574278 <- 100 pln

        unitConverter.RegisterStandardConversions(buy);
        unitConverter.RegisterStandardConversions(sell);

        var initial100Gbp = new Quantity(GBP, 100);

        var gbp2pln = unitConverter.Convert(initial100Gbp, PLN);
        var pln2gbp = unitConverter.Convert(gbp2pln, GBP);

        AssertThat(pln2gbp).IsEqualTo(new Quantity(GBP, 99.19863233251417));
        AssertThat(pln2gbp.Round(new RoundingPolicy(RoundingStrategy.RoundUp, 2))).IsEqualTo(new Quantity(GBP, 99.2));
    }

    private static AssertQuantity AssertThat(Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
