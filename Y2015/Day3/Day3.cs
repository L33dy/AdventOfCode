using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day3;

public class Day3(): Year2015(nameof(Day3))
{
    protected override string PartOne()
    {
        int giftedHouses = 1;

        int x = 0;
        int y = 0;
        
        HashSet<string> coordinates = new HashSet<string>();

        coordinates.Add("0 0");

        string input = ReadPlainInput();
        string[] moves = input.SplitInput();

        foreach (var move in moves)
        {
            foreach (var m in move)
            {
                switch (m)
                {
                    case '>':
                        x++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    case '^':
                        y++;
                        break;
                }

                string pos = $"{x} {y}";
                
                bool good = coordinates.Add(pos);

                if (good)
                    giftedHouses++;
            }
        }
        
        return giftedHouses.ToString();
    }

    protected override string PartTwo()
    {
        int giftedHouses = 1;

        int santaX = 0;
        int santaY = 0;

        int roboX = 0;
        int roboY = 0;
        
        string input = ReadPlainInput();
        string[] lines = input.SplitInput();

        HashSet<string> coordinates = new HashSet<string>();
        coordinates.Add("0 0");

        bool robo = false;

        foreach (var line in lines)
        {
            foreach (var move in line)
            {
                if (!robo)
                {
                    switch (move)
                    {
                        case '>':
                            santaX++;
                            break;
                        case 'v':
                            santaY--;
                            break;
                        case '<':
                            santaX--;
                            break;
                        case '^':
                            santaY++;
                            break;
                    }

                    string pos = $"{santaX} {santaY}";

                    bool good = coordinates.Add(pos);

                    if (good)
                        giftedHouses++;
                }
                else
                {
                    switch (move)
                    {
                        case '>':
                            roboX++;
                            break;
                        case 'v':
                            roboY--;
                            break;
                        case '<':
                            roboX--;
                            break;
                        case '^':
                            roboY++;
                            break;
                    }

                    string pos = $"{roboX} {roboY}";

                    bool good = coordinates.Add(pos);

                    if (good)
                        giftedHouses++;
                }

                robo = !robo;
            }
        }
        
        return giftedHouses.ToString();
    }
}