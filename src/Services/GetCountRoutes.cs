using System;
using Models;
using Services.Resources;
using Services.YRS;

namespace Services
{
    public static class GetCountRoutes
    {

        public static int Execute(CountRoutesFilter filter)
        {
            if (filter.maxCost == int.MaxValue && filter.maxStops == int.MaxValue)
            {
                throw new Exception("Please, select a max value or max cost or i'll be in a overflow :(");
            }

            using(var alg = new YRSAlgorithm(filter.graph))
            {
                alg.SetMaxStops(filter.maxStops);
                alg.SetMaxCost(filter.maxCost);
                return alg.NumberOfRoutes(filter.start, filter.end);
            }
        }

    }

}