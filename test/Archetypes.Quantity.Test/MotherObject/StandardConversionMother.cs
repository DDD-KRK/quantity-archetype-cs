using System;
using Archetypes.Quantity.Conversion;

namespace Archetypes.Quantity.Test.MotherObject;

public static class StandardConversionMother
{
    public static StandardConversion GetUniqueTwoWayConversion(double? conversionFactor = null)
    {
        return GetUnique(conversionFactor, false);
    }

    public static StandardConversion GetUniqueOneWayConversion(double? conversionFactor = null)
    {
        return GetUnique(conversionFactor, true);
    }

    private static StandardConversion GetUnique(double? conversionFactor = null, bool? oneWayConversion = null)
    {
        return new StandardConversion(
            UnitMother.GetUnique(),
            UnitMother.GetUnique(),
            conversionFactor ?? Random.Shared.NextDouble(),
            oneWayConversion ?? false
        );
    }
}
