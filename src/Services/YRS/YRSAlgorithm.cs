using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Services.Interfaces;
using Services.YRS.Resources;

namespace Services.YRS
{
    public class YRSAlgorithm : IRouteSearchAlgorithm
    {
        private int _maxCost { get; set; }
        private int _maxStops { get; set; }
        private Graph _graph { get; set; }

        private List<YRSRoute> _validRoutes { get; set; }
        private List<YRSRoute> _workingRoutes { get; set; }

        public YRSAlgorithm(Graph graph)
        {
            this._maxCost = 0;
            this._maxStops = 0;
            this._graph = graph;

            _validRoutes = new List<YRSRoute>();
            _workingRoutes = new List<YRSRoute>();
        }

        public int NumberOfRoutes(Node start, Node end)
        {
            start.Routes
                .ForEach(route => _workingRoutes.Add(new YRSRoute(route)));

            while (_workingRoutes.Any())
            {
                YRSRoute route = _workingRoutes.First();

                if (isValid(route))
                {
                    var actualStop = route.Paths.Last().End;
                    if (actualStop.Name == end.Name)
                    {
                        _validRoutes.Add(route);
                    }

                    foreach(var path in actualStop.Routes)
                    {
                        var newRoute = new YRSRoute();
                        newRoute.Paths.AddRange(route.Paths);
                        newRoute.Paths.Add(path);

                        _workingRoutes.Add(newRoute);
                    }
                }

                _workingRoutes.Remove(route);
            }

            return _validRoutes.Count();
        }

        public void SetMaxCost(int value)
        {
            this._maxCost = value;
        }

        public void SetMaxStops(int value)
        {
            this._maxStops = value;
        }

        private bool isValid(YRSRoute route)
        {
            var actualStops = route.Paths.Count;
            var actualCost = route.Paths.Sum(path => path.Cost);

            return (actualStops <= this._maxStops && actualCost <= this._maxCost);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}