namespace Archetypes.Quantity;

public class Quantity
{
    private readonly Metric _metric;
    private readonly double _amount;

    public Quantity(Metric metric, double amount)
    {
        _metric = metric;
        _amount = amount;
    }

    public Metric GetMetric()
    {
        return _metric;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public Quantity Add(Quantity quantity)
    {
        AssertIsTheSameMetric(quantity);

        return NewInstance(_amount + quantity._amount);
    }

    public Quantity Subtract(Quantity quantity)
    {
        AssertIsTheSameMetric(quantity);

        return NewInstance(_amount - quantity._amount);
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
                return NewInstance(Math.Round(_amount, policy.NumberOfDigits, MidpointRounding.ToPositiveInfinity));
            case RoundingStrategy.RoundDown:
                return NewInstance(Math.Round(_amount, policy.NumberOfDigits, MidpointRounding.ToNegativeInfinity));
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
        AssertIsTheSameMetric(quantity);

        return Math.Abs(_amount - quantity._amount) < 0;
    }

    //todo research the obj equality topic
    // public override bool Equals(object? obj)
    // {
    //     if (ReferenceEquals(this, obj)) return true;
    //     if (ReferenceEquals(obj, null)) return false;
    //     if (GetType() != obj.GetType()) return false;
    //     return EqualTo(obj as Quantity);
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
        return new Quantity(_metric, amount);
    }

    private void AssertIsTheSameMetric(Quantity other)
    {
        //todo same metric requirement verification to be refactored
        if (_metric.GetSymbol() != other._metric.GetSymbol())
        {
            throw new ArgumentException();
        }
    }
}
