using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015.Day8;

public class Day8(): Year2015(nameof(Day8))
{
    protected override string PartOne()
    {
        int numInCode = 0;
        int numInString = 0;
        
        string input = ReadPlainInput(true);
        string[] lines = input.SplitInput();

        foreach (var line in lines)
        {
            int codeLength = line.Length;

            string trimmed = line.Trim('"');
            string backslash = Regex.Replace(trimmed, @"(\\{2})", @"\");
            string quote = Regex.Replace(backslash, @"(\\"")", @"""");

            Console.WriteLine(quote);
            
            numInCode += codeLength;
            // numInString += stringLength;
        }
        
        return (numInCode - numInString).ToString();
    }

    protected override string PartTwo()
    {
        return "";
    }
}