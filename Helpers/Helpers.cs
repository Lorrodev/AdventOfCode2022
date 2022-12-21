namespace Helpers;

public class IoHelpers
{
    public static void ParseInput()
    {
        var currentInventory = new Inventory();
        inventories.Add(currentInventory);

        foreach (var line in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode01/Inputs.txt"))
        {
            if (line == string.Empty)
            {
                currentInventory.CalculateTotalCalories();
                currentInventory = new Inventory();
                inventories.Add(currentInventory);
            }
            else
            {
                currentInventory.Add(Int32.Parse(line));
            }
        }
    }
}