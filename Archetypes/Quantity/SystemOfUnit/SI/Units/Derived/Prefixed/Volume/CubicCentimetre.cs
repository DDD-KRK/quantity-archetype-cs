using Archetypes.Quantity.SystemOfUnit.SI.Units.Base.Prefixed.Length;

namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Derived.Prefixed.Volume;

public class CubicCentimetre : SIDerivedUnit
{
    public override string GetName()
    {
        return "cubic centimeter";
    }

    public override string GetSymbol()
    {
        return "cm3";
    }

    public override string GetDefinition()
    {
        return "...";
    }

    public override DerivedUnitTerm[] GetTerms()
    {
        return new[] {new DerivedUnitTerm(new Centimetre(), 3)};
    }
}
