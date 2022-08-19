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
        Assert.Throws<NoMatchingStandardConversionException>(() => subject.Convert(new Quantity(UnitMother.GetUnique(), 1), UnitMother.GetUnique()));
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

    [Fact]
    public void ConvertWithOneWayStandardConversion_MultipliesAmountByConversionFactor_OnSourceToTargetUnitConversion()
    {
        //Arrange
        var oneWayStandardConversion = StandardConversionMother.GetUniqueOneWayConversion(1.2);
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(oneWayStandardConversion);

        //Act
        var quantity = subject.Convert(new Quantity(oneWayStandardConversion.SourceUnit, 1000), oneWayStandardConversion.TargetUnit);

        //Assert
        AssertThat(quantity).IsEqualTo(new Quantity(oneWayStandardConversion.TargetUnit, 1200));
    }

    [Fact]
    public void ConvertWithOneWayStandardConversion_ThrowsException_OnTargetToSourceUnitConversion()
    {
        //Arrange
        var oneWayStandardConversion = StandardConversionMother.GetUniqueOneWayConversion();
        var subject = new UnitConverter();
        subject.RegisterStandardConversions(oneWayStandardConversion);

        //Act, Assert
        Assert.Throws<NoMatchingStandardConversionException>(
            () => subject.Convert(new Quantity(oneWayStandardConversion.TargetUnit, 1), oneWayStandardConversion.SourceUnit)
        );
    }

    private static AssertQuantity AssertThat(Quantity quantity)
    {
        return new AssertQuantity(quantity);
    }
}
