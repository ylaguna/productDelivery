using Models;
using Services.Interfaces;
using Services.Dijkstra.Resources;
using System.Linq;

namespace Services.Dijkstra
{
    public class Dijkstra : IGraphAlgorithm
    {
        private DijkstraGraph _graph;

        public Dijkstra(Graph graph)
        {
            _graph = DijkstraGraphFactory.Make(graph);
        }

        public int CheapestCost(Node start, Node end)
        {
            var startNode = _graph.GetNodeByName(start.Name);
            var endNode   = _graph.GetNodeByName(end.Name);
            startNode.PathLegth = 0;
            
            while( endNode.IsTemporary() && (_graph.Nodes.Any(node => node.IsTemporary() && !node.IsInfinity())))
            {

                var smallestNode = _graph.GetSmallestTemporaryNode();
                // System.Console.WriteLine("loop");
                smallestNode.MakePermanent();
                UpdateNodeAdjacents(smallestNode);
            }


            return endNode.PathLegth;
        }

        public int ShortestPath(Node start, Node end)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateNodeAdjacents(DijkstraNode currentNode)
        {
            var adjacentRoutes = _graph.GetAdjacentRoutes(currentNode);
        
            foreach(var route in adjacentRoutes)
            {
                var adjacentNode = _graph.GetNodeByName(route.EndName);
                var routeCost = currentNode.PathLegth + route.Cost;
                if ( routeCost < adjacentNode.PathLegth )
                {
                    adjacentNode.PathLegth = routeCost; 
                }
            }
        }
    }
}