namespace AdventOfCode08;

public class AdventOfCode08
{
    private static int[][] trees;
    private static Dictionary<(int x, int y), int> scorePerTree = new();

    public static void Main()
    {
        trees = ParseRowsAndCols();
        var count = 0;

        var y = 0;
        foreach (var row in trees)
        {
            var x = 0;
            foreach (var tree in row)
            {
                if (IsVisible(x, y))
                {
                    count++;
                }

                x++;
            }

            y++;
        }

        Console.WriteLine("Part 1: " + count);

        var bestView = scorePerTree.ToList();
        bestView.Sort((t, o) => t.Value > o.Value ? -1 : 1);
        
        Console.WriteLine("Part 2: " + bestView.First());
    }

    private static bool IsVisible(int x, int y)
    {
        var east = TreesEast(x, y);
        var west = TreesWest(x, y);
        var north = TreesNorth(x, y);
        var south = TreesSouth(x, y);

        var distMult = north.dist * south.dist * west.dist * east.dist;
        scorePerTree.Add((x, y), distMult);

        return east.visible || west.visible || north.visible || south.visible;
    }

    private static (bool visible, int dist) TreesNorth(int x, int y)
    {
        var dist = 0;

        for (var y2 = y - 1; y2 >= 0; y2--)
        {
            if (trees[y2][x] < trees[y][x])
            {
                dist++;
            }
            else
            {
                dist++;
                return (false, dist);
            }
        }

        return (true, dist);
    }

    private static (bool visible, int dist) TreesSouth(int x, int y)
    {
        var dist = 0;

        for (var y2 = y + 1; y2 < 99; y2++)
        {
            if (trees[y2][x] < trees[y][x])
            {
                dist++;
            }
            else
            {
                dist++;
                return (false, dist);
            }
        }

        return (true, dist);
    }

    private static (bool visible, int dist) TreesWest(int x, int y)
    {
        var dist = 0;

        for (var x2 = x - 1; x2 >= 0; x2--)
        {
            if (trees[y][x2] < trees[y][x])
            {
                dist++;
            }
            else
            {
                dist++;
                return (false, dist);
            }
        }

        return (true, dist);
    }

    private static (bool visible, int dist) TreesEast(int x, int y)
    {
        var dist = 0;

        for (var x2 = x + 1; x2 < 99; x2++)
        {
            if (trees[y][x2] < trees[y][x])
            {
                dist++;
            }
            else
            {
                dist++;
                return (false, dist);
            }
        }

        return (true, dist);
    }

    private static int[][] ParseRowsAndCols()
    {
        var result = Enumerable.Range(0, 99).Select(_ => Enumerable.Range(0, 99).Select(_ => 0).ToArray()).ToArray();

        var y = 0;

        foreach (var row in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode08/Inputs.txt"))
        {
            var x = 0;

            foreach (var tree in row)
            {
                result[y][x] = int.Parse($"{tree}");

                x++;
            }

            y++;
        }

        foreach (var row in result)
        {
            var s = row.Aggregate("", (current, tree) => current + tree);
            Console.WriteLine(s);
        }

        return result;
    }
}