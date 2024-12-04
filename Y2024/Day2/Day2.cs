using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day2;

public class Day2(): Year2024(nameof(Day2))
{
    protected override string PartOne()
    {
        int safeReports = 0;
        
        string input = ReadPlainInput();
        string[] splitted = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        List<int[]> reports = new List<int[]>();
        
        foreach (var line in splitted)
        {
            int[] levels = line.Split(' ').Select(int.Parse).ToArray();
            
            reports.Add(levels);
        }

        foreach (var report in reports)
        {
            var order = report[0] > report[1];

            if (order)
                safeReports += Descend(report) ? 1 : 0;
            else
                safeReports += Ascend(report) ? 1 : 0;
        }
        
        return safeReports.ToString();
    }

    protected override string PartTwo()
    {
        int safeReports = 0;

        string input = ReadPlainInput();
        string[] splitted = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        var reports = new List<int[]>();

        foreach (var line in splitted)
        {
            int[] levels = line.Split(' ').Select(int.Parse).ToArray();
            
            reports.Add(levels);
        }
        
        
        
        return safeReports.ToString();
    }

    private bool Descend(int[] report)
    {
        for (int i = 0; i < report.Length - 1; i++)
        {
            var difference = Math.Abs(report[i] - report[i + 1]);

            if (report[i] <= report[i + 1] || difference >= 4)
            {
                return false;
            }
        }

        return true;
    }

    private bool Ascend(int[] report)
    {
        for (int i = 0; i < report.Length - 1; i++)
        {
            var difference = Math.Abs(report[i] - report[i + 1]);

            if (report[i] >= report[i + 1] || difference >= 4)
            {
                return false;
            }
        }

        return true;
    }
}