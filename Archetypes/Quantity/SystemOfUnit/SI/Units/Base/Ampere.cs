namespace Archetypes.Quantity.SystemOfUnit.SI.Units.Base;

public class Ampere : SIBaseUnit
{
    public override string GetName()
    {
        return "ampere";
    }

    public override string GetSymbol()
    {
        return "A";
    }

    public override string GetDefinition()
    {
        return "The ampere is that constant current which, if maintained in two straight parallel conductors of infinite length, of negligible circular cross-section, and placed 1 meter apart in vacuum, would produce between these conductors a force equal to 2 x 10 –7 newton per meter of length";
    }
}
