using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day7;

public class Day7(): Year2024(nameof(Day7))
{
    protected override string PartOne()
    {
        long sum = 0;
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        Dictionary<long, long[]> equations = new Dictionary<long, long[]>();

        foreach (var line in lines)
        {
            string[] splitted = line.Split(':');

            long product = long.Parse(splitted[0]);
            long[] equation = splitted[1].Trim().Split(' ').Select(long.Parse).ToArray();

            equations.Add(product, equation);
        }

        foreach (var e in equations)
        {
            long product = e.Key;
            long[] nums = e.Value;

            bool good = Check(product, 0, nums);

            if (good)
            {
                sum += product;
            }
        }
        
        return sum.ToString();
    }

    protected override string PartTwo()
    {
        long sum = 0;
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        Dictionary<long, long[]> equations = new Dictionary<long, long[]>();

        foreach (var line in lines)
        {
            string[] splitted = line.Split(':');

            long product = long.Parse(splitted[0]);
            long[] equation = splitted[1].Trim().Split(' ').Select(long.Parse).ToArray();

            equations.Add(product, equation);
        }

        foreach (var e in equations)
        {
            long product = e.Key;
            long[] nums = e.Value;

            bool good = Check(product, 0, nums, true);

            if (good)
            {
                sum += product;
            }
            
            // Console.WriteLine($"{product}: {good}");
        }
        
        return sum.ToString();
    }

    private bool Check(long target, long acc, long[] nums, bool part2 = false)
    {
        if (nums.Length == 0)
        {
            return target == acc;
        }

        long first = nums[0];
        long[] rest = nums[1..];

        if (part2)
        {
            return Check(target, acc * first, rest, true) || Check(target, acc + first, rest, true) 
                                                    || Check(target, long.Parse(acc.ToString() + first.ToString()), rest, true);
        }

        return Check(target, acc * first, rest) || Check(target, acc + first, rest);
    }
    
}