using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IGraphAlgorithm
    {
        int CheapestCost(Node start, Node end);
        int ShortestPath(Node start, Node end);
    }
}