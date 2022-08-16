namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

public class Meter : SIBaseUnit
{
    public override string GetName()
    {
        return "meter";
    }

    public override string GetSymbol()
    {
        return "m";
    }

    public override string GetDefinition()
    {
        return "The meter is the length of the path travelled by light in vacuum during a time interval of 1/299792458 of a second";
    }
}
