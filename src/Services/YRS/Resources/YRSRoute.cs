using System;
using System.Collections.Generic;
using Models;

namespace Services.YRS.Resources
{
    internal class YRSRoute
    {
        public List<Edge> Paths { get; set; }

        public YRSRoute(Edge firstPath)
        {
            this.Paths = new List<Edge>() { firstPath };
        }

        public YRSRoute()
        {
            this.Paths = new List<Edge>();
        }
    }
}