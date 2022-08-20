namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

public class Candela : SIBaseUnit
{
    public override string GetName()
    {
        return "candela";
    }

    public override string GetSymbol()
    {
        return "cd";
    }

    public override string GetDefinition()
    {
        return "The candela is the luminous intensity, in a given direction, of a source that emits monochromatic radiation of frequency 540 x 10 12hertz and that has a radiant intensity in that direction of 1/683 watt per steradian";
    }
}
