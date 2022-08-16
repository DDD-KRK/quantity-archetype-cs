using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.SystemOfUnit.NonSI.Units.Volume;
using Archetypes.Quantity.SystemOfUnit.NonSI.Units.Volume.Prefixed;

namespace Archetypes.Quantity.SystemOfUnit.NonSI;

public class NonSISystem : SystemOfUnits
{
    public NonSISystem() : base("Non-SI units mentioned in the SI", "-")
    {
        StandardConversions = new StandardConversion[]
        {
            new(new Liter(), new Millilitre(), 0.001),
        };
    }
}
