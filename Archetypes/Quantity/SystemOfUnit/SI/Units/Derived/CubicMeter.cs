using Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Derived;

public class CubicMeter : SIDerivedUnit
{
    public override string GetName()
    {
        return "cubic meter";
    }

    public override string GetSymbol()
    {
        return "m3";
    }

    public override string GetDefinition()
    {
        return "...";
    }

    public override DerivedUnitTerm[] GetTerms()
    {
        return new[] {new DerivedUnitTerm(new Meter(), 3)};
    }
}
