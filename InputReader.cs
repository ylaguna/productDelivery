using System;
using Models;

namespace ProductDelivery
{
    public static class InputReader
    {
        public static void PopulateGraph(Graph graph, string[] args)
        {
            var input = args[0];
            var inputedRoutes = input.Split(",");

            foreach(var route in inputedRoutes)
            {
                var sanitedRoute = route.Trim();
                string regex = @"^([A-F])([A-F])(\d+)$";

                var matchGroups = System.Text.RegularExpressions.Regex.Match(sanitedRoute, regex).Groups;

                //A comparação deve ser feita com o numero de grupos + 1, onde o grupo[0] é o match inteiro
                if (matchGroups.Count != 4)
                {
                    throw new Exception("Parâmetros inválidos");
                }

                Node startNode = graph.Nodes.Find(node => node.Name.ToString() == matchGroups[1].Value);
                Node endNode = graph.Nodes.Find(node => node.Name.ToString() == matchGroups[2].Value);

                int cost = int.Parse(matchGroups[3].Value);

                startNode.AddRoute(endNode, cost);
            }
        }
    }
}