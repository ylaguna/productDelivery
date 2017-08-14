using Models;
using Services.Dijkstra;
using Services.Interfaces;

namespace Services
{
    public class AlgorithmFactory
    {                
        public static IShortestPathAlgorithm ShortestPathAlgorithm(Graph graph)
        {
            return new DijkstraAlgorithm(graph);
        }
    
    
    }
}