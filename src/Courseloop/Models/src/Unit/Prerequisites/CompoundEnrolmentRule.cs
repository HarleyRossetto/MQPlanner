namespace Courseloop.Models.Unit.Prerequisites;

using System.Collections.Generic;


public record CompoundEnrolmentRule : EnrolmentRule
{
    public CompoundType RuleCompoundType { get; init; }
    public List<EnrolmentRule> Rules { get; init; }
}

public enum CompoundType
{
    AND,
    OR
}
