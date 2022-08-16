using Archetypes.Quantity.Rounding;

namespace Archetypes.Quantity;

public class Quantity
{
    public Unit Unit { get; }
    public double Amount { get; }

    public Quantity(Unit unit, double amount)
    {
        Unit = unit;
        Amount = amount;
    }

    public Quantity Add(Quantity quantity)
    {
        AssertIsTheSameUnit(quantity);

        return NewInstance(Amount + quantity.Amount);
    }

    public Quantity Subtract(Quantity quantity)
    {
        AssertIsTheSameUnit(quantity);

        return NewInstance(Amount - quantity.Amount);
    }

    public Quantity Multiply(double multiplier)
    {
        throw new NotImplementedException();
    }

    public Quantity Multiply(Quantity quantity)
    {
        throw new NotImplementedException();
    }

    public Quantity Divide(double divisor)
    {
        throw new NotImplementedException();
    }

    public Quantity Divide(Quantity quantity)
    {
        throw new NotImplementedException();
    }

    public Quantity Round(RoundingPolicy policy)
    {
        switch (policy.RoundingStrategy)
        {
            case RoundingStrategy.RoundUp:
                return NewInstance(Math.Round(Amount, policy.NumberOfDigits, MidpointRounding.ToPositiveInfinity));
            case RoundingStrategy.RoundDown:
                return NewInstance(Math.Round(Amount, policy.NumberOfDigits, MidpointRounding.ToNegativeInfinity));
            case RoundingStrategy.Round:
                throw new NotImplementedException();
            case RoundingStrategy.RoundUpByStep:
                throw new NotImplementedException();
            case RoundingStrategy.RoundDownByStep:
                throw new NotImplementedException();
            case RoundingStrategy.RoundTowardsPositive:
                throw new NotImplementedException();
            case RoundingStrategy.RoundTowardsNegative:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool EqualTo(Quantity quantity)
    {
        AssertIsTheSameUnit(quantity);

        return Math.Abs(Amount - quantity.Amount) < 0;
    }

    //todo research the obj equality topic
    // public override bool Equals(object? obj)
    // {
    //     if (ReferenceEquals(this, obj)) return true;
    //     if (ReferenceEquals(obj, null)) return false;
    //     if (GetType() != obj.GetType()) return false;
    //     return EqualTo(obj as Archetypes.Quantity);
    // }
    //
    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(_metric, _amount);
    // }

    public bool GreaterThan(Quantity quantity)
    {
        throw new NotImplementedException();
    }

    public bool LessThan(Quantity quantity)
    {
        throw new NotImplementedException();
    }

    private Quantity NewInstance(double amount)
    {
        return new Quantity(Unit, amount);
    }

    private void AssertIsTheSameUnit(Quantity other)
    {
        if (!other.Unit.Equals(Unit)) throw new ArgumentException("Operation allowed only on the same unit.", nameof(other));
    }
}
