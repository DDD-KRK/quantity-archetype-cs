namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

public class Kelvin : SIBaseUnit
{
    public override string GetName()
    {
        return "kelvin";
    }

    public override string GetSymbol()
    {
        return "K";
    }

    public override string GetDefinition()
    {
        return "The kelvin, unit of thermodynamic temperature, is the fraction 1/273.16 of the thermodynamic temperature of the triple point of water";
    }
}
