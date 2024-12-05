using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day2;

public class Day2(): Year2024(nameof(Day2))
{
    protected override string PartOne()
    {
        int safeReports = 0;
        
        string input = ReadPlainInput();
        string[] splitted = input.SplitInput();
        
        foreach (var line in splitted)
        {
            var report = line.ConvertToIntList(' ');
            
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
        string[] splitted = input.SplitInput();

        foreach (var line in splitted)
        {
            var report = line.ConvertToIntList(' ');

            var order = report[0] > report[1];
            bool isSafe = false;

            isSafe = order ? Descend(report) : Ascend(report);

            if (isSafe)
            {
                safeReports++;
            }
            else
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var removed = report[i];
                    report.RemoveAt(i);

                    order = report[0] > report[1];
                    
                    isSafe = order ? Descend(report) : Ascend(report);

                    if (isSafe)
                    {
                        safeReports++;
                        break;
                    }

                    report.Insert(i, removed);
                }
            }
        }
        
        
        return safeReports.ToString();
    }

    private bool Descend(List<int> report)
    {
        for (int i = 0; i < report.Count - 1; i++)
        {
            var difference = Math.Abs(report[i] - report[i + 1]);

            if (report[i] <= report[i + 1] || difference >= 4)
            {
                return false;
            }
        }

        return true;
    }

    private bool Ascend(List<int> report)
    {
        for (int i = 0; i < report.Count - 1; i++)
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