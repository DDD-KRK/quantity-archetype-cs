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
        Assert.StrictEqual(_quantity, other);

        return this;
    }
}
