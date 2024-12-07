namespace AdventOfCode.Shared;

public static class StringExtensions
{
    public static string[] SplitInput(this string input)
    {
        return input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }

    public static List<int> ConvertToIntList(this string input, char separator)
    {
        return input.Split(separator).Select(int.Parse).ToList();
    }

    public static IEnumerable<char> TraverseHorizontal(this string[] lines)
    {
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                yield return lines[y][x];
            }
        }
    }

    public static IEnumerable<char> TraverseVertical(this string[] lines)
    {
        for (int x = 0; x < lines[0].Length; x++)
        {
            for (int y = 0; y < lines.Length; y++)
            {
                yield return lines[y][x];
            }
        }
    }

    public static IEnumerable<char> TraverseDiagonal(this string[] lines)
    {
        for (var y = 0; y < lines.Length; y++)
        {
            foreach (var c in TraverseLine(y, 0))
            {
                yield return c;
            }
        }

        for (var x = 1; x < lines[0].Length; x++)
        {
            foreach (var c in TraverseLine(0, x))
            {
                yield return c;
            }
        }

        IEnumerable<char> TraverseLine(int y, int x)
        {
            while (y < lines.Length && x < lines[y].Length)
            {
                yield return lines[y][x];

                y++;
                x++;
            }
        }
    }
}