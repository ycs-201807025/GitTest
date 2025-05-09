﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             메모리 (Memory)

            프로그램을 처리하기 위해 필요한 정보를 저장하는 기억장치
            프로그래은 메모리에 저장한 정보를 토대로 명령들을 수행함
             */
             /*
              * 메모리 구조
              * 
              * 프로그램은 효율적인 메모리 관리를 위해 메모리 영역을 구분
              * 데이터는 각 역할마다 저장되는 영역을 달리하여 접근범위, 생존범위 등을 관리
              */
             /*<코드 영역>
              
                프로그램이 실행할 코드가 저장되는 영역
                데이터가 변경되지 않은 읽기 전용 데이터

               <데이터 영역>
                
                정적변수가 저장되는 영역
                프로그램의 시작시 할당되며 종료시 삭제됨

               <스택 영역>

                지역변수와 매개변수가 저장되는 영역
                함수의 호출시 할당되며 종료시 삭제됨

               <힙 영역>
                
                클래스 인스턴스가 저장되는 영역
                인스턴스를 생성시 할당되며 더이상 사용하지 않을시 자동으로 삭제됨
                인스턴스를 참조하고 있는 변수가 없을 때 더이상 사용하지 않는다고 판단
                더이상 사용하지 않는 인스턴스는 가비지 컬랙터가 특정 타이밍에 수거해감
              */
        }
    }
}
