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

        //Act
        var result = new StandardConversion(expectedSourceUnit, expectedTargetUnit, expectedConversionFactor);

        //Assert
        Assert.Same(expectedSourceUnit, result.SourceUnit);
        Assert.Same(expectedTargetUnit, result.TargetUnit);
        Assert.Equal(expectedConversionFactor, result.ConversionFactor);
    }
}
