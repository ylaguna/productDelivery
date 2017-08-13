using System;
using Models;

namespace Services.Interfaces
{
    public interface IGraphAlgorithm : IDisposable
    {
        int CheapestCost(Node start, Node end);
        int ShortestPathCost(Node start, Node end);
    }
}