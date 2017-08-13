using System;
using Domain.Models;
using Domain.Services.Dijkstra;

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
            var short1 = new Dijkstra(graph).CheapestCost(A, D);
            var short2 = new Dijkstra(graph).CheapestCost(D, E);
            System.Console.WriteLine(short1);
            System.Console.WriteLine(short2);
        }
    }
}
