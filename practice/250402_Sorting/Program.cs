using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250402_Sorting
{
    class Program
    {
        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (list[j - 1] > list[j])
                    {
                        Swap(list, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }



        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O
        public static void MergeSort(IList<int> list) => MergeSort(list, 0, list.Count - 1);

        public static void MergeSort(IList<int> list, int start, int end)
        {
            if (start == end)
            {
                return;
            }

            int mid = (start + end) / 2;
            MergeSort(list, start, mid);
            MergeSort(list, mid + 1, end);
            Merge(list, start, mid, end);
        }

        private static void Merge(IList<int> list, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (list[leftIndex] < list[rightIndex])
                {
                    sortedList.Add(list[leftIndex++]);
                }
                else
                {
                    sortedList.Add(list[rightIndex++]);
                }
            }

            if (leftIndex > mid)
            {
                for (int i = rightIndex; i <= end; i++)
                {
                    sortedList.Add(list[i]);
                }
            }
            else // if (rightIndex > end)
            {
                for (int i = leftIndex; i <= mid; i++)
                {
                    sortedList.Add(list[i]);
                }
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                list[start + i] = sortedList[i];
            }
        }



        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void QuickSort(IList<int> list) => QuickSort(list, 0, list.Count - 1);

        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right)
            {
                while (list[left] <= list[pivot] && left < right)
                {
                    left++;
                }
                while (list[right] > list[pivot] && left <= right)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(list, left, right);
                }
                else
                {
                    Swap(list, pivot, right);
                    break;
                }
            }

            QuickSort(list, start, right - 1);
            QuickSort(list, right + 1, end);
        }



        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X
        public static void HeapSort(IList<int> list)
        {
            MakeHeap(list);

            for (int i = list.Count - 1; i > 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, 0, i);
            }
        }

        private static void MakeHeap(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                Heapify(list, i, list.Count);
            }
        }

        private static void Heapify(IList<int> list, int index, int size)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int max = index;
            if (left < size && list[left] > list[max])
            {
                max = left;
            }
            if (right < size && list[right] > list[max])
            {
                max = right;
            }

            if (max != index)
            {
                Swap(list, index, max);
                Heapify(list, max, size);
            }
        }
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


            Console.WriteLine("선택 정렬 결과 : ");
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
            Console.WriteLine();
        }
    }
}
