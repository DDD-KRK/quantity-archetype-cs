namespace Archetypes;

public class DerivedUnitTerm
{
    private readonly Unit _unit;
    private readonly int _power;

    public DerivedUnitTerm(Unit unit, int power)
    {
        _unit = unit;
        _power = power;
    }

    public Unit GetUnit()
    {
        return _unit;
    }

    public int GetPower()
    {
        return _power;
    }

    public string GetName()
    {
        return _unit.GetName();
    }

    public string GetSymbol()
    {
        return _unit.GetSymbol();
    }

    public string GetDefinition()
    {
        return _unit.GetDefinition();
    }

    public SystemOfUnits GetSystemOfUnits()
    {
        return _unit.GetSystemOfUnits();
    }
}
