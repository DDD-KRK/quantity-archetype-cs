namespace Archetypes.Quantity.SystemOfUnit.SI;

public static class SIUnitFactory
{
    private static readonly Dictionary<string, Unit> AvailableUnits = new ();
    static SIUnitFactory()
    {
        var siSystem = new SISystem();
        AvailableUnits.Add(SIUnit.Kilogram, new Unit(siSystem, "Kilogram", "kg", "..."));
        AvailableUnits.Add(SIUnit.Decagram, new Unit(siSystem, "Decagram", "dag", "..."));
        AvailableUnits.Add(SIUnit.Gram, new Unit(siSystem, "Gram", "g", "..."));
        
    }

    public static Unit? CreateFromSymbol(string symbol)
    {
        return AvailableUnits.GetValueOrDefault(symbol);
    }
}

public static class SIUnit
{
    public static readonly string Kilogram = "si_kg";
    public static readonly string Decagram = "si_dag";
    public static readonly string Gram = "si_g";
}

public static class AvailableUnits
{
    public static Unit[] Get()
    {
        return new[] {SIUnitFactory.CreateFromSymbol(SIUnit.Kilogram), SIUnitFactory.CreateFromSymbol(SIUnit.Gram)};
    }
}
/*
 *
 * 1. czytanie z DB i konwersja na obiekt, np. nazwa-skrócona-układu_symbol; si_kg => Unit(SISystem, Kilogram)
 * 2. Konwersja
 * 3. Wylistowanie dostepnych jednostek
 * 
 */
