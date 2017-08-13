using Models;

namespace Services.Interfaces
{
    public interface IGraphAlgorithm
    {
        int CheapestCost(Node start, Node end);
        int ShortestPath(Node start, Node end);
    }
}