namespace Archetypes.SI;

public abstract class SIBaseUnit: Unit
{
    public override SystemOfUnits GetSystemOfUnits() => new SISystem();
}