namespace Courseloop.Models.Sanitisers;

using System.Text.RegularExpressions;

public static class HTMLTagStripper
{
    private static readonly Regex filterHtmlTags = new("<.>(.*?)<\\/.>", RegexOptions.Compiled);
    public static string StripHtmlTags(string input)
    {
        if (input is null)
            return string.Empty;

        var output = filterHtmlTags.Match(input);
        if (output.Groups.Count >= 2)
            return output.Groups[1].Value;
        else
            return input;
    }
}
