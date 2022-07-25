using System;
using System.Collections.Generic;
using Archetypes.Quantity;
using Archetypes.Quantity.Conversion;
using Archetypes.Test.Quantity.AssertObject;
using NSubstitute;
using Xunit;

namespace Archetypes.Test.Quantity.Conversion;

public class UnitConverterTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var systemOfUnits = new SystemOfUnits("foo", "bar");
        var unitA = new UnitInstance("A", "A", "...", systemOfUnits);
        var unitB = new UnitInstance("B", "B", "...", systemOfUnits);

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
        subject.RegisterStandardConversions(new[] {standardConversion});

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

        //A A
        var targetUnit = Substitute.For<Unit>();
        var sourceQuantity = Substitute.For<Archetypes.Quantity.Quantity>(Substitute.For<Unit>(), 1);

        var exception = Assert.Throws<Exception>(() => subject.Convert(sourceQuantity, targetUnit));
        Assert.Equal("Unable to convert. No standard conversion found.", exception.Message);
    }

    private static AssertQuantity AssertThat(Archetypes.Quantity.Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
