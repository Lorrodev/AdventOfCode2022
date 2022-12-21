using System.Drawing;

namespace AdventOfCode07;

public class AdventOfCode07
{
    private const int totalSpace = 70000000;
    private const int neededForUpdate = 30000000;
    private static int usedSpace = 0;

    private static readonly Node Root = new("/", null);
    private static Dictionary<string, Node> nodeByAbsolutePath = new() { { "/", Root } };

    public static void Main()
    {
        ParseConsoleOutput();

        var sizedDirectories = nodeByAbsolutePath
            .Where(nbap => nbap.Value.Type == NodeType.DIRECTORY)
            .Where(nbap => nbap.Value.GetSize() <= 100000)
            .Select(dir => (Name: dir.Value.Name, Size: dir.Value.GetSize()))
            .ToList();

        sizedDirectories.Sort((t, o) => t.Size > o.Size ? -1 : 1);
        Console.WriteLine("Part  1: " + sizedDirectories.Sum(sd => sd.Size));

        usedSpace = Root.GetSize();

        var freeSpace = totalSpace - usedSpace;
        var toFree = neededForUpdate - freeSpace;

        sizedDirectories = nodeByAbsolutePath
            .Where(nbap => nbap.Value.Type == NodeType.DIRECTORY)
            .Select(dir => (Name: dir.Value.Name, Size: dir.Value.GetSize()))
            .ToList();

        sizedDirectories.Sort((t, o) => t.Size > o.Size ? -1 : 1);

        var possibleDirs = sizedDirectories.Where(sd => sd.Size >= toFree).ToList();
        Console.WriteLine("Part  2: " + possibleDirs.Last().Size);
    }

    private static void ParseConsoleOutput()
    {
        var currentNode = Root;

        foreach (var line in File.ReadLines(@"/Users/marc/Playground/AdventOfCode/AdventOfCode07/Inputs.txt"))
        {
            var command = line[0] == '$' ? line.Split(" ")[1][..2] : null; // cd or ls
            var cdDir = command == "cd" ? line.Split("cd ")[1] : null;

            if (command == "ls")
            {
                continue;
            }

            if (command == "cd")
            {
                if (cdDir == "..")
                {
                    currentNode = currentNode.ParentNode;
                }
                else if (currentNode.ChildNodes.Any(node => node.Name == cdDir))
                {
                    currentNode = currentNode.ChildNodes.Single(node => node.Name == cdDir);
                }
                else
                {
                    Console.WriteLine("Should not run into this case");

                    var newNode = new Node(cdDir, currentNode);
                    newNode.Type = NodeType.DIRECTORY;
                    currentNode.ChildNodes.Add(newNode);
                    nodeByAbsolutePath.Add(newNode.GetFullPath(), newNode);
                    currentNode = newNode;
                }
            }
            else if (line[..3] == "dir")
            {
                var dir = line[4..];
                var newNode = new Node(dir, currentNode);
                newNode.Type = NodeType.DIRECTORY;
                currentNode.ChildNodes.Add(newNode);
                nodeByAbsolutePath.Add(newNode.GetFullPath(), newNode);
            }
            else // node is a file
            {
                var fileSize = int.Parse(line.Split(" ")[0]);
                var fileName = line.Split(" ")[1];
                var newNode = new Node(fileName, currentNode);
                newNode.Size = fileSize;
                newNode.Type = NodeType.FILE;
                currentNode.ChildNodes.Add(newNode);
                nodeByAbsolutePath.Add(newNode.GetFullPath(), newNode);
            }
        }
    }
}

public class Node
{
    public readonly string Name;
    public int Size;
    public NodeType Type;
    public readonly Node? ParentNode;
    public HashSet<Node> ChildNodes = new();

    public Node(string name, Node? parentNode)
    {
        this.Name = name;
        this.ParentNode = parentNode;
    }

    public int GetSize()
    {
        var total = Type == NodeType.FILE ? Size : 0;

        foreach (var node in ChildNodes)
        {
            if (node.Type == NodeType.FILE)
            {
                total += node.Size;
            }
            else
            {
                total += node.GetSize();
            }
        }

        return total;
    }

    public string GetFullPath()
    {
        var current = this;
        var path = Name;

        while (current.ParentNode != null)
        {
            path = current.ParentNode.Name == "/" ? "/" + path : current.ParentNode.Name + "/" + path;
            current = current.ParentNode;
        }

        return path;
    }
}

public enum NodeType
{
    FILE,
    DIRECTORY
}