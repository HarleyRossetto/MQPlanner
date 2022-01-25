namespace Courseloop.Models.Unit.Prerequisites;

using System;
using System.Text;

public class PrerequisiteRequirements
{

}

public record CreditPointRequirement
{
    public int CreditPoints { get; init; }
    public int? Level { get; init; }
    public bool OrAbove { get; init; }
    public bool Including { get; init; }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(CreditPoints).Append(" credit points");

        if (Level is not null)
        {
            sb.Append(" at ").Append(Level);

            if (OrAbove)
            {
                sb.Append(" or above");
            }

            if (Including)
            {
                sb.Append(" including");
            }
        }
        return sb.ToString();
    }
}
