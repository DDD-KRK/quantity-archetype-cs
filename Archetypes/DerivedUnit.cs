namespace Archetypes;

//todo covnert back to normal class and create factory for derived units
public abstract class DerivedUnit : Unit
{
    // todo at least one
    /// <summary>
    /// Sequence matters
    /// </summary>
    public abstract DerivedUnitTerm[] GetTerms();
}