namespace AdventOfCode04;

public class AdventOfCode04
{
    public static void Main()
    {
        var count = 0;
        
        foreach (var line in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode04/Inputs.txt"))
        {
            var ranges= line.Split(",");
            var range1 = (int.Parse(ranges[0].Split("-")[0]), int.Parse(ranges[0].Split("-")[1]));
            var range2 = (int.Parse(ranges[1].Split("-")[0]), int.Parse(ranges[1].Split("-")[1]));

            if (CheckRangeOverlap(range1, range2))
            {
                count++;
                Console.WriteLine($"{range1} <> {range2}");
            }
        }
        
        Console.WriteLine(count);
    }

    private static bool CheckRangeOverlap((int start, int end) range1, (int start, int end) range2)
    {
        var r1IncludesR2 = range2.start >= range1.start && range2.end <= range1.end;
        var r2IncludesR1 = range1.start >= range2.start && range1.end <= range2.end;

        var inclusiveRangeCheck = r1IncludesR2 || r2IncludesR1;

        var r1LeftOverlapsR2 = range1.start < range2.start && range1.end >= range2.start;
        var r1RightOverlapsR2 = range1.start < range2.end && range1.end >= range2.end;

        var r2LeftOverlapsR1 = range2.start < range1.start && range2.end >= range1.start;
        var r2RightOverlapsR1 = range2.start < range1.end && range2.end >= range1.end;

        var overlappingRangeCheck = r1LeftOverlapsR2 || r1RightOverlapsR2 || r2LeftOverlapsR1 || r2RightOverlapsR1;
        
        return overlappingRangeCheck || inclusiveRangeCheck;
    }
}