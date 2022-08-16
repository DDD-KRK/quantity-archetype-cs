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
            // currency nie mozna tak przeliczac, bo w obie strony stawki sa rozne - OneWayConverter + TwoWayConverter;
            // FixedConversionFactorConverter + 
            if (standardConversion.SourceUnit.Equals(sourceUnit) && standardConversion.TargetUnit.Equals(targetUnit))
            {
                return new Quantity(targetUnit, sourceQuantity.Amount * standardConversion.ConversionFactor);
            }

            if (standardConversion.TargetUnit.Equals(sourceUnit) && standardConversion.SourceUnit.Equals(targetUnit))
            {
                return new Quantity(targetUnit, sourceQuantity.Amount / standardConversion.ConversionFactor);
            }
        }

        throw new Exception("Unable to convert. No standard conversion found.");
    }
}
