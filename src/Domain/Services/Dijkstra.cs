using Domain.Models;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class Dijkstra : IGraphAlgorithm
    {
        private Graph _graph;
        private readonly int Temporary = 1;
        private readonly int Permanent = 2;
        private readonly int Infinity = 99999;

        public Dijkstra(Graph graph)
        {
            this._graph = graph;
        }

        public int CheapestCost(Node start, Node end)
        {
            throw new System.NotImplementedException();
        }

        public int ShortestPath(Node start, Node end)
        {
            throw new System.NotImplementedException();
        }
    }
}