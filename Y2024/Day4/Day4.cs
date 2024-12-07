using System.Text.RegularExpressions;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day4;

public class Day4(): Year2024(nameof(Day4))
{
    protected override string PartOne()
    {
        int count = 0;
        
        string input = ReadPlainInput(true);
        string[] rows = input.SplitInput();

        string horizontal = new String(rows.TraverseHorizontal().ToArray());
        string vertical = new String(rows.TraverseVertical().ToArray());
        string diagonal = new String(rows.TraverseDiagonal().ToArray());

        Console.WriteLine(horizontal);
        Console.WriteLine(vertical);
        Console.WriteLine(diagonal);
        
        string pattern = @"(?=(XMAS|SAMX))";

        MatchCollection horizontalMatches = Regex.Matches(horizontal, pattern);
        MatchCollection verticalMatches = Regex.Matches(vertical, pattern);
        MatchCollection diagonalMatches = Regex.Matches(diagonal, pattern);

        count += horizontalMatches.Count;
        count += verticalMatches.Count;
        count += diagonalMatches.Count;
        
        return count.ToString();
    }

    protected override string PartTwo()
    {
        return "";
    }
}