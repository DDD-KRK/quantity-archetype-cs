namespace Archetypes.Quantity;

public class SystemOfUnits : IEquatable<SystemOfUnits>
{
    private readonly string _nameOfSystem;
    private readonly string _nameOfStandardizationBody;

    public SystemOfUnits(string nameOfSystem, string nameOfStandardizationBody)
    {
        _nameOfSystem = nameOfSystem;
        _nameOfStandardizationBody = nameOfStandardizationBody;
    }

    public bool Equals(SystemOfUnits? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return _nameOfSystem == other._nameOfSystem && _nameOfStandardizationBody == other._nameOfStandardizationBody;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((SystemOfUnits) obj);
    }

    public override int GetHashCode()
    {
        return (_nameOfSystem, _nameOfStandardizationBody).GetHashCode();
    }

    public static bool operator ==(SystemOfUnits? left, SystemOfUnits? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(SystemOfUnits? left, SystemOfUnits? right)
    {
        return !Equals(left, right);
    }
}
