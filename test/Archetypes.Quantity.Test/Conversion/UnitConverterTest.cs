using System;
using System.Collections.Generic;
using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Test.AssertObject;
using Xunit;

namespace Archetypes.Quantity.Test.Conversion;

public class UnitConverterTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var systemOfUnits = new SystemOfUnits("foo", "bar");
        var unitA = new Unit( systemOfUnits, "A", "A", "...");
        var unitB = new Unit( systemOfUnits, "B", "B", "...");

        yield return new object[]
        {
            // multiply when source to target
            new StandardConversion(unitA, unitB, 1.1), new Archetypes.Quantity.Quantity(unitA, 1000), unitB, new Archetypes.Quantity.Quantity(unitB, 1100),
        };
        yield return new object[]
        {
            // divide when target to source
            new StandardConversion(unitA, unitB, 1.1),
            new Archetypes.Quantity.Quantity(unitB, 1000),
            unitA,
            new Archetypes.Quantity.Quantity(unitA, 909.090909090909),
        };
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Convert_Test(StandardConversion standardConversion, Archetypes.Quantity.Quantity sourceQuantity, Unit targetUnit,
        Archetypes.Quantity.Quantity expectedQuantity)
    {
        //A
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(standardConversion);

        //A
        var quantity = subject.Convert(sourceQuantity, targetUnit);

        //A
        AssertThat(quantity).IsEqualTo(expectedQuantity);
    }

    [Fact]
    public void Convert_Throws_Exception_When_No_Conversion_Standard_Found()
    {
        //A
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(new StandardConversion(
            new Unit(new SystemOfUnits("c", "c"),"c","c","c"),
            new Unit(new SystemOfUnits("d", "d"),"d","d","d"),
            1
            ));

        //A A
        var targetUnit = new Unit(new SystemOfUnits("a", "a"),"a","a","a");
        var sourceQuantity = new Archetypes.Quantity.Quantity(new Unit(new SystemOfUnits("b", "b"),"b","b","b"), 1);

        var exception = Assert.Throws<Exception>(() => subject.Convert(sourceQuantity, targetUnit));
        Assert.Equal("Unable to convert. No standard conversion found.", exception.Message);
    }

    private static AssertQuantity AssertThat(Archetypes.Quantity.Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
