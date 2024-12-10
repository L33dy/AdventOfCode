using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day6;

public class Day6(): Year2015(nameof(Day6))
{
    protected override string PartOne()
    {
        int totalLights = 0;
        
        int[,] grid = new int[999,999];

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = 0;
            }    
        }
        
        string input = ReadPlainInput(true);
        string[] lines = input.SplitInput();

        string instructionRegex = @"(turn (on|off) \d+,\d+)|(through \d+,\d+)|(toggle \d+,\d+)";

        foreach (var line in lines)
        {
            
        }
        
        
        return totalLights.ToString();
    }

    protected override string PartTwo()
    {
        return "";
    }
}