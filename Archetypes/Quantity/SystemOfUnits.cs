using Archetypes.Quantity.Conversion;

namespace Archetypes.Quantity;

public class SystemOfUnits : IEquatable<SystemOfUnits>
{
    public string NameOfSystem { get; }
    public string NameOfStandardizationBody { get; }

    public SystemOfUnits(string nameOfSystem, string nameOfStandardizationBody)
    {
        NameOfSystem = nameOfSystem;
        NameOfStandardizationBody = nameOfStandardizationBody;
    }

    #region IEquatable

    public override bool Equals(object? obj)
    {
        return Equals(obj as SystemOfUnits);
    }

    public bool Equals(SystemOfUnits? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return NameOfSystem == other.NameOfSystem && NameOfStandardizationBody == other.NameOfStandardizationBody;
    }

    public override int GetHashCode()
    {
        return (NameOfSystem, NameOfStandardizationBody).GetHashCode();
    }

    public static bool operator ==(SystemOfUnits? left, SystemOfUnits? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(SystemOfUnits? left, SystemOfUnits? right)
    {
        return !Equals(left, right);
    }

    #endregion
}
