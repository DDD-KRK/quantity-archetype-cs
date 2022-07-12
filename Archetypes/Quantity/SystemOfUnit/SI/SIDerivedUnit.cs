namespace Archetypes.Quantity.SystemOfUnit.SI;

public abstract class SIDerivedUnit : DerivedUnit
{
    public override SystemOfUnits GetSystemOfUnits() => new SISystem();
}
