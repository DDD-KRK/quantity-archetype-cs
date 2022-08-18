using System;
using System.Collections.Generic;
using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Test.AssertObject;
using Archetypes.Quantity.Test.MotherObject;
using Xunit;

namespace Archetypes.Quantity.Test.Conversion;

public class UnitConverterTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var twoWayStandardConversion = StandardConversionMother.GetUniqueTwoWayConversion(1.1);
        var sourceUnit = twoWayStandardConversion.SourceUnit;
        var targetUnit = twoWayStandardConversion.TargetUnit;

        yield return new object[]
        {
            // multiply when source to target
            twoWayStandardConversion, new Quantity(sourceUnit, 1000), targetUnit, new Quantity(targetUnit, 1100)
        };
        yield return new object[]
        {
            // divide when target to source
            twoWayStandardConversion, new Quantity(targetUnit, 1000), sourceUnit, new Quantity(sourceUnit, 909.090909090909)
        };
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Convert_Test(StandardConversion twoWayStandardConversion, Quantity sourceQuantity, Unit targetUnit,
        Quantity expectedQuantity)
    {
        //todo  rewrite this test: one,two way conversions
        //A
        Assert.False(twoWayStandardConversion.OneWayConversion, "Expected two way standard conversion");
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(twoWayStandardConversion);

        //A
        var quantity = subject.Convert(sourceQuantity, targetUnit);

        //A
        AssertThat(quantity).IsEqualTo(expectedQuantity);
    }

    [Fact]
    public void Convert_MultipliesAmountByConversionFactor_OnSourceToTargetUnitConversion()
    {
        //Arrange
        throw new NotImplementedException();

        //Act

        //Assert
    }

    [Fact]
    public void Convert_DividesAmountByConversionFactor_OnTargetToSourceUnitConversion()
    {
        //Arrange
        throw new NotImplementedException();

        //Act

        //Assert
    }

    //todo one way conversion standard: multiply and throw Exception

    [Fact]
    public void Convert_Throws_Exception_When_No_Conversion_Standard_Found()
    {
        //A
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(StandardConversionMother.GetUniqueTwoWayConversion());

        //A A
        var targetUnit = UnitMother.GetUnique();
        var sourceQuantity = new Quantity(UnitMother.GetUnique(), 1);

        var exception = Assert.Throws<Exception>(() => subject.Convert(sourceQuantity, targetUnit));
        Assert.Equal("Unable to convert. No standard conversion found.", exception.Message);
    }

    private static AssertQuantity AssertThat(Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
