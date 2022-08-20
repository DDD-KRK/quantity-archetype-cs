namespace Archetypes.Quantity.SystemOfUnit.SI;

public class SIBaseUnit : Unit
{
    public SIBaseUnit(string name, string symbol, string definition) : base(new SISystem(), name, symbol, definition)
    {
    }
}
