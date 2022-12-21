namespace AdventOfCode06;

public class AdventOfCode06
{
    public static void Main()
    {
        var buffer = File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode06/Inputs.txt").First();

        var current = "";
        var cursor = 0;

        do
        {
            var c = buffer[cursor];

            if (!current.Contains(c))
            {
                current += c;
            }
            else
            {
                cursor -= current.Length - current.IndexOf(c);
                current = "";
            }
            
            cursor++;
        } while (current.Length < 14);
        
        Console.WriteLine("'" + current + "' at character " + cursor);
    }
}