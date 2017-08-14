using System.Linq;
using Models;
using Services.Resources;

namespace Services
{
    internal static class GetCountRoutesArriving
    {
        public static int Execute(RoutesArrivingFilter filter)
        {
            var total = filter.graph.Nodes
                .Sum(node =>
                    node.Routes.Any(path => path.End.Name.Equals(filter.client.Name)) ?
                    1 : 0
                );

            return total;
        }

    }
}