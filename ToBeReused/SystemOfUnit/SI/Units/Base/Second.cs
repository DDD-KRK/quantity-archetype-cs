namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

class Second : SIBaseUnit
{
    public override string GetName()
    {
        return "second";
    }

    public override string GetSymbol()
    {
        return "s";
    }

    public override string GetDefinition()
    {
        return "The second is the duration of 9,192,631,770 periods of the radiation corresponding to the transition between the two hyperfine levels of the ground state of the cesium 133 atom";
    }
}
