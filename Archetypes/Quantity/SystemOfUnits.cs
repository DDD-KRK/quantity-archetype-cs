namespace Archetypes.Quantity;

public class SystemOfUnits
{
    private string _nameOfSystem;
    private string _nameOfStandardizationBody;

    public SystemOfUnits(string nameOfSystem, string nameOfStandardizationBody)
    {
        _nameOfSystem = nameOfSystem;
        _nameOfStandardizationBody = nameOfStandardizationBody;
    }
}
