using System.Collections.Generic;
using Xunit;

namespace Archetypes.Quantity.Test;

public class SystemOfUnitsTest
{
    public static IEnumerable<object[]> GetTestData()
    {
        var systemOfUnits = new SystemOfUnits("xa", "xb");
        yield return new object[] {true, systemOfUnits, systemOfUnits};
        yield return new object[] {true, new SystemOfUnits("a", "b"), new SystemOfUnits("a", "b")};
        yield return new object[] {false, new SystemOfUnits("a", "b"), new SystemOfUnits("xa", "b")};
        yield return new object[] {false, new SystemOfUnits("a", "b"), new SystemOfUnits("a", "xb")};
        yield return new object[] {false, new SystemOfUnits("a", "b"), new SystemOfUnits("xa", "xb")};
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void TestSystemOfUnitsEquability(bool expectedResult, SystemOfUnits a, SystemOfUnits b)
    {
        Assert.Equal(expectedResult, a.Equals(b));
        Assert.Equal(expectedResult, a == b);
        Assert.Equal(!expectedResult, a != b);
    }
}
