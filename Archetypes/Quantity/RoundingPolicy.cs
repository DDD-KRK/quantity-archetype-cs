using System.Diagnostics.CodeAnalysis;

namespace Archetypes.Quantity;

public class RoundingPolicy
{
    public RoundingStrategy RoundingStrategy { get; }
    public int NumberOfDigits { get; }
    public int RoundingDigit { get; }
    public double RoundingStep { get; }

    public RoundingPolicy(RoundingStrategy roundingStrategy, int? numberOfDigits, int? roundingDigit, double? roundingStep)
    {
        //todo verify required parameters per rounding strategy
        RoundingStrategy = roundingStrategy;
        NumberOfDigits = numberOfDigits ?? 0;
        RoundingDigit = roundingDigit ?? 0;
        RoundingStep = roundingStep ?? 1.0;
    }
}
