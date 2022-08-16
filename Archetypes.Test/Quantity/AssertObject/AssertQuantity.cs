using Xunit;

namespace Archetypes.Test.Quantity.AssertObject;

public class AssertQuantity
{
    private readonly Archetypes.Quantity.Quantity _quantity;

    public AssertQuantity(Archetypes.Quantity.Quantity quantity)
    {
        _quantity = quantity;
    }

    public AssertQuantity IsEqualTo(Archetypes.Quantity.Quantity other)
    {
        //todo refactor when Quantity.Equals is implemented
        Assert.Equal(other.Amount, _quantity.Amount);
        Assert.Equal(other.Unit, _quantity.Unit);
       
        return this;
    }
}
