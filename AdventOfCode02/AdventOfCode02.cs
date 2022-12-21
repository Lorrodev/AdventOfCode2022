using System.Collections.ObjectModel;

namespace AdventOfCode02;

public static class AdventOfCode02
{
    private static Dictionary<string, int> scoreMatrix = new()
    {
        { "A X", 3 + 0 },
        { "A Y", 1 + 3 },
        { "A Z", 2 + 6 },
        { "B X", 1 + 0 },
        { "B Y", 2 + 3 },
        { "B Z", 3 + 6 },
        { "C X", 2 + 0 },
        { "C Y", 3 + 3 },
        { "C Z", 1 + 6 },
        // Matrix part 1:
        // { "A X", 1 + 3 },
        // { "A Y", 2 + 6 },
        // { "A Z", 3 + 0 },
        // { "B X", 1 + 0 },
        // { "B Y", 2 + 3 },
        // { "B Z", 3 + 6 },
        // { "C X", 1 + 6 },
        // { "C Y", 2 + 0 },
        // { "C Z", 3 + 3 },
    };

    public static void Main()
    {
        var currentScore = 0;

        foreach (var game in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode02/Inputs.txt"))
        {
            currentScore += scoreMatrix[game];
        }
        
        Console.WriteLine($"Total Score: {currentScore}");
    }
}