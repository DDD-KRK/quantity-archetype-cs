namespace Archetypes.Quantity.Conversion;

public class StandardConversion
{
    public Unit SourceUnit { get; }
    public Unit TargetUnit { get; }
    public double ConversionFactor { get; }
    public bool OneWayConversion { get; }

    public StandardConversion(Unit sourceUnit, Unit targetUnit, double conversionFactor, bool oneWayConversion = false)
    {
        SourceUnit = sourceUnit;
        TargetUnit = targetUnit;
        ConversionFactor = conversionFactor;
        OneWayConversion = oneWayConversion;
    }
}
