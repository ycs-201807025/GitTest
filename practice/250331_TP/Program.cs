using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250331_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int>[] listGraph = new List<int>[8];
            listGraph[0] = new List<int>() {3,4 };
            listGraph[1] = new List<int>() {6 };
            listGraph[2] = new List<int>() {5,6 };
            listGraph[3] = new List<int>() {0,7 };
            listGraph[4] = new List<int>() {0,6 };
            listGraph[5] = new List<int>() {2,7 };
            listGraph[6] = new List<int>() {1,2,4 };
            listGraph[7] = new List<int>() {3,5 };



            Graph<string> graph = new Graph<string>();


            GraphNode<string> a = graph.AddNode("A");
            GraphNode<string> b = graph.AddNode("B");
            GraphNode<string> c = graph.AddNode("C");
            GraphNode<string> d = graph.AddNode("D");
            GraphNode<string> e = graph.AddNode("E");
            GraphNode<string> f = graph.AddNode("F");
            GraphNode<string> g = graph.AddNode("G");
            GraphNode<string> h = graph.AddNode("H");
           
            graph.AddEdgeCycle(a, c);
            graph.AddEdgeCycle(a, e);
            graph.AddEdgeCycle(e, c);
            graph.AddEdgeCycle(b, c);
            graph.AddEdgeCycle(c, b);
            graph.AddEdgeCycle(c, f);
            graph.AddEdgeCycle(b, f);
            graph.AddEdgeCycle(d, b);
            graph.AddEdgeCycle(d, f);
            graph.AddEdgeCycle(h, f);
            graph.AddEdgeCycle(h, g);

            graph.PrintGraphInfo();

            //bool[,] graph = new bool[8, 8]
            //{
            //    { false, false,  true,  true, false, false, false, false },
            //    { false, false, false, false, false,  true, false, false },
            //    {  true,  true, false, false, false,  true, false, false },
            //    { false, false, false, false, false, false, false, false },
            //    { false, false,  true, false, false, false, false, false },
            //    { false, false, false, false, false, false,  true,  true },
            //    { false, false,  true, false, false, false, false,  true },
            //    { false, false, false, false, false, false, false, false },
            //};

            
        }
        public class GraphNode<T>
        {
            public T Value { get; set; }
            public List<GraphNode<T>> NeighborNodes { get; } = new List<GraphNode<T>>();

            public GraphNode(T value)
            {
                Value = value;
            }
            public void PrintNeighborNodes()
            {
                Console.WriteLine($"{Value} 인접노드");
                foreach (var neighbor in NeighborNodes)
                {
                    Console.WriteLine($" ㄴ {neighbor.Value}");
                }
            }
            public void AddEdge(GraphNode<T> node)
            {
                NeighborNodes.Add(node);
            }
            public void RemoveEdge(GraphNode<T> node)
            {
                NeighborNodes.Remove(node);
            }
        }
        public class Graph<T>
        {
            private List<GraphNode<T>> _nodes = new List<GraphNode<T>>();

            public GraphNode<T> AddNode(T value)
            {
                GraphNode<T> node = new GraphNode<T>(value);
                _nodes.Add(node);
                return node;
            }
            public void AddEdge(GraphNode<T> from, GraphNode<T> to)
            {
                from.NeighborNodes.Add(to);
            }
            public void AddEdgeCycle(GraphNode<T> from, GraphNode<T> to)
            {
                from.NeighborNodes.Add(to);
                to.NeighborNodes.Add(from);
            }
            public void RemoveNode(GraphNode<T> node)
            {
                foreach (var n in _nodes)
                {
                    n.RemoveEdge(node);
                }

                _nodes.Remove(node);
            }

            public void PrintGraphInfo()
            {
                Console.WriteLine("그래프 노드 구조 ---");
                foreach (var n in _nodes)
                {
                    n.PrintNeighborNodes();
                }
            }
        }
        
    }
}
