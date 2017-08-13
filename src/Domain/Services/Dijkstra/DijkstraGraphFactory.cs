using System.Collections.Generic;
using Domain.Models;
using Domain.Services.Dijkstra.Resources;
using System.Linq;

namespace Domain.Services.Dijkstra
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