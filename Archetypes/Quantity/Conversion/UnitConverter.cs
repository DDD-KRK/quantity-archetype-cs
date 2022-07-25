namespace Archetypes.Quantity.Conversion;

public class UnitConverter
{
    private List<StandardConversion> StandardConversions { get; } = new();

    public void RegisterStandardConversions(IEnumerable<StandardConversion> standardConversions)
    {
        StandardConversions.AddRange(standardConversions);
    }

    public Quantity Convert(Quantity sourceQuantity, Unit targetUnit)
    {
        var sourceMetric = sourceQuantity.GetMetric();

        foreach (var standardConversion in StandardConversions)
        {
            //todo no way of knowing if the source unit is of the same system of units as the quantity.metric
            if (standardConversion.SourceUnit.GetSymbol() == sourceMetric.GetSymbol() && standardConversion.TargetUnit == targetUnit)
            {
                return new Quantity(targetUnit, sourceQuantity.GetAmount() * standardConversion.ConversionFactor);
            }

            if (standardConversion.TargetUnit.GetSymbol() == sourceMetric.GetSymbol() && standardConversion.SourceUnit == targetUnit)
            {
                return new Quantity(targetUnit, sourceQuantity.GetAmount() / standardConversion.ConversionFactor);
            }
        }

        throw new Exception("Unable to convert. No standard conversion found.");
    }
}
