namespace Archetypes.Quantity;

public abstract class Unit : Metric, IEquatable<Unit>
{
    public abstract SystemOfUnits GetSystemOfUnits();

    #region IEquatable

    public override bool Equals(object? obj)
    {
        return Equals(obj as Unit);
    }

    public bool Equals(Unit? other)
    {
        return base.Equals(other) && other.GetSystemOfUnits().Equals(GetSystemOfUnits());
    }

    public override int GetHashCode()
    {
        return (base.GetHashCode(), GetSystemOfUnits()).GetHashCode();
    }

    #endregion
}
