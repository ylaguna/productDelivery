using System;
using Models;

namespace Services.Interfaces
{
    public interface IRouteSearchAlgorithm : IDisposable
    {
        void SetMaxStops(int value);
        void SetMaxCost(int value);
        void SetExactlyStops(int? value);
        int NumberOfRoutes(Node start, Node end);
    }
}