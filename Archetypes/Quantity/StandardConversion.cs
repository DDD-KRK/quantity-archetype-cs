namespace Archetypes.Quantity;

public class StandardConversion
{
    public Unit SourceUnit { get; }
    public Unit TargetUnit { get; }
    public double ConversionFactor { get; }

    public StandardConversion(Unit sourceUnit, Unit targetUnit, double conversionFactor)
    {
        SourceUnit = sourceUnit;
        TargetUnit = targetUnit;
        ConversionFactor = conversionFactor;
    }
}
