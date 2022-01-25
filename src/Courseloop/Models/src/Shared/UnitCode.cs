namespace Courseloop.Models.Shared;

public record UnitCode
{
    public UnitCode(string code)
    {
        SubjectComponent = code[..4];
        NumericComponent = code[^4].ToString();
    }

    public string SubjectComponent { get; init; }
    public string NumericComponent { get; init; }

    public override string ToString()
    {
        return $"{SubjectComponent}{NumericComponent}";
    }
}

public record UnitCodeNumericComponent
{
    public UnitCodeNumericComponent(string s)
    {
        //TODO Parse string value into study level (1..8) etc and unit number (000..999) components.
    }

    public ushort StudyLevel { get; init; }
    public ushort UnitNumber { get; init; }
}