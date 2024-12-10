using System.Text.RegularExpressions;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day5;

public class Day5(): Year2015(nameof(Day5))
{
    protected override string PartOne()
    {
        int count = 0;
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        foreach (var line in lines)
        {
            if (GetVowels(line) >= 3 && !IsRestricted(line) && HasDoubleLetters(line))
            {
                count++;
            }
        }
        
        return count.ToString();
    }

    protected override string PartTwo()
    {
        int count = 0;
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        foreach (var line in lines)
        {
            if (RepeatsCorrectly(line) && HasPair(line))
            {
                count++;
            }
        }
        
        return count.ToString();
    }
    
    private bool HasPair(string input)
    {
        return Regex.IsMatch(input, @"(\w{2}).*?\1");
    }

    private bool RepeatsCorrectly(string input)
    {
        return Regex.IsMatch(input, @"(.)(.)\1");
    }

    private int GetVowels(string input)
    {
        char[] vowels = ['a', 'e', 'i', 'o', 'u'];

        return input.Count(c => vowels.Contains(c));
    }

    private bool IsRestricted(string input)
    {
        string[] restricted = ["ab", "cd", "pq", "xy"];

        return restricted.Any(input.Contains);
    }

    private bool HasDoubleLetters(string input)
    {
        return Regex.IsMatch(input, @"(.)\1");
    }
}