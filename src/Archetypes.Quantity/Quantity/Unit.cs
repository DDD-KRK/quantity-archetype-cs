namespace Archetypes.Quantity;

public class Unit: IEquatable<Unit>
{ 
    public SystemOfUnits SystemOfUnits { get; }
    public string Name { get; }
    public string Symbol { get; }
    public string Definition { get; }

    public Unit(SystemOfUnits systemOfUnits, string name, string symbol, string definition)
    {
        SystemOfUnits = systemOfUnits;
        Name = name;
        Symbol = symbol;
        Definition = definition;
    }

    #region IEquatable

    public override bool Equals(object? obj)
    {
        return Equals(obj as Unit);
    }

    public bool Equals(Unit? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

         return other.GetType() == GetType() &&
                other.SystemOfUnits.Equals(SystemOfUnits) &&
                other.Name.Equals(Name) &&
                other.Symbol.Equals(Symbol) &&
                other.Definition.Equals(Definition);
    }
    
    public static bool operator ==(Unit? left, Unit? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Unit? left, Unit? right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return (SystemOfUnits, Name, Symbol, Definition).GetHashCode();
    }

    #endregion
}
