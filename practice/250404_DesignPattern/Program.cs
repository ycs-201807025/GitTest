using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250404_DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // 스테이지 1-1
            MonsterFactory level1Factory = new MonsterFactory();
            level1Factory.rate = 1;

            // 1. 처음 맵 만들어 졌을 때 -> 몬스터 3마리
            Monster monster11 = level1Factory.Create("슬라임");
            Monster monster33 = level1Factory.Create("슬라임");
            Monster monster55 = level1Factory.Create("슬라임");

            // 2. 다음 장소로 이동했을 때 -> 몬스터 5마리
            Monster monster1 = level1Factory.Create("슬라임");
            Monster monster2 = level1Factory.Create("슬라임");
            Monster monster3 = level1Factory.Create("슬라임");
            Monster monster4 = level1Factory.Create("고블린");
            Monster monster5 = level1Factory.Create("고블린");

            // 3. 보스룸 입장하면 -> 몬스터 2마리
            Monster bossMonster = level1Factory.Create("오크족장");
            Monster subMonster1 = level1Factory.Create("고블린");
            Monster subMonster2 = level1Factory.Create("고블린");


            // 스테이지 2-1
            MonsterFactory level2Factory = new MonsterFactory();
            level2Factory.rate = 1.1f;
            Monster level2monster1 = level2Factory.Create("슬라임");
            Monster level2monster2 = level2Factory.Create("슬라임");

        }
        public class MonsterFactory
        {
            public float rate;

            public Monster Create(string name)
            {
                Monster monster;
                switch (name)
                {
                    case "슬라임":    monster = new Monster("슬라임", 1, 100); break;
                    case "고블린":    monster = new Monster("고블린", 3, 200); break;
                    case "오크족장":  monster = new Monster("오크족장", 10, 2000); break;
                    default: return null;
                }

                monster.hp = (int)(monster.hp * rate);
                return monster;
            }
        }


        public class Monster
        {
            public string name;
            public int level;
            public int hp;

            public Monster(string name, int level, int hp)
            {
                this.name = name;
                this.level = level;
                this.hp = hp;
            }
        }
    }
}
