using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250402_Recursion
{
    class Program
    {
        /******************************************************
         * 재귀 (Recursion)
         * 
         * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
         * 함수를 정의할 때 자기자신을 이용하여 표현하는 방법
         ******************************************************/

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함

        // <재귀함수 장점>
        //1. 코드로 표현하기 어려운 경우도 직관적이고 처리가 가능
        //2. 분할정복을 통한 반절 계산이 가능해서 효율이 높아지게 구현이 가능하다

        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1

        static int Factorial(int x)
        {
            if (x == 1)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        int Fibonachi(int n)
        {
            if (n == 1)
                return 1;
            else if (n == 2)
            {
                return 1;
            }
            return Fibonachi(n - 1) + Fibonachi(n - 2);
        }
        //폴더 삭제
        public class Folder
        {
            public List<string> files;
            public List<Folder> children;
        }
        public static void RemoveFolder(Folder folder)
        {
            //파일들 삭제하고 

            foreach (Folder child in folder.children)
            {
                RemoveFolder(child);
            }
        }
        static void Main(string[] args)
        {
            int result = Factorial(5);
        }
    }
}
