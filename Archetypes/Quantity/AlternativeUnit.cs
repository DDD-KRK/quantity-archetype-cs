namespace Archetypes.Quantity;

public sealed class AlternativeUnit : Metric, IEquatable<AlternativeUnit>
{
    public SystemOfUnits SystemOfUnits { get; }
    public string Name { get; }
    public string Symbol { get; }
    public string Definition { get; }

    public AlternativeUnit(SystemOfUnits systemOfUnits, string name, string symbol, string definition)
    {
        SystemOfUnits = systemOfUnits;
        Name = name;
        Symbol = symbol;
        Definition = definition;
    }

    public SystemOfUnits GetSystemOfUnits() => SystemOfUnits;
    public override string GetName() => Name;

    public override string GetSymbol() => Symbol;

    public override string GetDefinition() => Definition;

    #region IEquatable

    public override bool Equals(object? obj)
    {
        return Equals(obj as AlternativeUnit);
    }

    public bool Equals(AlternativeUnit? other)
    {
        return base.Equals(other) && other.GetSystemOfUnits().Equals(GetSystemOfUnits());
    }

    public override int GetHashCode()
    {
        return (base.GetHashCode(), GetSystemOfUnits()).GetHashCode();
    }

    #endregion
}
