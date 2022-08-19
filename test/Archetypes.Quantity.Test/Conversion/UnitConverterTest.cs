using System;
using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Test.AssertObject;
using Archetypes.Quantity.Test.MotherObject;
using Xunit;

namespace Archetypes.Quantity.Test.Conversion;

public class UnitConverterTest
{
    [Fact]
    public void Convert_ThrowsException_WhenNoConversionStandardMatched()
    {
        //Arrange
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(StandardConversionMother.GetUniqueTwoWayConversion());
        subject.RegisterStandardConversions(StandardConversionMother.GetUniqueOneWayConversion());

        //Act, Assert
        var exception = Assert.Throws<Exception>(() => subject.Convert(new Quantity(UnitMother.GetUnique(), 1), UnitMother.GetUnique()));
        Assert.Equal("Unable to convert. No standard conversion found.", exception.Message);
    }

    [Fact]
    public void ConvertWithTwoWayStandardConversion_MultipliesAmountByConversionFactor_OnSourceToTargetUnitConversion()
    {
        //Arrange
        var twoWayStandardConversion = StandardConversionMother.GetUniqueTwoWayConversion(1.1);
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(twoWayStandardConversion);

        //Act
        var quantity = subject.Convert(new Quantity(twoWayStandardConversion.SourceUnit, 1000), twoWayStandardConversion.TargetUnit);

        //Assert
        AssertThat(quantity).IsEqualTo(new Quantity(twoWayStandardConversion.TargetUnit, 1100));
    }

    [Fact]
    public void ConvertWithTwoWayStandardConversion_DividesAmountByConversionFactor_OnTargetToSourceUnitConversion()
    {
        //Arrange
        var twoWayStandardConversion = StandardConversionMother.GetUniqueTwoWayConversion(1.1);
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(twoWayStandardConversion);

        //Act
        var quantity = subject.Convert(new Quantity(twoWayStandardConversion.TargetUnit, 1000), twoWayStandardConversion.SourceUnit);

        //Assert
        AssertThat(quantity).IsEqualTo(new Quantity(twoWayStandardConversion.SourceUnit, 909.090909090909));
    }

    private static AssertQuantity AssertThat(Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
