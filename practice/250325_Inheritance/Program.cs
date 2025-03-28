using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250325_Inheritance
{
    class Program
    {
        /**********************************************************************************
         * 상속 (Inheritance)
         *
         * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
         * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
         **********************************************************************************/

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스 : 부모클래스
        class Monster
        {
            protected string name;
            public int hp;
            public float speed;
           

            public void Move()
            {
                Console.WriteLine("{0} 이/가 {1} 속도로 움직입니다",name,speed);
            }
        }

        class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 10;
                speed = 3.5f;
            }
            public void Split()
            {
                Console.WriteLine("분열 합니다");
            }

        }
        class Dragon : Monster
        {
            public float speed;

            public Dragon()
            {
                name = "드래곤";
                hp = 100;
                speed = 5.5f;
            }
            public void Breath()
            {
                Console.WriteLine("브레스를 뿜습니다.");
            }
        }
        static void Main(string[] args)
        {

            Slime slime = new Slime();
            Dragon dragon = new Dragon();

            //부모클래스 Monster를 상속한 자식클래스는 모두 부모클래스의 기능을 가지고 있음
            slime.Move(); 
            dragon.Move();
            //자식클래스는 부모클래스의 기능에 자식만의 기능을 더욱 추가하여 구현 가능
            slime.Split();
            dragon.Breath();

            //업캐스팅 : 자식클래스는 부모클래스 자료형으로 암시적 형변환 가능
            Monster monster0 = new Slime(); 
            Monster dragon0 = new Dragon();


            Item[] inventory = new Item[20];
            inventory[0] = new Potion();
            inventory[1] = new Weapon();

        }

        class Item
        {
            public string name;
            public string icon;
            public int weight;
        }

        class Potion : Item { }
        class Weapon : Item { }
    }
}
