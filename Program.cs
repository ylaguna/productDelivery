using System;
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

            A.AddRoute(D, 4);
            D.AddRoute(E, 1);
            E.AddRoute(C, 8);
            C.AddRoute(B, 2);
            B.AddRoute(A, 6);
            A.AddRoute(C, 9);
            D.AddRoute(F, 7);
            F.AddRoute(C, 5);
            F.AddRoute(E, 9);
            B.AddRoute(D, 3);
            F.AddRoute(A, 3);

            var graph = new Graph(A, B, C, D, E, F);
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

                var output7 = service.CountRoutes(B, A, maxStops : 5);
                System.Console.WriteLine($"Output #7: {output7}");

                var output8 = service.CountRoutes(A, A, maxStops : 3);
                System.Console.WriteLine($"Output #8: {output8}");

                var output9 = service.ShortestRoute(A, E);
                System.Console.WriteLine($"Output #9: {output9}");

                var output10 = service.ShortestRoute(C, E);
                System.Console.WriteLine($"Output #10: {output10}");

                var output11 = service.CountRoutes(A, B, maxCost : 39);
                System.Console.WriteLine($"Output #11: {output11}");

                var output12 = service.CountRoutes(E, D, maxCost : 59);
                System.Console.WriteLine($"Output #12: {output12}");
            }
        }
    }
}