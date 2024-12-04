using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day1;

internal class Day1() : Year2024(nameof(Day1))
{
    protected override string PartOne()
    {
        int totalDistance = 0;
        
        string input = ReadPlainInput();
        string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        var leftCoordinates = new List<int>();
        var rightCoordinates = new List<int>();

        foreach (var line in lines)
        {
            string[] columns = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            leftCoordinates.Add(int.Parse(columns[0]));
            rightCoordinates.Add(int.Parse(columns[1]));
        }

        leftCoordinates.Sort();
        rightCoordinates.Sort();

        for (int i = 0; i < leftCoordinates.Count; i++)
        {
            int leftSmallest = leftCoordinates[i];
            int rightSmallest = rightCoordinates[i];

            int distance = Math.Abs(leftSmallest - rightSmallest);
            
            totalDistance += distance;
        }

        return totalDistance.ToString();
    }

    protected override string PartTwo()
    {
        int similarityScore = 0;

        string input = ReadPlainInput();
        string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        var leftCoordinates = new List<int>();
        var rightCoordinates = new List<int>();
        
        foreach (var line in lines)
        {
            string[] columns = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            
            leftCoordinates.Add(int.Parse(columns[0]));
            rightCoordinates.Add(int.Parse(columns[1]));
        }

        for (int i = 0; i < leftCoordinates.Count; i++)
        {
            int leftNum = leftCoordinates[i];
            int occurences = rightCoordinates.FindAll(n => n == leftNum).Count;

            similarityScore += (leftNum * occurences);
        }
        
        return similarityScore.ToString();
    }
}