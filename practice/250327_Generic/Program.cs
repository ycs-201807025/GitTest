using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250327_Generic
{
    class Program
    {
        /**************************************************************************
         * 일반화 델리게이트
         * 
         * 개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용
         **************************************************************************/

        // <Func 델리게이트>
        // 반환형과 매개변수를 지정한 델리게이트
        // Func<매개변수1, 매개변수2, ..., 반환형>
        static int Plus(int left, int right) { return left + right; }
        static int Minus(int left, int right) { return left - right; }
        static void Main(string[] args)
        {
            Func<int, int, int> func;
            func = Plus;
            func = Minus;

            Action<string> action;
            action = Message;

            Predicate<string> predicate;
            predicate = IsSentence;
        }
        // <Action 델리게이트>
        // 반환형이 void 이며 매개변수를 지정한 델리게이트
        // Action<매개변수1, 매개변수2, ...>
        static void Message(string message) { Console.WriteLine(message); }

        


        // <Predicate 델리게이트>
        // 반환형이 bool, 매개변수가 하나인 델리게이트
        static bool IsSentence(string str) { return str.Contains(' '); }

        
    }
}
