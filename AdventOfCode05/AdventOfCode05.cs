namespace AdventOfCode05;

public class AdventOfCode05
{
    public static void Main()
    {
        string[] stacks =
            { "", "WDGBHRV", "JNGCRF", "LSFHDNJ", "JDSV", "SHDRQWNV", "PGHCM", "FJBGLZHC", "SJR", "LGSRBNVM" };

        foreach (var line in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode05/Procedure.txt"))
        {
            var amount = int.Parse(line.Split("move ")[1].Split(" from")[0]);
            var from = int.Parse(line.Split("from ")[1].Split(" to")[0]);
            var to = int.Parse(line.Split("to ")[1]);

            stacks[to] = stacks[to].Insert(stacks[to].Length, stacks[from][(stacks[from].Length-amount)..]);
            stacks[from] = stacks[from].Remove(stacks[from].Length - amount);

            // for (var i = 0; i < amount; i++)
            // {
            //     stacks[to] = stacks[to].Insert(stacks[to].Length, stacks[from].Last().ToString());
            //     stacks[from] = stacks[from].Remove(stacks[from].Length - 1);
            // }
        }

        foreach (var stack in stacks)
        {
            Console.WriteLine(stack);
        }
    }
}