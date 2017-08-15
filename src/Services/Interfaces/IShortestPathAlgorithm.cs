using System;
using Models;

namespace Services.Interfaces
{
    public interface IShortestPathAlgorithm : IDisposable
    {
        int CheapestCost(Node start, Node end);
        int ShortestPathCost(Node start, Node end);
    }
}