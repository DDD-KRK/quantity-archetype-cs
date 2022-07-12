using Archetypes.SI.Units.Base;

namespace Archetypes.Quantity;

public class UnitConverter
{
    private readonly StandardConversion[] _standardConversions;
    
    public UnitConverter()
    {
        _standardConversions = new []
        {
            new StandardConversion(new Gram(), new Kilogram(), 0.001),
            new StandardConversion(new Kilogram(), new Gram(), 1000),
        };
    }

    public Quantity Convert(Quantity quantity, Unit targetUnit)
    {
        foreach (var standardConversion in _standardConversions)
        {
            if(
                standardConversion.SourceUnit.GetSymbol().Equals(quantity.GetMetric().GetSymbol())
                && standardConversion.TargetUnit.GetSymbol().Equals(targetUnit.GetSymbol())
                )
            {
                return new Quantity(targetUnit, quantity.GetAmount() * standardConversion.ConversionFactor);
            }
        }

        //todo handle unmatched conversion
        return quantity;
    }
}
