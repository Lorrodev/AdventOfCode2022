namespace AdventOfCode10;

public class AdventOfCode10
{
    public static void Main()
    {
        var cycle = 0;
        var value = 1;
        var sum = 0;

        var reader = File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode10/Inputs.txt").GetEnumerator();
        var finished = false;
        var commandExecuted = true;
        var command = "";
        var commandRunningForCycles = 0;
        var outputLine = "";

        do
        {
            cycle++;

            if (commandExecuted)
            {
                if (reader.MoveNext())
                {
                    command = reader.Current;
                    commandRunningForCycles = 0;
                    commandExecuted = false;
                }
                else
                {
                    finished = true;
                }
            }
            
            if (value >= ((cycle - 1) % 40) - 1 && value <= ((cycle - 1) % 40) + 1)
            {
                outputLine += "#";
            }
            else
            {
                outputLine += ".";
            }

            if ((cycle == 20 || ((cycle - 20) % 40 == 0 && cycle > 20)))
            {
                sum += value * cycle;
                //Console.WriteLine("Cycle: " + cycle + ", command: " + command + ", running for: " +
                //                  commandRunningForCycles + ", Value: " + value);
            }

            if (cycle % 40 == 0)
            {
                Console.WriteLine(outputLine);
                outputLine = "";
            }

            if (command.Split(" ")[0] == "addx")
            {
                if (commandRunningForCycles == 1)
                {
                    commandExecuted = true;
                    value += int.Parse(command.Split(" ")[1]);
                }
                else
                {
                    commandRunningForCycles++;
                }
            }
            else if (command.Split(" ")[0] == "noop")
            {
                commandExecuted = true;
            }
        } while (!finished);

        Console.WriteLine(sum);
    }
}