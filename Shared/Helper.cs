namespace AdventOfCode.Shared;

public static class Helper
{
    public static string[] SplitInput(this string input)
    {
        return input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }

    public static List<int> ConvertToIntList(this string input, char separator)
    {
        return input.Split(separator).Select(int.Parse).ToList();
    }
}