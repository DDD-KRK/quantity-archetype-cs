using Archetypes.Quantity;

namespace Archetypes.Test.Quantity;

public class UnitInstance : Unit
{
    private string Name { get; }
    private string Symbol { get; }
    private string Definition { get; }
    private SystemOfUnits SystemOfUnits { get; }

    public UnitInstance(string name, string symbol, string definition, SystemOfUnits systemOfUnits)
    {
        Name = name;
        Symbol = symbol;
        Definition = definition;
        SystemOfUnits = systemOfUnits;
    }

    public override string GetName()
    {
        return Name;
    }

    public override string GetSymbol()
    {
        return Symbol;
    }

    public override string GetDefinition()
    {
        return Definition;
    }

    public override SystemOfUnits GetSystemOfUnits()
    {
        return SystemOfUnits;
    }

    public override string ToString()
    {
        return (Name, Symbol).ToString();
    }
}
