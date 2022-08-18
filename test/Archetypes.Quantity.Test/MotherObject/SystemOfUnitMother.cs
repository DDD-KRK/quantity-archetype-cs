using System;

namespace Archetypes.Quantity.Test.MotherObject;

public static class SystemOfUnitMother
{
    public static SystemOfUnits GetUnique()
    {
        return new SystemOfUnits(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
        );
    }

}
