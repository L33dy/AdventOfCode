﻿using System.Text.RegularExpressions;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day7;

public class Day7(): Year2015(nameof(Day7))
{
    protected override string PartOne()
    {
        Dictionary<string, ushort> wires = new Dictionary<string, ushort>();
        
        string input = ReadPlainInput(true);
        string[] lines = input.SplitInput();
        
        string notPattern = @"(NOT .+)";
        string andPattern = @"(.+ AND .+)";
        string orPattern = @"(.+ OR .+)";
        string lShiftPattern = @"(.+ LSHIFT \d+)";
        string rShiftPattern = @"(.+ RSHIFT \d+)";

        foreach (var line in lines)
        {
            string[] instructions = line.Split(new[] { "->" }, StringSplitOptions.TrimEntries);

            string instruction = instructions[0];
            string outputWire = instructions[1];

            /*Console.WriteLine(Regex.IsMatch(instruction, signalPattern));
            Console.WriteLine(Regex.IsMatch(instruction, andPattern));
            Console.WriteLine(Regex.IsMatch(instruction, orPattern));
            Console.WriteLine(Regex.IsMatch(instruction, notPattern));
            Console.WriteLine(Regex.IsMatch(instruction, lShiftPattern));
            Console.WriteLine(Regex.IsMatch(instruction, rShiftPattern));*/
            
            // NOT
            if (Regex.IsMatch(instruction, notPattern))
            {
                string target = instruction.Split(' ')[1];

                bool present = wires.TryGetValue(target, out ushort value);

                if (!present) continue;

                wires[outputWire] = (ushort)~value;
            }
            // AND
            else if (Regex.IsMatch(instruction, andPattern))
            {
                string[] targets = instruction.Split("AND");
                
                string targetX = targets[0].Trim();
                string targetY = targets[1].Trim();
                bool xPresent = true;
                bool yPresent = true;

                ushort valueX;
                ushort valueY;

                if (!IsOnlyNum(targetX))
                {
                    xPresent = wires.TryGetValue(targetX, out valueX);
                }
                else
                {
                    valueX = ushort.Parse(targetX);
                }

                if (!IsOnlyNum(targetY))
                {
                    yPresent = wires.TryGetValue(targetY, out valueY);
                }
                else
                {
                    valueY = ushort.Parse(targetY);
                }

                if (!xPresent || !yPresent) continue;

                wires[outputWire] = (ushort)(valueX & valueY);
            }
            // OR
            else if (Regex.IsMatch(instruction, orPattern))
            {
                string targetX = instruction.Split("OR")[0].Trim();
                string targetY = instruction.Split("OR")[1].Trim();

                bool xPresent = true;
                bool yPresent = true;

                ushort valueX;
                ushort valueY;

                if (!IsOnlyNum(targetX))
                {
                    wires.TryGetValue(targetX, out valueX);
                }
                else
                {
                    valueX = ushort.Parse(targetX);
                }

                if (!IsOnlyNum(targetY))
                {
                    wires.TryGetValue(targetY, out valueY);
                }
                else
                {
                    valueY = ushort.Parse(targetY);
                }

                if (!xPresent || !yPresent) continue;

                wires[outputWire] = (ushort)(valueX | valueY);
            }
            // LSHIFT
            else if (Regex.IsMatch(instruction, lShiftPattern))
            {
                string target = instruction.Split("LSHIFT")[0].Trim();
                int byTarget = int.Parse(instruction.Split("LSHIFT")[1].Trim());

                bool present = wires.TryGetValue(target, out ushort value);

                if (!present) continue;
                
                wires[outputWire] = (ushort)(value << byTarget);
            }
            // RSHIFT
            else if (Regex.IsMatch(instruction, rShiftPattern))
            {
                string target = instruction.Split("RSHIFT")[0].Trim();
                int byTarget = int.Parse(instruction.Split("RSHIFT")[1].Trim());

                bool present = wires.TryGetValue(target, out ushort value);

                if (!present) continue;

                wires[outputWire] = (ushort)(value >> byTarget);
            }
            // SIGNAL
            else
            {
                if (IsOnlyNum(instruction))
                {
                    wires[outputWire] = ushort.Parse(instruction);
                }
                else
                {
                    bool present = wires.TryGetValue(instruction, out ushort value);

                    if (!present) continue;

                    wires[outputWire] = value;
                }
            }
        }

        foreach (var wire in wires)
        {
            Console.WriteLine($"Key: {wire.Key}, Value: {wire.Value}");
        }

        wires.TryGetValue("a", out ushort wireA);
        
        return wireA.ToString();
    }

    protected override string PartTwo()
    {
        return "";
    }

    private bool IsOnlyNum(string input)
    {
        return Regex.IsMatch(input, @"\d");
    }
}