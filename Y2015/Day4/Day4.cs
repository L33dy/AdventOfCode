using System.Text;
using AdventOfCode.Shared;
using AdventOfCode.Shared.Years;

namespace AdventOfCode.Y2015.Day4;

public class Day4(): Year2015(nameof(Day4))
{
    protected override string PartOne()
    {
        string input = ReadPlainInput();
        string key = input.SplitInput()[0];

        int output = 0;

        for (int i = 0; i < 2000000; i++)
        {
            string attempt = $"{key}{i}";

            string hash = MD5(attempt);

            if (hash.StartsWith("00000"))
            {
                output = i;

                break;
            }
        }
        
        return output.ToString();
    }

    protected override string PartTwo()
    {
        string input = ReadPlainInput();
        string key = input.SplitInput()[0];

        int output = 0;

        for (int i = 0; i < 2000000; i++)
        {
            string attempt = $"{key}{i}";

            string hash = MD5(attempt);

            if (hash.StartsWith("000000"))
            {
                output = i;

                break;
            }
        }
        
        return output.ToString();
    }

    private string MD5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes).ToLower();
        }
    }
}