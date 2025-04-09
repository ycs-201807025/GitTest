using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250402_TP
{
    class Program
    {
        //알고리즘
        //인벤토리 정렬

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public void SelectionSort()
        {
            for (int i = 0; i < length; i++)
            {

            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O

        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X

        //스왑
        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 20;

            List<int> selectionList = new List<int>(count);
            List<int> insertionList = new List<int>(count);
            List<int> bubbleList = new List<int>(count);
            List<int> mergeList = new List<int>(count);
            List<int> quickList = new List<int>(count);
            List<int> heapList = new List<int>(count);
            List<int> introList = new List<int>(count);

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next() % 100;
                Console.Write($"{rand,3}");

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                heapList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                introList.Add(rand);
            }
            Console.WriteLine();


            /*Console.WriteLine("선택 정렬 결과 : ");
            SelectionSort(selectionList);
            foreach (int i in selectionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
            Console.WriteLine("삽입 정렬 결과 : ");
            InsertionSort(insertionList);
            foreach (int i in insertionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("버블 정렬 결과 : ");
            BubbleSort(bubbleList);
            foreach (int i in bubbleList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("합병 정렬 결과 : ");
            MergeSort(mergeList);
            foreach (int i in mergeList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("퀵 정렬 결과 : ");
            QuickSort(quickList);
            foreach (int i in quickList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("힙 정렬 결과 : ");
            HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("인트로 정렬 결과 : ");
            introList.Sort();
            foreach (int i in introList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();*/
        }
    }
}
