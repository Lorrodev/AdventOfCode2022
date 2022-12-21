namespace AdventOfCode01;

public static class AdventOfCode01
{
    private static List<Inventory> inventories = new();

    public static void Main()
    {
        ParseInput();

        inventories.Sort((t, o) => t.totalCalories < o.totalCalories ? 1 : -1);

        Console.WriteLine("\n==================================" +
                          "\nMax calories:" +
                          $"\n1) {inventories[0].totalCalories}" +
                          $"\n2) {inventories[1].totalCalories}" +
                          $"\n3) {inventories[2].totalCalories}" +
                          $"\nTotal top 3: {inventories[0].totalCalories + inventories[1].totalCalories + inventories[2].totalCalories}" +
                          "\n==================================");
    }

    private static void ParseInput()
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

class Inventory
{
    public List<int> items = new List<int>();
    public int totalCalories;

    public int CalculateTotalCalories()
    {
        totalCalories = items.Aggregate(0, (count, next) => count + next);
        return totalCalories;
    }

    public void Add(int item)
    {
        items.Add(item);
    }
}