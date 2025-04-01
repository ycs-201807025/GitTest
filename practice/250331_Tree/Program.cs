using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250331_Tree
{
    class Program
    {
        /*******************************************************************************
         * 트리 (Tree)
         * 
         * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
         * 부모노드가 여러자식노드들을 가질 수 있는 1 대 다 구조
         * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가지지 않음
         ********************************************************************************/

        // <트리 구성>
        // 부모(Parent) : 루트 노드 방향으로 직접 연결된 노드
        // 자식(Child)  : 루트 노드 반대방향으로 직접 연결된 노드
        //
        // 뿌리(root)   : 부모노드가 없는 최상위 노드, 트리의 깊이 0에 하나만 존재
        // 가지(Branch) : 부모노드와 자식노드가 모두 있는 노드, 트리의 중간에 존재
        // 잎(Leaf)     : 자식노드가 없는 노드, 트리의 끝에 존재
        //
        // 길이(Length) : 출발 노드에서 도착 노드까지 거치는 수
        // 깊이(Depth)  : 루트 노드부터의 길이
        // 차수(Degree) : 자식노드의 갯수
        //
        //             뿌리                  - 깊이 0
        //        ┌─────┼─────┐
        //       가지  가지  가지            - 깊이 1
        //  ┌─────┤     │     │
        // 가지  가지   잎   가지            - 깊이 2
        //  │     │           ├────┬────┐
        //  잎    잎         가지  잎   잎   - 깊이 3
        //                    ├────┐
        //                    잎   잎        - 깊이 4


        // <트리 사용처>
        // 주로 계층구조를 가질 수 있는 자료나 효율적인 검색에 많이 사용됨
        // ex) 윈도우의 폴더 구조, 문서의 목차, 데이터 베이스 & 검색 엔진의 구조
        //     상위스킬을 배워야 하위스킬을 배울 수 있는 스킬트리


        // <트리 구현>
        // 노드를 기반으로 부모노드와 자식노드들을 보관할 수 있도록 구성
        // 자식노드들의 최대갯수가 정해져 있는 경우 배열로, 정해지지 않은 경우 리스트로 구현
        public class TreeNode<T>
        {
            public T item;
            public TreeNode<T> parent;
            public List<TreeNode<T>> children;
        }


        // <이진 트리>
        // 부모노드가 자식노드를 최대 2개까지만 가질 수 있는 트리
        // n개의 자식을 가질 수 있는 트리를 연결구조를 변경하여 이진트리로 변환 가능
        // 그러므로, 특별한 이유가 없는 이상은 이진 트리로 구현하는 것이 일반적
        public class BinaryNode<T>
        {
            public T item;
            public BinaryNode<T> parent;
            public BinaryNode<T> left;
            public BinaryNode<T> right;
        }


        // <이진트리 순회>
        // 트리는 비선형 자료구조로 순차적 처리를 위해 순서에 대해 규칙을 선정해야 함
        // 순회의 방식은 크게 전위, 중위, 후위 순회가 있음
        // 전위순회(Pre-Order)  : 노드, 왼쪽, 오른쪽
        // 중위순회(In-Order)   : 왼쪽, 노드, 오른쪽
        // 후위순회(Post-Order) : 왼쪽, 오른쪽, 노드
        //
        //        A
        //    ┌───┴───┐
        //    B       C
        //  ┌─┴─┐   ┌─┴─┐
        //  D   E   F   G
        //
        // 전위순회 : A, (B, D, E), (C, F, G) => A, B, D, E, C, F, G
        // 중위순회 : (D, B, E), A, (F, C, G) => D, B, E, A, F, C, G
        // 후위순회 : (D, E, B), (F, G, C), A => D, E, B, F, G, C, A

        /******************************************************************
         * 이진탐색트리 (BinarySearchTree)
         * 
         * 이진속성과 탐색속성을 적용한 트리
         * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
         * 이진 : 부모노드는 최대 2개의 자식노드를 가질 수 있음
         * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
         *******************************************************************/

        // <이진탐색트리 구현>
        // 이진탐색트리는 모든 노드들이 최대 2개의 자식노드를 가질 수 있으며
        // 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치시킴
        //
        //             23
        //      ┌──────┴──────┐
        //      11            38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘     └─┐
        //     6 17  22  24        87


        // <이진탐색트리 탐색>
        // 아래의 이진탐색트리에서 17 탐색
        // 루트 노드부터 시작하여 탐색하는 값과 비교하여,
        // 작은 경우 왼쪽자식노드로, 큰 경우 오른쪽자식노드를 탐색
        //
        //             23(↙)
        //      ┌──────┴──────┐
        //      11(↘)         38
        //   ┌──┴──┐       ┌──┴──┐
        //   3     19(↙)   31    65
        //   └┐  ┌─┴─┐   ┌─┘
        //    6 (17)  22  24


        // <이진탐색트리 삽입>
        // 아래의 이진탐색트리에서 35 삽입
        // 루트 노드부터 시작하여 삽입하는 값과 비교하여,
        // 작은 경우 왼쪽자식노드로, 큰 경우 오른쪽자식노드로 하강
        // 만약 빈공간이라면 빈공간에 삽입
        //
        //             23(↘)                          23
        //      ┌──────┴──────┐                ┌──────┴──────┐
        //      11            38(↙)            11            38
        //   ┌──┴──┐       ┌──┴──┐      =>  ┌──┴──┐       ┌──┴──┐ 
        //   3     19      31(↘) 65         3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘                └─┐ ┌─┴─┐   ┌─┴─┐
        //     6 17  22  24                   6 17  22  24 (35)


        // <이진탐색트리 삭제>
        // 1. 자식이 0개인 노드의 삭제 : 단순 삭제 진행
        // 아래의 이진탐색트리에서 22 삭제
        //
        //             23                             23
        //      ┌──────┴──────┐                ┌──────┴──────┐
        //      11            38               11            38
        //   ┌──┴──┐       ┌──┴──┐    =>    ┌──┴──┐       ┌──┴──┐
        //   3     19      31    65         3     19      31    65
        //   └─┐ ┌─┴─┐   ┌─┘                └─┐ ┌─┘     ┌─┴─┐
        //     6 17 (22) 24                   6 17      24  35
        //
        // 2. 자식이 1개인 노드의 삭제 : 삭제하는 노드의 부모와 자식을 연결 후 삭제
        // 아래의 이진탐색트리에서 38 삭제
        //
        //            23                              23
        //     ┌──────┴──────┐                 ┌──────┴──────┐
        //     11            (38)              11            31
        //  ┌──┴──┐       ┌──┘        =>    ┌──┴──┐       ┌──┴──┐ 
        //  3     19      31                3     19      24    35
        //  └─┐ ┌─┴─┐   ┌─┴─┐               └─┐ ┌─┴─┐
        //    6 17  22  24  35                6 17  22
        //
        // 3. 자식이 2개인 노드의 삭제 : 삭제하는 노드를 기준으로 오른쪽자식 중 가장 작은 값 노드와 교체 후 삭제
        // 아래의 이진탐색트리에서 23 삭제
        //
        //           (23)                             24                              24
        //     ┌──────┴──────┐                 ┌──────┴──────┐                 ┌──────┴──────┐
        //     11            38                11            38                11            38
        //  ┌──┴──┐       ┌──┴──┐     =>    ┌──┴──┐       ┌──┴──┐     =>    ┌──┴──┐       ┌──┴──┐ 
        //  3     19      24    49          3     19     (23)   49          3     19      35   49
        //  └─┐ ┌─┴─┐     └─┐               └─┐ ┌─┴─┐     └─┐               └─┐ ┌─┴─┐
        //    6 17  22      35                6 17  22      35                6 17  22


        // <이진탐색트리 정렬>
        // 이진탐색트리는 중위순회시 오름차순으로 정렬됨
        //
        //             7
        //      ┌──────┴──────┐
        //      4             11
        //   ┌──┴──┐       ┌──┴──┐
        //   2     5       9     12
        // ┌─┴─┐   └─┐   ┌─┴─┐
        // 1   3     6   8   10
        //
        // 중위순회 : ((1, 2, 3), 4, (5, 6)), 7, ((8, 9, 10), 11, 12)
        //            => 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12


        // <이진탐색트리 주의점>
        // 이진탐색트리는 최악의 상황에 노드들이 한쪽 자식으로만 추가되는 불균형 현상이 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        //
        //           5
        //         ┌─┘
        //         4
        //       ┌─┘
        //       3
        //     ┌─┘
        //     2
        //   ┌─┘
        //   1
        //
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 자가균형트리는 회전을 이용하여 불균형이 있는 상황을 해결
        //
        //       8                        5
        //    ┌──┴──┐   -- 우회전 ->   ┌──┴──┐
        //    5     9                  3     8
        //  ┌─┴─┐       <- 좌회전 --       ┌─┴─┐      
        //  3   6                          6   9 
        //
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등을 통해 불균형상황을 파악


        // <이진탐색트리 시간복잡도>
        // - 평균 -
        // 접근       탐색       삽입       삭제
        // O(logn)    O(logn)    O(logn)    O(logn)
        //
        // - 최악 -
        // 접근       탐색       삽입       삭제
        // O(n)       O(n)       O(n)       O(n)

        static void Main(string[] args)
        {
            // 이진탐색트리 기반의 SortedSet 자료구조
            // 중복이 없는 정렬을 보장한 저장소
            SortedSet<int> sortedSet = new SortedSet<int>();

            // 삽입
            sortedSet.Add(1);
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);
            sortedSet.Add(2);
            sortedSet.Add(3);       // 중복 추가는 무시함
            sortedSet.Add(3);
            sortedSet.Add(3);

            // 삭제
            sortedSet.Remove(4);

            // 탐색
            sortedSet.Contains(3);          // 포함 확인

            // 순서대로 출력시 정렬된 결과 확인
            foreach (int value in sortedSet)
            {
                Console.Write(value);       // output : 1235
            }
            Console.WriteLine();


            // 이진탐색트리 기반의 SortedDictionary 자료구조
            // 중복을 허용하지 않는 key를 기준으로 정렬을 보장한 value 저장소
            SortedDictionary<string, Book> sortedDictionary = new SortedDictionary<string, Book>();

            // 삽입
            sortedDictionary.Add("BookA", new Book("BookA", "WriterA", 100));
            sortedDictionary.Add("BookB", new Book("BookB", "WriterB", 200));
            sortedDictionary.Add("BookC", new Book("BookC", "WriterC", 300));
            sortedDictionary.Add("BookD", new Book("BookD", "WriterD", 400));
            sortedDictionary.Add("BookE", new Book("BookE", "WriterE", 500));
            // sortedDictionary.Add("BookC", new Book("BookC", "WriterE", 700));    // error : 동일 키값의 데이터를 중복불가

            // 삭제
            sortedDictionary.Remove("BookD");

            // 탐색
            sortedDictionary.ContainsKey("BookB");                      // 포함 확인
            sortedDictionary.TryGetValue("BookE", out Book book);       // 탐색 시도
            string str = sortedDictionary["BookA"].ToString();          // 인덱서를 통한 탐색

            // 순서대로 출력시 정렬된 결과 확인
            foreach (string key in sortedDictionary.Keys)
            {
                Console.WriteLine(key);
            }
            foreach (Book value in sortedDictionary.Values)
            {
                Console.WriteLine(value);
            }
        }
        public class Book
        {
            public string name;
            public string writer;
            public int pages;

            public Book(string name, string writer, int pages)
            {
                this.name = name;
                this.writer = writer;
                this.pages = pages;
            }

            public override string ToString()
            {
                return $"{name} : {writer}, {pages}pages";
            }
        }
        public class BinarySearchTree<T> where T : IComparable<T>
        {
            private Node root;

            public BinarySearchTree()
            {
                this.root = null;
            }

            public bool Add(T item)
            {
                if (root == null)
                {
                    Node newNode = new Node(item, null, null, null);
                    root = newNode;
                    return true;
                }

                Node current = root;
                while (current != null)
                {
                    if (item.CompareTo(current.item) < 0)
                    {
                        if (current.left == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.left = newNode;
                            newNode.parent = current;
                            break;
                        }

                        current = current.left;
                    }
                    else if (item.CompareTo(current.item) > 0)
                    {
                        if (current.right == null)
                        {
                            Node newNode = new Node(item, null, null, null);
                            current.right = newNode;
                            newNode.parent = current;
                            break;
                        }

                        current = current.right;
                    }
                    else // if (item.CompareTo(current.item) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            public bool Remove(T item)
            {
                Node findNode = FindNode(item);
                if (findNode != null)
                {
                    EraseNode(findNode);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Contains(T item)
            {
                Node findNode = FindNode(item);
                return findNode != null ? true : false;
            }

            public void Clear()
            {
                root = null;
            }

            private Node FindNode(T item)
            {
                if (root == null)
                {
                    return null;
                }

                Node current = root;
                while (current != null)
                {
                    if (item.CompareTo(current.item) < 0)
                    {
                        current = current.left;
                    }
                    else if (item.CompareTo(current.item) > 0)
                    {
                        current = current.right;
                    }
                    else // if (item.CompareTo(current.item) == 0)
                    {
                        return current;
                    }
                }

                return null;
            }

            private void EraseNode(Node node)
            {
                if (node.left == null && node.right == null)
                {
                    Node parent = node.parent;

                    if (parent == null)
                    {
                        root = null;
                    }
                    else if (parent.left == node)
                    {
                        parent.left = null;
                    }
                    else if (parent.right == node)
                    {
                        parent.right = null;
                    }
                }
                else if (node.left == null || node.right == null)
                {
                    Node parent = node.parent;
                    Node child = node.left != null ? node.left : node.right;

                    if (parent == null)
                    {
                        root = child;
                        child.parent = null;
                    }
                    else if (parent.left == node)
                    {
                        parent.left = child;
                        child.parent = parent;
                    }
                    else if (parent.right == node)
                    {
                        parent.right = child;
                        child.parent = parent;
                    }
                }
                else // if (node.left != null && node.right != null)
                {
                    Node nextNode = node.right;
                    while (nextNode.left != null)
                    {
                        nextNode = nextNode.left;
                    }
                    node.item = nextNode.item;
                    EraseNode(nextNode);
                }
            }

            private class Node
            {
                public T item;
                public Node parent;
                public Node left;
                public Node right;

                public Node(T item, Node parent, Node left, Node right)
                {
                    this.item = item;
                    this.parent = parent;
                    this.left = left;
                    this.right = right;
                }
            }
        }
    }
}
