using System;
using System.Collections.Generic;
using System.Linq;
using static Graph;
using static Dijkstra;
using static Kruskal;

class Lab_04
{
    public static void Main(String[] args)
    {
        Graph graph = new Graph(5);

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 1);
        graph.AddEdge(2, 3);
        graph.AddEdge(1, 4);
        //graph.AddEdge(3, 3);

        Console.WriteLine("Поиск в глубину:");
        graph.DFS(0);
        Console.WriteLine("Поиск в ширину:");
        graph.BFS(0);

        Console.WriteLine("\n\nДейкстра:");
        int[,] g = new int[,] { { 0, 2, 0, 0, 0, 0, 0, 4, 0 },
                                { 1, 0, 5, 0, 0, 0, 0, 3, 0 },
                                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                { 0, 0, 2, 0, 0, 0, 6, 7, 0 },
                                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                { 0, 6, 0, 4, 0, 4, 0, 0, 11 },
                                { 0, 0, 7, 0, 9, 14, 0, 0, 0 }};
        Dijkstra t = new Dijkstra();
        t.dijkstra(g, 0);

        Console.WriteLine("\n\nКрускал:");
        int V = 8;
        int E = 10;
        Kruskal gr = new Kruskal(V, E);

        // add edge 0-1
        gr.edge[0].src = 0;
        gr.edge[0].dest = 1;
        gr.edge[0].weight = 6;

        // add edge 0-2
        gr.edge[1].src = 0;
        gr.edge[1].dest = 2;
        gr.edge[1].weight = 17;

        // add edge 0-3
        gr.edge[2].src = 0;
        gr.edge[2].dest = 3;
        gr.edge[2].weight = 11;

        // add edge 1-3
        gr.edge[3].src = 1;
        gr.edge[3].dest = 3;
        gr.edge[3].weight = 25;

        // add edge 2-3
        gr.edge[4].src = 2;
        gr.edge[4].dest = 3;
        gr.edge[4].weight = 8;

        // add edge 1-4
        gr.edge[5].src = 1;
        gr.edge[5].dest = 4;
        gr.edge[5].weight = 19;

        // add edge 3-6
        gr.edge[6].src = 3;
        gr.edge[6].dest = 6;
        gr.edge[6].weight = 2;

        // add edge 4-5
        gr.edge[7].src = 4;
        gr.edge[7].dest = 5;
        gr.edge[7].weight = 9;

        // add edge 5-6
        gr.edge[8].src = 5;
        gr.edge[8].dest = 6;
        gr.edge[8].weight = 14;

        // add edge 6-7
        gr.edge[9].src = 6;
        gr.edge[9].dest = 7;
        gr.edge[9].weight = 21;

        gr.KruskalMST();
    }
}