using System;
using System.Collections;
namespace DataStructureUdemy.Graphs;

public class Gp_Adj_List : Problem
{
    public Gp_Adj_List()
    {
        this.RunIndex = 4.3f;
    }
    public override void Run()
    {
        Console.WriteLine(".........Graph");
        Graph g = new Graph(7);
        g.AddEdge(0,1);
        g.AddEdge(1,2);
        g.AddEdge(2,3);
        g.AddEdge(3,5);
        g.AddEdge(5,6);
        g.AddEdge(4,5);
        g.AddEdge(0,4);
        g.AddEdge(3,4);
        // g.PrintAdjList();
        g.Bfs(1);
    }
}

public class Graph
{
    private int Vertices;
    public List<List<int>> GraphAdjList;

    public Graph(int v)
    {
        this.Vertices = v;
        GraphAdjList = new List<List<int>>();
        for (int i = 0; i < v; i++)
        {
            GraphAdjList.Add(new List<int>());
        }
    }

    public void AddEdge(int i, int j, bool undir = true)
    {
        // if (GraphAdjList[i] == null)
        //     GraphAdjList[i] = new List<int>();
        GraphAdjList[i].Add(j);
        if (undir)
        {
            GraphAdjList[j].Add(i);
        }
    }

    public void PrintAdjList()
    {
        // Iterate Over All Rows
        for (int i = 0; i < Vertices; i++)
        {
            Console.Write("[{0}]-->",i);
            // Print Current List
            foreach (var val in GraphAdjList[i])
            {
                Console.Write("{0}, ",val);
            }
            Console.WriteLine();
        }
    }

    public void Bfs(int source)
    {
        bool[] traversedNodesArray = new bool[Vertices];
        
        Queue<int> queue = new Queue<int>();
        
        int[] dist = new int[Vertices];
        int[] parent = new int[Vertices];
        for (int i = 0; i < Vertices; i++)
        {
            parent[i] = -1;
        }
        dist[source] = 0;

        parent[source] = source;
        queue.Enqueue(source);
        traversedNodesArray[source] = true;
        Console.Write(source+", ");
        while (queue.Count>0)
        {
            int currentval = queue.Dequeue();
            
            foreach (var nd in GraphAdjList[currentval])
            {   
                if (!traversedNodesArray[nd])
                {
                    Console.Write(nd+", ");
                    queue.Enqueue(nd);
                    parent[nd] = currentval;
                    dist[nd] = dist[currentval] + 1;
                }
                traversedNodesArray[nd] = true;
            }
        }
        Console.WriteLine();
        Console.WriteLine("-------Disntanc-------");
        for (int i = 0; i < Vertices; i++)
        {
            Console.WriteLine("{0}-->{1} Distance = {2}",source,i,dist[i]);
        }
    }
}