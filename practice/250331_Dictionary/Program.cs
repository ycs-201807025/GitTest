﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250331_Dictionary
{
    class Program
    {
        public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>
        {
            private const int DefaultCapacity = 1000;

            private struct Entry
            {
                public enum State { None, Using, Deleted }

                public State state;
                public TKey key;
                public TValue value;
            }

            private Entry[] table;
            private int usedCount;
            private int deletedCount;

            public Dictionary()
            {
                table = new Entry[DefaultCapacity];
                usedCount = 0;
                deletedCount = 0;
            }

            public TValue this[TKey key]
            {
                get
                {
                    if (TryFind(key, out int index) == false)
                        throw new KeyNotFoundException();

                    return table[index].value;
                }
                set
                {
                    if (TryFind(key, out int index))
                    {
                        table[index].value = value;
                    }
                    else
                    {
                        Add(key, value);
                    }
                }
            }

            public int Capacity { get { return table.Length; } }
            public int Count { get { return usedCount; } }

            public void Add(TKey key, TValue value)
            {
                if (TryFind(key, out int index) == false)
                    throw new InvalidOperationException();

                if (usedCount + deletedCount > table.Length * 0.7f)
                {
                    ReHashing();
                }

                table[index].key = key;
                table[index].value = value;
                table[index].state = Entry.State.Using;
                usedCount++;
            }

            public void Clear()
            {
                table = new Entry[DefaultCapacity];
                usedCount = 0;
                deletedCount = 0;
            }

            public bool ContainsKey(TKey key)
            {
                if (TryFind(key, out int index))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool Remove(TKey key)
            {
                if (TryFind(key, out int index))
                {
                    table[index].state = Entry.State.Deleted;
                    usedCount--;
                    deletedCount++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool TryFind(TKey key, out int index)
            {
                if (key == null)
                    throw new ArgumentNullException();

                index = Hash(key);
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[index].state == Entry.State.None)
                    {
                        return false;
                    }
                    else if (table[index].state == Entry.State.Using)
                    {
                        if (key.Equals(table[index].key))
                        {
                            return true;
                        }
                        else
                        {
                            index = Hash2(index);
                        }
                    }
                    else // if (table[index].state == Entry.State.Deleted)
                    {
                        if (key.Equals(table[index].key))
                        {
                            return false;
                        }
                        else
                        {
                            index = Hash2(index);
                        }
                    }
                }

                index = -1;
                throw new InvalidOperationException();
            }

            private int Hash(TKey key)
            {
                // 나눗셈법
                return Math.Abs(key.GetHashCode() % table.Length);
            }

            private int Hash2(int index)
            {
                // 선형 탐사
                return (index + 1) % table.Length;

                // 제곱 탐사
                // return (index + 1) * (index + 1) % table.Length;

                // 이중 해싱
                // return Math.Abs((index + 1).GetHashCode() % table.Length);
            }

            private void ReHashing()
            {
                Entry[] oldTable = table;
                table = new Entry[table.Length * 2];
                usedCount = 0;
                deletedCount = 0;

                for (int i = 0; i < oldTable.Length; i++)
                {
                    Entry entry = oldTable[i];
                    if (entry.state == Entry.State.Using)
                    {
                        Add(entry.key, entry.value);
                    }
                }
            }

        }
        /***********************************************************************************
         * 해시테이블 (HashTable)
         * 
         * 키 값을 해시함수로 해싱하여 해시테이블의 특정 위치로 직접 엑세스하도록 만든 방식
         * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
         ***********************************************************************************/

        // <해시테이블 구현>
        // 데이터를 담을 테이블을 이미 크게 확보해 놓은 후
        // 입력받은 키를 해싱하여 테이블 고유한 index를 계산하고 데이터를 담아 보관
        // 
        //           해싱
        //          ┌────┐
        //      2 ─→│    │─→   2
        //    998 ─→│해시│─→ 998
        //   2066 ─→│함수│─→  66
        //   8027 ─→│    │─→  27
        //          └────┘
        //
        //   [0]   [1]   [2]        [27]        [66]       [997] [998] [999]
        // ┌─────┬─────┬─────┬─  ─┬──────┬─  ─┬──────┬─  ─┬─────┬─────┬─────┐
        // │     │     │  2  │....│ 8027 │....│ 2066 │....│     │ 998 │     │
        // └─────┴─────┴─────┴─  ─┴──────┴─  ─┴──────┴─  ─┴─────┴─────┴─────┘


        // <해시함수>
        // 키값을 해싱하여 고유한 index를 만드는 함수
        // 조건으로 하나의 키값을 해싱하는 경우 반드시 항상 같은 index를 반환해야 함
        // 대표적인 해시함수로 나눗셈법이 있음
        // 예시 : 2581 → (2581 % 1000) = 581


        // <해시테이블 주의점 - 충돌>
        // 해시함수가 서로 다른 입력 값에 대해 동일한 해시테이블 주소를 반환하는 것
        // 모든 입력 값에 대해 고유한 해시 값을 만드는 것은 불가능하며 충돌은 피할 수 없음
        //
        //           해싱
        //          ┌────┐
        //   1081 ─→│해시│─→  81
        //   2081 ─→│함수│─→  81
        //          └────┘
        //
        //   [0]   [1]   [2]          [81]          [997] [998] [999]
        // ┌─────┬─────┬─────┬─  ─┬───────────┬─  ─┬─────┬─────┬─────┐
        // │     │     │     │....│ 1081 2081 │....│     │     │     │
        // └─────┴─────┴─────┴─  ─┴───────────┴─  ─┴─────┴─────┴─────┘
        //                          ↑충돌발생


        // <충돌해결방안 - 체이닝>
        // 해시 충돌이 발생하면 연결리스트로 데이터들을 연결하는 방식
        // 장점 : 해시테이블에 자료사용률에 따른 성능저하가 적음
        // 단점 : 해시테이블 외 추가적인 저장공간이 필요, 삽입삭제시 오버헤드가 발생
        //
        //   [0]   [1]   [2]        [81]      [997] [998] [999]
        // ┌─────┬─────┬─────┬─  ─┬──────┬─  ─┬─────┬─────┬─────┐
        // │     │     │     │....│  │   │....│     │     │     │
        // └─────┴─────┴─────┴─  ─┴──│───┴─  ─┴─────┴─────┴─────┘
        //                           ↓
        //                        ┌──────┬─┐ ┌──────┬─┐
        //                        │ 1081 │──→│ 2081 │ │
        //                        └──────┴─┘ └──────┴─┘


        // <충돌해결방안 - 개방주소법>
        // 해시 충돌이 발생하면 다른 빈 공간에 데이터를 삽입하는 방식
        // 해시 충돌시 선형탐색, 제곱탐색, 이중해시 등을 통해 다른 빈 공간을 선정
        // 장점 : 추가적인 저장공간이 필요하지 않음, 삽입삭제시 오버헤드가 적음
        // 단점 : 해시테이블에 자료사용률에 따른 성능저하가 발생
        //                          
        //   [0]   [1]   [2]        [81]   [82]       [997] [998] [999]
        // ┌─────┬─────┬─────┬─  ─┬──────┬──────┬─  ─┬─────┬─────┬─────┐
        // │     │     │     │....│ 1081 │      │....│     │     │     │
        // └─────┴─────┴─────┴─  ─┴──────┴──────┴─  ─┴─────┴─────┴─────┘
        //                          ↑2081(충돌)
        //
        //   [0]   [1]   [2]        [81]   [82]       [997] [998] [999]
        // ┌─────┬─────┬─────┬─  ─┬──────┬──────┬─  ─┬─────┬─────┬─────┐
        // │     │     │     │....│ 1081 │ 2081 │....│     │     │     │
        // └─────┴─────┴─────┴─  ─┴──────┴──────┴─  ─┴─────┴─────┴─────┘
        //                                 ↑(다음위치에 저장)


        // <해시테이블 효율>
        // 해시테이블의 공간 사용률이 높을 경우(통계적으로 70% 이상) 급격한 성능저하가 발생
        // 이런 경우 재해싱을 통해 공간 사용률을 낮추어 다시 효율을 확보함
        // 재해싱 : 해시테이블의 크기를 늘리고 테이블 내의 모든 데이터를 다시 해싱하여 보관
        //
        // ┌─────┬─────┬─────┬─────┬─────┐
        // │ 124 │ 258 │     │ 857 │ 858 │
        // └─────┴─────┴─────┴─────┴─────┘
        //   ↓ 재해싱
        // ┌─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┬─────┐
        // │ 124 │     │     │ 857 │ 858 │     │     │ 258 │     │     │
        // └─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┴─────┘


        // <해시테이블 시간복잡도>
        // 접근       탐색       삽입       삭제
        //  X         O(1)       O(1)       O(1)
        static void Main(string[] args)
        {

            // 해시테이블 기반의 HashSet 자료구조
            // 중복이 없는 해싱을 통한 빠른 탐색의 저장소
            HashSet<int> hashSet = new HashSet<int>();

            // 삽입
            hashSet.Add(1);
            hashSet.Add(3);
            hashSet.Add(4);
            hashSet.Add(5);
            hashSet.Add(2);
            hashSet.Add(3);     // 중복 추가는 무시함
            hashSet.Add(3);
            hashSet.Add(3);

            // 삭제
            hashSet.Remove(4);

            // 탐색
            hashSet.Contains(3);    // 포함 확인

            // 순회
            foreach (int value in hashSet)
            {
                Console.Write(value);   // output : 1352
            }
            Console.WriteLine();


            // 해시테이블 기반의 Dictionary 자료구조
            // 중복을 허용하지 않는 key를 기준으로 해싱을 통한 빠른 탐색의 value 저장소
            Dictionary<string, Book> dictionary = new Dictionary<string, Book>();

            // 삽입
            dictionary.Add("BookA", new Book("BookA", "WriterA", 100));
            dictionary.Add("BookB", new Book("BookB", "WriterB", 200));
            dictionary.Add("BookC", new Book("BookC", "WriterC", 300));
            dictionary.Add("BookD", new Book("BookD", "WriterD", 400));
            dictionary.Add("BookE", new Book("BookE", "WriterE", 500));
            // dictionary.Add("BookC", new Book("BookC", "WriterE", 700));  // error : 동일 키값의 데이터를 중복불가

            // 삭제
            dictionary.Remove("BookD");

            // 탐색
            dictionary.ContainsKey("BookB");                    // 포함 확인
            dictionary.TryGetValue("BookE", out Book book);     // 탐색 시도

            // 인덱서를 통한 간략한 사용
            Book indexerBook = dictionary["BookA"];                     // 탐색 후 반환(없을 시 오류)
            dictionary["BookF"] = new Book("BookF", "WriterF", 600);    // 탐색 후 대입(없을 시 삽입)

            //// 순회
            //foreach (string key in dictionary.Keys)
            //{
            //    Console.WriteLine(key);
            //}
            //foreach (Book value in dictionary.Values)
            //{
            //    Console.WriteLine($"{value.name} : {value.writer}, {value.pages}pages");
            //}
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
        }
    }
}
