namespace Archetypes.Quantity.SystemOfUnit.SI;

public abstract class SIBaseUnit : Unit
{
    public override SystemOfUnits GetSystemOfUnits() => new SISystem();
}
