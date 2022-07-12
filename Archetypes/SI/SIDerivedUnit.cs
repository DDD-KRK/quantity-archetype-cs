namespace Archetypes.SI;

public abstract class SIDerivedUnit: DerivedUnit
{
    public override SystemOfUnits GetSystemOfUnits() => new SISystem();
}
