using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250331_Graph
{
    class Program
    {
        internal class Graph
        {
            /************************************************************************
             * 그래프 (Graph)
             * 
             * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
             * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
             * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
             * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
             ************************************************************************/

            // <인접행렬 그래프>
            // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
            // 2차원 배열을 [출발정점, 도착정점] 으로 표현
            // 장점 : 인접여부 접근이 빠름
            // 단점 : 메모리 사용량이 많음

            // 예시 - 양방향 연결 그래프
            bool[,] matrixGraph1 = new bool[5, 5]
            {
            { false, false, false, false,  true },
            { false, false,  true, false, false },
            { false,  true, false,  true, false },
            { false, false,  true, false,  true },
            {  true, false, false,  true, false },
            };

            const int INF = int.MaxValue;

            // 예시 - 단방향 가중치 그래프 (단절은 최대값으로 표현)
            int[,] matrixGraph2 = new int[5, 5]
            {
            {   0, 132, INF, INF,  16 },
            {  12,   0, INF, INF, INF },
            { INF,  38,   0, INF, INF },
            { INF,  12, INF,   0,  54 },
            { INF, INF, INF, INF,   0 },
            };


            // <인접리스트 그래프>
            // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
            // 인접한 간선만을 리스트에 추가하여 관리
            // 장점 : 메모리 사용량이 적음
            // 단점 : 인접여부를 확인하기 위해 리스트 탐색이 필요

            // 예시
            List<int>[] listGraph1;                 // 연결 그래프
            List<(int, int)>[] listGraph2;          // 가중치 그래프
            public void CreateGraph()
            {
                listGraph1 = new List<int>[5];

                listGraph1[0].Add(1);
                listGraph1[1].Add(0);
                listGraph1[1].Add(3);
                listGraph1[2].Add(0);
                listGraph1[2].Add(1);
                listGraph1[2].Add(4);
                listGraph1[3].Add(1);
                listGraph1[4].Add(3);
            }
        }
        static void Main(string[] args)
        {
            // 순차탐색
            int index1;
            int index2;
            int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            Console.Write("배열 : ");
            foreach (int i in array)
            {
                Console.Write($"{i,2}");
            }
            Console.WriteLine();

            index1 = Array.IndexOf(array, 2);
            index2 = Searching.SequentialSearch(array, 2);
            Console.WriteLine($"순차탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 순차탐색 결과 위치 : {index2}");
            Console.WriteLine();


            // 이진탐색
            index1 = Array.BinarySearch(array, 2);
            index2 = Searching.BinarySearch(array, 2);
            Console.WriteLine("정렬 전 결과");
            Console.WriteLine($"이진탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 이진탐색 결과 위치 : {index2}");
            Console.WriteLine();

            Array.Sort(array);  // 이진탐색의 경우 우선 정렬이 필요
            Console.Write("정렬된 배열 : ");
            foreach (int i in array)
            {
                Console.Write($"{i,2}");
            }
            Console.WriteLine();

            index1 = Array.BinarySearch(array, 2);
            index2 = Searching.BinarySearch(array, 2);
            Console.WriteLine("정렬 후 결과");
            Console.WriteLine($"이진탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 이진탐색 결과 위치 : {index2}");
            Console.WriteLine();


            bool[,] graph = new bool[8, 8]
            {
                { false,  true, false, false, false, false, false, false },
                {  true, false,  true, false, false,  true, false, false },
                { false,  true, false, false,  true,  true, false, false },
                { false, false, false, false, false,  true, false, false },
                { false, false,  true, false, false, false,  true,  true },
                { false,  true,  true,  true, false, false, false, false },
                { false, false, false, false,  true, false, false, false },
                { false, false, false, false,  true, false, false, false },
            };


            // DFS 탐색
            Console.WriteLine("<DFS>");
            Searching.DFS(graph, 0, out bool[] dfsVisited, out int[] dfsParents);
            PrintGraphSearch(dfsVisited, dfsParents);
            Console.WriteLine();


            // BFS 탐색
            Console.WriteLine("<BFS>");
            Searching.BFS(graph, 0, out bool[] bfsVisited, out int[] bfsParents);
            PrintGraphSearch(bfsVisited, bfsParents);
            Console.WriteLine();
        }
        private static void PrintGraphSearch(bool[] visited, int[] parents)
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Parent",8}");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.WriteLine($"{i,8}{visited[i],8}{parents[i],8}");
            }
        }
        class Searching
        {
            // <순차 탐색>
            // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
            // 시간복잡도 - O(n)
            public static int SequentialSearch<T>(IList<T> list, in T item)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }


            // <이진 탐색>
            // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
            // 단, 이진 탐색은 정렬이 되어 있는 자료에만 적용 가능
            // 시간복잡도 - O(logn)
            public static int BinarySearch<T>(IList<T> list, in T item) where T : IComparable<T>
            {
                int low = 0;
                int high = list.Count - 1;
                while (low <= high)
                {
                    int middle = (low + high) / 2;
                    int compare = list[middle].CompareTo(item);

                    if (compare < 0)
                    {
                        low = middle + 1;
                    }
                    else if (compare > 0)
                    {
                        high = middle - 1;
                    }
                    else
                    {
                        return middle;
                    }
                }

                return -1;
            }


            // <깊이 우선 탐색 (Depth-First Search)>
            // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
            // 분기의 탐색을 마쳤을 때 다음 분기를 탐색
            // 스택을 통해 구현
            public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
            {
                int size = graph.GetLength(0);
                visited = new bool[size];
                parents = new int[size];

                for (int i = 0; i < size; i++)
                {
                    visited[i] = false;
                    parents[i] = -1;
                }

                SearchNode(graph, start, visited, parents);
            }

            private static void SearchNode(bool[,] graph, int vertex, bool[] visited, int[] parents)
            {
                int size = graph.GetLength(0);
                visited[vertex] = true;
                for (int i = 0; i < size; i++)
                {
                    if (graph[vertex, i] &&     // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        parents[i] = vertex;
                        SearchNode(graph, i, visited, parents);
                    }
                }
            }


            // <너비 우선 탐색 (Breadth-First Search)>
            // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
            // 다음 깊이의 분기들을 탐색
            // 큐를 통해 탐색
            public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
            {
                int size = graph.GetLength(0);
                visited = new bool[size];
                parents = new int[size];

                for (int i = 0; i < size; i++)
                {
                    visited[i] = false;
                    parents[i] = -1;
                }

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(start);
                visited[start] = true;

                while (queue.Count > 0)
                {
                    int next = queue.Dequeue();

                    for (int i = 0; i < size; i++)
                    {
                        if (graph[next, i] &&       // 연결되어 있는 정점이며,
                            !visited[i])            // 방문한적 없는 정점
                        {
                            visited[i] = true;
                            parents[i] = next;
                            queue.Enqueue(i);
                        }
                    }
                }
            }
        }
    }
}
