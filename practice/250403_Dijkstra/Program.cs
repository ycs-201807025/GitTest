﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250403_Dijkstra
{

    class Program
    {
        /********************************************************************
         * 다익스트라 알고리즘 (Dijkstra Algorithm)
         * 
         * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
         * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
         * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
         ********************************************************************/

        const int INF = 99999;

        public static void ShortestPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            distance = new int[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                distance[i] = INF;
                parents[i] = -1;
                visited[i] = false;
            }
            distance[start] = 0;

            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minCost)
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }
                if (next < 0)
                    break;
                visited[next] = true;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        parents[j] = next;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            int[,] graph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);
            PrintDijkstra(visited, distance, parents);
        }
        private static void PrintDijkstra(bool[] visited, int[] distance, int[] parents)
        {
            Console.WriteLine($"{"Vertex",-12}{"Visit",-12}{"Distance",-12}{"Parent",-12}");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write($"{i,-12}");

                Console.Write($"{visited[i],-12}");

                if (distance[i] >= INF)
                {
                    Console.Write($"{"INF",-12}");
                }
                else
                {
                    Console.Write($"{distance[i],-12}");
                }

                Console.WriteLine($"{parents[i],-12}");
            }
        }
    }
}
