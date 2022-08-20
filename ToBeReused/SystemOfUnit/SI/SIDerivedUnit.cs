namespace Archetypes.Quantity.SystemOfUnit.SI;

public class SIDerivedUnit : DerivedUnit
{
    public SIDerivedUnit(string name, string symbol, string definition, DerivedUnitTerm[] terms) : base(new SISystem(), name, symbol, definition, terms)
    {
    }
}
