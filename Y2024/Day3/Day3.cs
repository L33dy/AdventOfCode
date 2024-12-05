using System.Text.RegularExpressions;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day3;

public class Day3() : Year2024(nameof(Day3))
{
    protected override string PartOne()
    {
        int result = 0;

        string input = ReadPlainInput();
        string mulPattern = @"mul\(\d{0,3},\d{0,3}\)"; // mul(x,y) -> x = 1 - 999; y = 1 - 999

        MatchCollection matches = Regex.Matches(input, mulPattern);

        foreach (Match match in matches)
        {
            string numPattern = @"\d+"; // x && y
            MatchCollection numbers = Regex.Matches(match.Value, numPattern);

            int num1 = int.Parse(numbers[0].Value);
            int num2 = int.Parse(numbers[1].Value);

            result += num1 * num2;
        }

        return result.ToString();
    }

    protected override string PartTwo()
    {
        int result = 0;
        string input = ReadPlainInput();
        string pattern = @"mul\(\d{0,3},\d{0,3}\)|do\(\)|don't\(\)";

        MatchCollection matches = Regex.Matches(input, pattern);

        bool enable = true;

        foreach (Match match in matches)
        {
            if (match.Value == "don't()")
            {
                enable = false;
                continue;
            }
            
            if (match.Value == "do()")
            {
                enable = true;
                continue;
            }

            if (!enable) continue;

            string numPattern = @"\d+";
            MatchCollection numbers = Regex.Matches(match.Value, numPattern);

            int num1 = int.Parse(numbers[0].Value);
            int num2 = int.Parse(numbers[1].Value);

            result += num1 * num2;
        }

        return result.ToString();
    }
}