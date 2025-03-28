using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250326_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 10;

            //업 캐스팅: 암시적으로 사용가능
            //박싱 : 값형식 -> 참조형식
            object obj = value;

            //다운캐스팅 : 명시적으로 해야함
            //언박싱 : 참조형식 -> 값형식
            int result = (int)obj;

            Console.WriteLine("{0},{1},{2}",value,obj,result);

            Parent parent = new child();
        }
    }
    //일반화 자료형 제약
    
    //일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸수 있는 자료형을 제한

    //일반화 함수

    //일반화는 자료형의 형식을 지정하지 않고 함수를 정의
    //기능을 구현한 뒤 사용 당시에 자료형의 형식을 지정해서 사용

    public class Parent
    {

    }

    public class child : Parent
    {

    }
}
