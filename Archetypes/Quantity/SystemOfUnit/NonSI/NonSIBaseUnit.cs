namespace Archetypes.Quantity.SystemOfUnit.NonSI;

public abstract class NonSIBaseUnit : Unit
{
    public override SystemOfUnits GetSystemOfUnits() => new NonSISystem();
}
