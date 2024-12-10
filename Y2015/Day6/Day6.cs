using System.Text.RegularExpressions;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day6;

public class Day6(): Year2015(nameof(Day6))
{
    protected override string PartOne()
    {
        int totalLights = 0;
        
        int[,] grid = new int[1000,1000];

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = 0;
            }    
        }
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        string instructionsPattern = @"(turn (on|off) \d+,\d+)|(through \d+,\d+)|(toggle \d+,\d+)";

        foreach (var line in lines)
        {
            MatchCollection instructions = Regex.Matches(line, instructionsPattern);

            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;

            string primaryInstruction = "";

            foreach (Match instruction in instructions)
            {
                string instr = Regex.Match(instruction.Value, @"(turn on|turn off|toggle|through)").Value;
                int[] positions = Regex.Match(instruction.Value, @"(\d+,\d+)").Value.Split(',').Select(int.Parse).ToArray();

                int x = positions[0];
                int y = positions[1];

                if (instr == "through")
                {
                    endX = x;
                    endY = y;
                }
                else
                {
                    startX = x;
                    startY = y;

                    primaryInstruction = instr;
                }
            }

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    if (primaryInstruction == "turn on")
                    {
                        grid[x, y] = 1;
                    }
                    else if (primaryInstruction == "turn off")
                    {
                        grid[x, y] = 0;
                    }
                    else if (primaryInstruction == "toggle")
                    {
                        grid[x, y] = grid[x, y] == 1 ? 0 : 1;
                    }
                }
            }
        }

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] == 1)
                {
                    totalLights++;
                }
            }
        }
        
        return totalLights.ToString();
    }
    
    protected override string PartTwo()
    {
        int totalBrightness = 0;
        
        int[,] grid = new int[1000,1000];

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = 0;
            }    
        }
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        string instructionsPattern = @"(turn (on|off) \d+,\d+)|(through \d+,\d+)|(toggle \d+,\d+)";

        foreach (var line in lines)
        {
            MatchCollection instructions = Regex.Matches(line, instructionsPattern);

            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;

            string primaryInstruction = "";

            foreach (Match instruction in instructions)
            {
                string instr = Regex.Match(instruction.Value, @"(turn on|turn off|toggle|through)").Value;
                int[] positions = Regex.Match(instruction.Value, @"(\d+,\d+)").Value.Split(',').Select(int.Parse).ToArray();

                int x = positions[0];
                int y = positions[1];

                if (instr == "through")
                {
                    endX = x;
                    endY = y;
                }
                else
                {
                    startX = x;
                    startY = y;

                    primaryInstruction = instr;
                }
            }

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    if (primaryInstruction == "turn on")
                    {
                        grid[x, y] += 1;
                    }
                    else if (primaryInstruction == "turn off")
                    {
                        grid[x, y] -= grid[x, y] > 0 ? 1 : 0;
                    }
                    else if (primaryInstruction == "toggle")
                    {
                        grid[x, y] += 2;
                    }
                }
            }
        }

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                totalBrightness += grid[x, y];
            }
        }
        
        return totalBrightness.ToString();
    }
}