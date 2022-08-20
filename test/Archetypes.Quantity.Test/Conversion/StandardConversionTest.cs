using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.Test.MotherObject;
using Xunit;

namespace Archetypes.Quantity.Test.Conversion;

public class StandardConversionTest
{
    [Fact]
    public void ConstructorTest()
    {
        //Arrange
        var expectedSourceUnit = UnitMother.GetUnique();
        var expectedTargetUnit = UnitMother.GetUnique();
        const double expectedConversionFactor = 9000.1;
        const bool expectedOneWayConversion = true;

        //Act
        var result = new StandardConversion(expectedSourceUnit, expectedTargetUnit, expectedConversionFactor, expectedOneWayConversion);

        //Assert
        Assert.Same(expectedSourceUnit, result.SourceUnit);
        Assert.Same(expectedTargetUnit, result.TargetUnit);
        Assert.Equal(expectedConversionFactor, result.ConversionFactor);
        Assert.Equal(expectedOneWayConversion, result.OneWayConversion);
    }

    [Fact]
    public void DefaultOneWayConversionIsFalse()
    {
        //Arrange
        //Act
        var result = new StandardConversion(UnitMother.GetUnique(), UnitMother.GetUnique(), 1.0);

        //Assert
        Assert.False(result.OneWayConversion);
    }
}
