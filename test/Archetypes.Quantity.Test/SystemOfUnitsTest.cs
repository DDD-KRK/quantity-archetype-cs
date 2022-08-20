using System.Collections.Generic;
using Xunit;

namespace Archetypes.Quantity.Test;

public class SystemOfUnitsTest
{
    public static IEnumerable<object?[]> GetTestData()
    {
        var systemOfUnits = new SystemOfUnits("a", "b");

        //same instance
        yield return new object?[] {true, systemOfUnits, systemOfUnits};
        yield return new object?[] {false, systemOfUnits, null};

        //different instance, same values
        yield return new object?[] {true, systemOfUnits, new SystemOfUnits("a", "b")};

        //different instance, different values
        yield return new object?[] {false, systemOfUnits, new SystemOfUnits("xa", "xb")};
        yield return new object?[] {false, systemOfUnits, new SystemOfUnits("xa", "b")};
        yield return new object?[] {false, systemOfUnits, new SystemOfUnits("a", "xb")};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestSystemOfUnitsEquability(bool expectedResult, SystemOfUnits a, SystemOfUnits? b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }
}
