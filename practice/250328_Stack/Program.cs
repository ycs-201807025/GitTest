﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250328_Stack
{
    class Program
    {
        /******************************************************
         * 스택 (Stack)
         * 
         * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
         * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
         ******************************************************/

        // <스택 구현>
        // 스택은 리스트를 사용법만 달리하여 구현 가능
        //
        // - 삽입 -
        //         top                      top
        //          ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│ │ │ │  =>  │1│2│3│4│5│6│ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삭제 -
        //           top                  top
        //            ↓                    ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│ │ │  =>  │1│2│3│4│5│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);                          // 입력순서 : 0, 1, 2, 3, 4
            }

            Console.WriteLine(stack.Peek());            // 최상단 : 4

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(stack.Pop());         // 출력순서 : 4, 3, 2
            }

            for (int i = 5; i < 10; i++)
            {
                stack.Push(i);                          // 입력순서 : 5, 6, 7, 8, 9
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());         // 출력순서 : 9, 8, 7, 6, 5, 1, 0
            }
        }
    
    }
}
