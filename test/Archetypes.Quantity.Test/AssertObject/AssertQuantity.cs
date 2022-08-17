using Xunit;

namespace Archetypes.Quantity.Test.AssertObject;

public class AssertQuantity
{
    private readonly Quantity _quantity;

    public AssertQuantity(Quantity quantity)
    {
        _quantity = quantity;
    }

    public AssertQuantity IsEqualTo(Quantity other)
    {
        //todo refactor when Archetypes.Quantity.Equals is implemented
        Assert.Equal(other.Amount, _quantity.Amount);
        Assert.Equal(other.Unit, _quantity.Unit);
       
        return this;
    }
}
