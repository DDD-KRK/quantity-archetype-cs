namespace Archetypes.Quantity.Conversion;

public class UnitConverter
{
    private List<StandardConversion> StandardConversions { get; } = new();

    public void RegisterStandardConversions(StandardConversion standardConversion)
    {
        StandardConversions.Add(standardConversion);
    }

    public void RegisterStandardConversions(IEnumerable<StandardConversion> standardConversions)
    {
        StandardConversions.AddRange(standardConversions);
    }

    public Quantity Convert(Quantity sourceQuantity, Unit targetUnit)
    {
        var sourceUnit = sourceQuantity.Unit;

        foreach (var standardConversion in StandardConversions)
        {
            if (standardConversion.SourceUnit.Equals(sourceUnit) && standardConversion.TargetUnit.Equals(targetUnit))
            {
                return new Quantity(targetUnit, sourceQuantity.Amount * standardConversion.ConversionFactor);
            }

            if (!standardConversion.OneWayConversion && standardConversion.TargetUnit.Equals(sourceUnit) && standardConversion.SourceUnit.Equals(targetUnit))
            {
                return new Quantity(targetUnit, sourceQuantity.Amount / standardConversion.ConversionFactor);
            }
        }

        throw new NoMatchingStandardConversionException(sourceUnit, targetUnit);
    }
}
