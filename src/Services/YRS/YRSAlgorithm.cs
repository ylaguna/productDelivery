using System;
using System.Collections.Generic;
using Models;
using Services.Interfaces;

namespace Services.YRS
{
    public class YRSAlgorithm : IRouteSearchAlgorithm
    {
        private int _maxCost { get; set; }
        private int _maxStops { get; set; }
        private Graph _graph { get; set; }

        private List<Node> _validRoutes { get; set; }
        private List<Node> _workingRoutes { get; set; }

        public YRSAlgorithm(Graph graph)
        {
            this._maxCost = 0;
            this._maxStops = 0;
            this._graph = graph;

            _validRoutes = new List<Node>();
            _workingRoutes = new List<Node>();
        }

        public int NumberOfRoutes(Node start, Node end)
        {
            throw new NotImplementedException();
        }

        public void SetMaxCost(int value)
        {
            this._maxCost = value;
        }

        public void SetMaxStops(int value)
        {
            this._maxStops = value;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}