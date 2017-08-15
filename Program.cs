using System;
using System.Linq;
using Models;
using Services;
using Services.Dijkstra;

namespace ProductDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new Node('A');
            var B = new Node('B');
            var C = new Node('C');
            var D = new Node('D');
            var E = new Node('E');
            var F = new Node('F');
            var graph = new Graph(A, B, C, D, E, F);

            try
            {
                InputReader.PopulateGraph(graph, args);

                using(var service = new ProductDeliveryService(graph))
                {
                    var output1 = service.CostOfTheRoute(A, D, E);
                    System.Console.WriteLine($"Output #1: {output1}");

                    var output2 = service.CostOfTheRoute(A, F, E);
                    System.Console.WriteLine($"Output #2: {output2}");

                    var output3 = service.CostOfTheRoute(E, C, B);
                    System.Console.WriteLine($"Output #3: {output3}");

                    var output4 = service.CostOfTheRoute(B, D, F, E);
                    System.Console.WriteLine($"Output #4: {output4}");

                    var output5 = service.CostOfTheRoute(F, C);
                    System.Console.WriteLine($"Output #5: {output5}");

                    var output6 = service.CountRoutesArriving(C);
                    System.Console.WriteLine($"Output #6: {output6}");

                    var output7 = service.CountRoutesMaxStops(B, A, maxStops : 5);
                    System.Console.WriteLine($"Output #7: {output7}");

                    var output8 = service.CountRoutesExactlyStops(A, A, exactlyStops : 3);
                    System.Console.WriteLine($"Output #8: {output8}");

                    var output9 = service.ShortestRoute(A, E);
                    System.Console.WriteLine($"Output #9: {output9}");

                    var output10 = service.ShortestRoute(C, E);
                    System.Console.WriteLine($"Output #10: {output10}");

                    var output11 = service.CountRoutesMaxCost(A, B, maxCost : 39);
                    System.Console.WriteLine($"Output #11: {output11}");

                    var output12 = service.CountRoutesMaxCost(E, D, maxCost : 59);
                    System.Console.WriteLine($"Output #12: {output12}");
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine($"OOoops!  => {e.Message}");
            }

        }
    }
}