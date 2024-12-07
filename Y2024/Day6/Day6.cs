using System.Numerics;
using System.Security.Cryptography;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2024.Day6;

public class Day6(): Year2024(nameof(Day6))
{
    private readonly char[] _guards = ['v', '^', '>', '<'];
    
    private char[,] map;
    private Vector2 guardPos;

    protected override string PartOne()
    {
        int visitedPositions = 0;
        
        string input = ReadPlainInput(true);
        string[] lines = input.SplitInput();

        int sizeX = lines[0].Length;
        int sizeY = lines.Length;

        map = InitializeMap(sizeX, sizeY, lines);

        while (guardPos.X <= sizeX && guardPos.X >= 0 && guardPos.Y <= sizeY && guardPos.Y >= 0)
        {
            guardPos = FindGuardPos();
            string direction = GetGuardDirection(guardPos);

            Console.WriteLine(guardPos);

            int posX = (int)guardPos.X;
            int posY = (int)guardPos.Y;

            if (direction == "up")
            {
                char obstruction = GetObstruction(posX, posY - 1);

                if (obstruction == '.')
                {
                    map[posX, posY] = '.';
                    map[posX, posY - 1] = '^';

                    visitedPositions++;
                }
                else if (obstruction == '#')
                {
                    map[posX, posY] = '>';
                }
            }
            else if (direction == "right")
            {
                char obstruction = GetObstruction(posX + 1, posY);

                if (obstruction == '.')
                {
                    map[posX, posY] = '.';
                    map[posX + 1, posY] = '>';

                    visitedPositions++;
                }
                else if (obstruction == '#')
                {
                    map[posX, posY] = 'v';
                }
            }
            else if (direction == "down")
            {
                char obstruction = GetObstruction(posX, posY + 1);

                if (obstruction == '.')
                {
                    map[posX, posY] = '.';
                    map[posX, posY + 1] = 'v';

                    visitedPositions++;
                }
                else if (obstruction == '#')
                {
                    map[posX, posY] = '<';
                }
            }
            else if (direction == "left")
            {
                char obstruction = GetObstruction(posX - 1, posY);

                if (obstruction == '.')
                {
                    map[posX, posY] = '.';
                    map[posX - 1, posY] = '<';

                    visitedPositions++;
                }
                else if (obstruction == '#')
                {
                    map[posX, posY] = '^';
                }
            }
        }
        
        return visitedPositions.ToString();
    }

    protected override string PartTwo()
    {
        return "";
    }

    private char GetObstruction(int x, int y)
    {
        return map[x, y];
    }

    private char[,] InitializeMap(int sizeX, int sizeY, string[] lines)
    {
        char[,] map = new char[sizeX, sizeY];
        
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                map[x, y] = lines[x][y];
            }
        }

        return map;
    }

    private Vector2 FindGuardPos()
    {
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (_guards.Any(c => c == map[x, y]))
                {
                    return new Vector2(x, y);
                }
            }
        }

        return new Vector2(0, 0);
    }

    private string GetGuardDirection(Vector2 pos)
    {
        char guard = map[(int)pos.X, (int)pos.Y];

        return guard switch
        {
            '^' => "up",
            '>' => "right",
            '<' => "left",
            'v' => "down",
            _ => ""
        };
    }
}