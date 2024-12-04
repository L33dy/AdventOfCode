using System.Net;
using System.Text.RegularExpressions;

namespace AdventOfCode.Shared;

public class Solver(string year, string day)
{
    private readonly string _folderPath = $"{year}/{day}";

    public string ReadPlainInput(bool test = false)
    {
        var file = "//input.txt";
        if (test)
        {
            file = "//test.txt";
        }
        var fullPath = _folderPath + $"{file}";

        try
        {
            var sr = new StreamReader(fullPath);

            var result = sr.ReadToEnd();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private string GetSession()
    {
        return Environment.GetEnvironmentVariable("AOC_SESSION") ?? throw new ArgumentException("Set AOC_SESSION environment variable!");
    }
    
    public async Task DownloadInput()
    {
        string outputFile = year + "/" + day + "/input.txt";
        string projectOutputFile =
            $"C:\\Users\\zidli\\Desktop\\Livin W\\I - Projects\\C#\\AdventOfCode\\{year}\\{day}\\input.txt";

        if (File.Exists(outputFile) && File.Exists(projectOutputFile))
        {
            return;
        }

        string dayNum = Regex.Match(day, @"\d+", RegexOptions.RightToLeft).Value;
        string yearNum = Regex.Match(year, @"\d+", RegexOptions.RightToLeft).Value;
        string url = $"https://adventofcode.com/{yearNum}/day/{dayNum}/input";

        string session = GetSession();

        using (var handler = new HttpClientHandler())
        {
            handler.CookieContainer = new CookieContainer();

            handler.CookieContainer.Add(new Uri(url), new Cookie("session", session));

            using (var client = new HttpClient(handler))
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    
                    EnsureDirectoryExists(outputFile);

                    using (var writer = new StreamWriter(outputFile, true))
                    {
                        writer.WriteLine(content);
                    }

                    using (var writer = new StreamWriter(projectOutputFile, true))
                    {
                        writer.WriteLine(content);
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }
    }

    private void EnsureDirectoryExists(string filePath)
    {
        FileInfo fi = new FileInfo(filePath);

        if (!fi.Directory.Exists)
        {
            Directory.CreateDirectory(fi.DirectoryName);
        }
    }
}