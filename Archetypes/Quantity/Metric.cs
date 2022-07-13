namespace Archetypes.Quantity;

public abstract class Metric : IEquatable<Metric>
{
    public abstract string GetName();
    public abstract string GetSymbol();
    public abstract string GetDefinition();

    public override bool Equals(object? obj)
    {
        return Equals(obj as Metric);
    }

    public bool Equals(Metric? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return other.GetType() == GetType() &&
               other.GetName().Equals(GetName()) &&
               other.GetSymbol().Equals(GetSymbol()) &&
               other.GetDefinition().Equals(GetDefinition());
    }

    public override int GetHashCode()
    {
        return (GetName(), GetSymbol(), GetDefinition()).GetHashCode();
    }

    public static bool operator ==(Metric? left, Metric? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Metric? left, Metric? right)
    {
        return !Equals(left, right);
    }
}
