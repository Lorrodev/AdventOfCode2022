namespace AdventOfCode03;

public class AdventOfCode03
{
    private const string letterValuesByIndex = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static void Main()
    {
        GetDuplicates();
        GetGroupLetter();
    }

    private static void GetGroupLetter()
    {
        var duplicates = new List<char>();
        var count = 0;
        var commonLetterCount = 0;
        
        using var rucksacks = File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode03/Inputs.txt")
            .GetEnumerator();
        rucksacks.MoveNext();
        
        do
        {
            var r1 = rucksacks.Current;
            rucksacks.MoveNext();
            var r2 = rucksacks.Current;
            rucksacks.MoveNext();
            var r3 = rucksacks.Current;

            Console.WriteLine($"Rucksacks: {r1} | {r2} | {r3}");
            var commonLetter = ' ';
            
            foreach (var c in r1)
            {
                if (r1.Contains(c) && r2.Contains(c) && r3.Contains(c))
                {
                    commonLetter = c;
                    commonLetterCount++;
                    duplicates.Add(c);
                    break;
                }
            }
            
            Console.WriteLine($"Common Letter: {commonLetter}");

        } while (rucksacks.MoveNext());
        
        count = duplicates.Sum(duplicate => letterValuesByIndex.IndexOf(duplicate));

        Console.WriteLine($"GroupLetter Total: {count} in {commonLetterCount} common letters");
    }

    private static void GetDuplicates()
    {
        var duplicates = new List<char>();
        var count = 0;

        foreach (var rucksack in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode03/Inputs.txt"))
        {
            var result = ' ';

            // Upper bound in range is not inclusive
            var compartments = (
                c1: rucksack[..(rucksack.Length / 2)],
                c2: rucksack[(rucksack.Length / 2)..]);

            foreach (var c in compartments.c1.Where(c => compartments.c2.Contains(c)))
            {
                result = c;
            }

            if (result != ' ')
            {
                duplicates.Add(result);
            }
        }

        count = duplicates.Sum(duplicate => letterValuesByIndex.IndexOf(duplicate));

        Console.WriteLine($"Duplicates Total: {count}");
    }
}