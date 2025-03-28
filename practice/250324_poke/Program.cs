using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_poke
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Poketmon poketmon1 = new firy();
            Poketmon poketmon2 = new Ggobugi();
            Poketmon poketmon3 = new chicorita();
            Poketmon poketmon4 = new gugu();
            Poketmon poketmon5 = new katerpy();
            Poketmon poketmon6 = new picachu();

            poketmon1.excute();
            poketmon2.excute();
            poketmon3.excute();
            poketmon4.excute();
            poketmon5.excute();
            poketmon6.excute();
        }
    }
    class Trainer
    {
        public string name;
        public string monster;// = {"파이리","꼬부기","치코리타","구구","캐터피","피카츄"};
    }
    class Poketmon
    {
        public string name;
        public string skill;

        public void excute()
        {
            Console.WriteLine("{0}의 스킬 발동 {1}", name, skill);
        }
    }
    class firy : Poketmon
    {
        public firy()
        {
            name = "파이리";
            skill = "불꽃";
        }
    }
    class Ggobugi : Poketmon
    {
        public Ggobugi()
        {
            name = "꼬부기";
            skill = "물대포";
        }
    }
    class chicorita : Poketmon
    {
        public chicorita()
        {
            name = "치코리타";
            skill = "풀베기";
        }
    }

    class gugu : Poketmon
    {
        public gugu()
        {
            name = "구구";
            skill = "공중날기";
        }
    }

    class katerpy : Poketmon
    {
        public katerpy()
        {
            name = "캐터피";
            skill = "몸통박치기";
        }
    }

    class picachu : Poketmon
    {
        public picachu()
        {
            name = "피카츄";
            skill = "백만볼트";
        }
    }
}
