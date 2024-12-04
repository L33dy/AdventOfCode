namespace AdventOfCode.Shared.Years;

public abstract class Year2024(string day) : Solver("Y2024", day)
{
    public void Solve()
    {
        Console.WriteLine($"Year 2024: {day} Part 1 solution is: {PartOne()}");
        Console.WriteLine($"Year 2024: {day} Part 2 solution is: {PartTwo()}");
    }

    protected abstract string PartOne();
    protected abstract string PartTwo();
}