namespace Archetypes.Quantity;

public class DerivedUnitTerm
{
    public Unit Unit { get; }
    public int Power { get; }

    public DerivedUnitTerm(Unit unit, int power)
    {
        Unit = unit;
        Power = power;
    }
}
