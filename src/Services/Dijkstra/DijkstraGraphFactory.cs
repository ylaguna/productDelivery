using System.Collections.Generic;
using System.Linq;
using Models;
using Services.Dijkstra.Resources;

namespace Services.Dijkstra
{
    internal static class DijkstraGraphFactory
    {
        public static DijkstraGraph Make(Graph graph)
        {
            var dijkstraGraph = new DijkstraGraph();

            foreach(var node in graph.Nodes)
            {
                dijkstraGraph.Nodes.Add(new DijkstraNode(node.Name));

                dijkstraGraph.Edges.AddRange(node.Routes
                    .Select(route => new DijkstraEdge(route.Start.Name, route.End.Name, route.Cost)).ToList());
            }

            return dijkstraGraph;
        }
    }
}