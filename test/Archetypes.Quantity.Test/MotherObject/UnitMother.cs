using System;

namespace Archetypes.Quantity.Test.MotherObject;

public static class UnitMother
{
    public static Unit GetUnique()
    {
        return new Unit(
            SystemOfUnitMother.GetUnique(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
        );
    }
}
