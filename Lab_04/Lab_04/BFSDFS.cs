using System;
using System.Collections.Generic;
using System.Linq;

class Graph
{
    private int V;
    private List<int>[] smezhn;

    public Graph(int v)
    {
        V = v;
        smezhn = new List<int>[v];
        for (int i = 0; i < v; ++i)
            smezhn[i] = new List<int>();
    }

    public void AddEdge(int v, int w)
    {
        smezhn[v].Add(w);
    }

    void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        List<int> vList = smezhn[v];
        foreach (var n in vList)
        {
            if (!visited[n])
            {
                DFSUtil(n, visited);
                Console.WriteLine();
            }
        }
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        DFSUtil(v, visited);
    }

    public void BFS(int s)
    {
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++)
            visited[i] = false;

        LinkedList<int> queue = new LinkedList<int>();

        visited[s] = true;
        queue.AddLast(s);

        while (queue.Any())
        {
            s = queue.First();
            Console.Write(s + " ");
            queue.RemoveFirst();

            List<int> list = smezhn[s];

            foreach (var val in list)
            {
                if (!visited[val])
                {
                    visited[val] = true;
                    queue.AddLast(val);
                    Console.WriteLine();
                }
            }
        }
    }
}

