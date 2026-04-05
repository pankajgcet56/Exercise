namespace PracticeGround.WinterBreak_25;

public class SomeTest : ILeetCodeSolotion
{
    public void RunSolution()
    {
        Console.WriteLine("Pankaj .... Pankaj Runk");
        Graph g = new Graph(6);
        g.AddEdge(0, 1);
        g.AddEdge(1, 2);
        g.AddEdge(2, 4);
        g.AddEdge(3, 4);
        g.AddEdge(4, 5);
        g.AddEdge(5, 6);
        g.AddEdge(6, 0);
        g.Display();
        Console.WriteLine(".......---->....");
        Console.WriteLine("Finding path from 0 to 4");
        g.FindPath(0, 4);
    }
}

/// <summary>
/// Graph with Adjuncy List
/// </summary>
public class Graph
{
    private int vertices;
    private Dictionary<int, List<int>> adjucenyList;
    public Graph(int vertices)
    {
        this.vertices = vertices;
        adjucenyList = new Dictionary<int, List<int>>();
    }
    public void AddEdge(int source, int destination)
    {
        if (!adjucenyList.ContainsKey(source))
            adjucenyList.Add(source, new List<int>());

        adjucenyList[source].Add(destination);
    }

    public void FindPath(int source, int destination)
    {
        foreach (var item in adjucenyList)
        {
            if (item.Key == source)
            {
                foreach (var dest in item.Value)
                {
                    if (dest == destination)
                    {
                        Console.WriteLine($"Path found from {source} to {destination}");
                        return;
                    }
                    else
                    {
                        FindPath(dest, destination);
                    }
                }
            }
        }
    }
    public void Display()
    {
        foreach (var item in adjucenyList)
        {
            Console.Write($"{item.Key} -> ");
            foreach (var dest in item.Value)
            {
                Console.Write($"{dest} ");
            }
            Console.WriteLine();
        }
    }
}