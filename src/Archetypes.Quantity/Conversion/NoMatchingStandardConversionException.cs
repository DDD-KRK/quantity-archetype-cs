namespace Archetypes.Quantity.Conversion;

public sealed class NoMatchingStandardConversionException : Exception
{
    public NoMatchingStandardConversionException(Unit sourceUnit, Unit targetUnit)
    {
        Data["sourceUnit"] = sourceUnit.Name;
        Data["targetUnit"] = targetUnit.Name;
    }

    public override string Message =>
        string.Format("No matching standard conversion found for source unit \"{0}\" and target unit \"{1}\" ", Data["sourceUnit"], Data["targetUnit"]);
}
