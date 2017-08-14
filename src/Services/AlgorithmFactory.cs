using Models;
using Services.Dijkstra;
using Services.Interfaces;
using Services.YRS;

namespace Services
{
    public class AlgorithmFactory
    {
        public static IShortestPathAlgorithm ShortestPathAlgorithm(Graph graph)
        {
            return new DijkstraAlgorithm(graph);
        }

        public static IRouteSearchAlgorithm RouteSearchAlgorithm(Graph graph)
        {
            return new YRSAlgorithm(graph);
        }

    }

}