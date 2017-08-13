using System;
using System.Linq;
using Models;
using Services.Dijkstra;

namespace Services
{
    public class ProductDeliveryService : IDisposable
    {
        private Graph _graph;

        public ProductDeliveryService(Graph graph)
        {
            this._graph = graph;
        }

        public int CostOfTheRoute(params Node[] nodes)
        {
            int total = 0;
            var before = nodes.First();
            foreach(var node in nodes)
            {
                using(var alg = new DijkstraAlgorithm(this._graph))
                {
                    total += alg.CheapestCost(before, node);
                }

                before = node;
            }

            return total;
        }
        public int ShortestRoute(params Node[] nodes)
        {
            int total = 0;
            var before = nodes.First();
            foreach(var node in nodes)
            {
                using(var alg = new DijkstraAlgorithm(this._graph))
                {
                    total += alg.ShortestPathCost(before, node);
                }

                before = node;
            }

            return total;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}