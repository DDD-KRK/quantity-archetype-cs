using Archetypes.Quantity.SystemOfUnit.SI.Units.Base.Prefixed.Length;

namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Derived.Prefixed.Volume;

public class CubicDecimetre : SIDerivedUnit
{
    public override string GetName()
    {
        return "cubic decimeter";
    }

    public override string GetSymbol()
    {
        return "dm3";
    }

    public override string GetDefinition()
    {
        return "...";
    }

    public override DerivedUnitTerm[] GetTerms()
    {
        return new[] {new DerivedUnitTerm(new Decimetre(), 3)};
    }
}
