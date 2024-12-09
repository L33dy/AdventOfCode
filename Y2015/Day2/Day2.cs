using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day2;

public class Day2(): Year2015(nameof(Day2))
{
    protected override string PartOne()
    {
        int total = 0;
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        foreach (var line in lines)
        {
            int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

            int length = dimensions[0];
            int width = dimensions[1];
            int height = dimensions[2];

            Array.Sort(dimensions);

            int smallestArea = dimensions[0] * dimensions[1];

            total += 2 * length * width + 2 * width * height + 2 * height * length + smallestArea;
        }
        
        return total.ToString();
    }

    protected override string PartTwo()
    {
        int ribbon = 0;

        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        foreach (var line in lines)
        {
            int[] dimensions = line.Split('x').Select(int.Parse).ToArray();

            Array.Sort(dimensions);
            
            int length = dimensions[0];
            int width = dimensions[1];
            int height = dimensions[2];

            ribbon += length * 2 + width * 2 + length * width * height;
        }
        
        return ribbon.ToString();
    }
}