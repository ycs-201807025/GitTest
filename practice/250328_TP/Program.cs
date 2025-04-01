using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250328_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            ParenthesesCheck p = new ParenthesesCheck();
            Console.WriteLine(p.Check("([])"));
            Console.WriteLine(p.Check("["));
            Console.WriteLine(p.Check("{"));
            Console.WriteLine(p.Check("{}[]"));
            Console.WriteLine(p.Check("[{()}]"));
           
            
            Ysps ysps = new Ysps();
            ysps.Ys(70, 12);
        }
        //괄호 검사기 : 입력(string "()[]{}) stack
        class ParenthesesCheck
        {
            public bool Check(string s)
            {
                Stack<string> stack = new Stack<string>();

                foreach (char item in s)
                {
                    if (item == '(' || item == '{' || item == '[')
                    {
                        stack.Push(item.ToString());
                        continue;
                    }
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
                return stack.Count == 0;
            }
            
        }


        //요세푸스문제 queue
        class Ysps
        {
            public void Ys(int n, int k)
            {
                Queue<int> queue = new Queue<int>();

                for (int i = 1; i <= n; i++)
                {
                    queue.Enqueue(i);
                    Console.WriteLine(i);
                }
                while (queue.Count > 1)
                {
                    for (int i = 1; i < k; i++)
                    {
                        queue.Enqueue(queue.Dequeue());  
                    }
                    Console.WriteLine("제거되는 번호{0}", queue.Dequeue());
                }
                Console.WriteLine("마지막에 남은 번호{0}", queue.Dequeue());
            }
        }
            
        
    }
}
