namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

public class Mole : SIBaseUnit
{
    public override string GetName()
    {
        return "mole";
    }

    public override string GetSymbol()
    {
        return "mol";
    }

    public override string GetDefinition()
    {
        return "The mole is the amount of substance of a system which contains as many elementary entities as there are atoms in 0.012 kilogram of carbon 12";
    }
}
