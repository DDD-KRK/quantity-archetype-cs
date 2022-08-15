using Archetypes.Quantity.Conversion;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base.Prefixed.Length;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Base.Prefixed.Mass;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Derived;
using Archetypes.Quantity.SystemOfUnit.SI.Units.Derived.Prefixed.Volume;

namespace Archetypes.Quantity.SystemOfUnit.SI;

public class SISystem : SystemOfUnits
{
    public SISystem() : base("SI", "BIPM")
    {
        StandardConversions = new StandardConversion[]
        {
            new(new Kilogram(), new Gram(), SiPrefixes.Kilo),
            new(new Decimetre(), new Meter(), SiPrefixes.Deci),
            new(new Centimetre(), new Meter(), SiPrefixes.Centi),
            new(new CubicDecimetre(), new CubicMeter(), Math.Pow(SiPrefixes.Deci, 3)),
            new(new CubicCentimetre(), new CubicMeter(), Math.Pow(SiPrefixes.Centi, 3)),
        };
    }

    private static class SiPrefixes
    {
        public const double Yotta = 1000000000000000000000000.0;
        public const double Zetta = 1000000000000000000000.0;
        public const double Exa = 1000000000000000000.0;
        public const double Peta = 1000000000000000.0;
        public const double Tera = 1000000000000.0;
        public const double Giga = 1000000000.0;
        public const double Mega = 1000000.0;
        public const double Kilo = 1000.0;
        public const double Hecto = 100.0;
        public const double Deca = 10.0;

        public const double Deci = 0.1;
        public const double Centi = 0.01;
        public const double Milli = 0.001;
        public const double Micro = 0.000001;
        public const double Nano = 0.000000001;
        public const double Pico = 0.000000000001;
        public const double Femto = 0.000000000000001;
        public const double Atto = 0.000000000000000001;
        public const double Zepto = 0.000000000000000000001;
        public const double Yocto = 0.000000000000000000000001;
    }
}
