namespace Archetypes.Quantity;

public class DerivedUnit : Unit
{
    /// <summary>
    /// At least one element. Sequence matters.
    /// </summary>
    public DerivedUnitTerm[] Terms { get; }

    public DerivedUnit(SystemOfUnits systemOfUnits, string name, string symbol, string definition, DerivedUnitTerm[] terms) : base(systemOfUnits, name, symbol, definition)
    {
        if (terms.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(terms));
        Terms = terms;
    }
}
