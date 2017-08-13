using System;
using System.Linq;
using Models;
using Services.Dijkstra.Resources;
using Services.Interfaces;

namespace Services.Dijkstra
{
    public class DijkstraAlgorithm : IGraphAlgorithm
    {
        private DijkstraGraph _graph;

        private bool _useCost;

        public DijkstraAlgorithm(Graph graph)
        {
            _graph = DijkstraGraphFactory.Make(graph);
        }

        public int CheapestCost(Node start, Node end)
        {
            this._useCost = true;
            return this.FindPath(start, end).PathCost;
        }

        public int ShortestPathCost(Node start, Node end)
        {
            this._useCost = false;
            return this.FindPath(start, end).PathCost;
        }

        private DijkstraNode FindPath(Node start, Node end)
        {
            var startNode = _graph.GetNodeByName(start.Name);
            var endNode = _graph.GetNodeByName(end.Name);
            startNode.PathLegth = 0;
            startNode.PathCost = 0;

            while (endNode.IsTemporary() && (_graph.Nodes.Any(node => node.IsTemporary() && !node.IsInfinity())))
            {

                var smallestNode = this._useCost ?
                    _graph.GetSmallestCostTemporaryNode() :
                    _graph.GetSmallestLengthTemporaryNode();

                smallestNode.MakePermanent();
                UpdateNodeAdjacents(smallestNode);
            }

            return endNode;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void UpdateNodeAdjacents(DijkstraNode currentNode)
        {
            var adjacentRoutes = _graph.GetAdjacentRoutes(currentNode);

            foreach(var route in adjacentRoutes)
            {
                var adjacentNode = _graph.GetNodeByName(route.EndName);

                var adjacentRouteLenght = currentNode.PathLegth + 1;
                var adjacentRouteCost = currentNode.PathCost + route.Cost;

                bool relabel = this._useCost ?
                    adjacentNode.PathCost > adjacentRouteCost :
                    adjacentNode.PathLegth > adjacentRouteLenght;

                if (relabel)
                {
                    adjacentNode.Predecessor = currentNode;
                    adjacentNode.PathLegth = adjacentRouteLenght;
                    adjacentNode.PathCost = adjacentRouteCost;
                }
            }
        }
    }
}