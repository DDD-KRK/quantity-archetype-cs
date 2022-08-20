using Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Derived;

// todo @see DerivedUnit
public class Velocity : SIDerivedUnit
{
    public override string GetName()
    {
        return "velocity";
    }

    public override string GetSymbol()
    {
        return "v";
    }

    public override string GetDefinition()
    {
        return "...";
    }

    public override DerivedUnitTerm[] GetTerms()
    {
        return new[] {new DerivedUnitTerm(new Meter(), 1), new DerivedUnitTerm(new Second(), -1)};
    }
}
