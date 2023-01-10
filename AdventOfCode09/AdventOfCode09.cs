namespace AdventOfCode09;

public class AdventOfCode09
{
    private static Knot head = new(0, 0);
    private static Knot knot1 = new(0, 0);
    private static Knot knot2 = new(0, 0);
    private static Knot knot3 = new(0, 0);
    private static Knot knot4 = new(0, 0);
    private static Knot knot5 = new(0, 0);
    private static Knot knot6 = new(0, 0);
    private static Knot knot7 = new(0, 0);
    private static Knot knot8 = new(0, 0);
    private static Knot tail = new(0, 0);

    private static Knot[] knots = { head, knot1, knot2, knot3, knot4, knot5, knot6, knot7, knot8, tail };

    private static HashSet<(int x, int y)> visited = new();

    public static void Main()
    {
        foreach (var line in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode09/Inputs.txt"))
        {
            var direction = line.Split(" ")[0];
            var numSteps = int.Parse(line.Split(" ")[1]);
            
            for (var i = 0; i < numSteps; i++)
            {
                switch (direction)
                {
                    case "L":
                        head.x--;
                        break;
                    case "R":
                        head.x++;
                        break;
                    case "U":
                        head.y--;
                        break;
                    case "D":
                        head.y++;
                        break;
                }

                for (var j = 1; j < knots.Length; j++)
                {
                    var otherKnot = knots[j - 1];
                    var thisKnot = knots[j];
                    
                    MoveKnot(thisKnot, otherKnot);
                }
                
                if (!visited.Contains((tail.x, tail.y)))
                {
                    visited.Add((tail.x, tail.y));
                }
            }
        }

        Console.WriteLine(visited.Count + " Places visited");
    }

    private static void MoveKnot(Knot thisKnot, Knot otherKnot)
    {
        var deltaX = otherKnot.x - thisKnot.x;
        var deltaY = otherKnot.y - thisKnot.y;

        if (Math.Abs(deltaX) > 1 || (Math.Abs(deltaX) == 1 && Math.Abs(deltaY) > 1))
        {
            thisKnot.x += Math.Sign(deltaX);
        }

        if (Math.Abs(deltaY) > 1|| (Math.Abs(deltaY) == 1 && Math.Abs(deltaX) > 1))
        {
            thisKnot.y += Math.Sign(deltaY);
        }
    }
}

public class Knot
{
    public int x;
    public int y;
    
    public Knot(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}