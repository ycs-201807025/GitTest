using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250404_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            MonsterBuilder orcArcherBuilder = new MonsterBuilder();
            orcArcherBuilder
                .SetName("오크 궁수")
                .SetWeapon("나무 활")
                .SetArmor("가죽 갑옷");

            MonsterBuilder orcWarriorBuilder = new MonsterBuilder();
            orcWarriorBuilder
                .SetName("오크 전사")
                .SetWeapon("나무 몽둥이")
                .SetArmor("철 갑옷");

            MonsterBuilder orcEliteWarriorBuilder = new MonsterBuilder();
            orcWarriorBuilder
                .SetName("오크 전사")
                .SetWeapon("철 검")
                .SetArmor("철 갑옷");

            Monster monster0 = orcArcherBuilder.Build();
            Console.WriteLine("이름: { 0}, 무기: { 1}, 갑옷: { 2}", monster0.name, monster0.weapon, monster0.armor);

            Monster monster1 = orcWarriorBuilder.Build();
            Console.WriteLine("이름: { 0}, 무기: { 1}, 갑옷: { 2}", monster1.name, monster1.weapon, monster1.armor);

            Monster monster2 = orcEliteWarriorBuilder.Build();
        }

        public class MonsterBuilder
        {
            public string name;
            public string weapon;
            public string armor;

            public MonsterBuilder()
            {
                name = "몬스터";
                weapon = "기본무기";
                armor = "기본갑옷";
            }

            public Monster Build()
            {
                Monster monster = new Monster();
                monster.name = name;
                monster.weapon = weapon;
                monster.armor = armor;

                return monster;
            }

            public MonsterBuilder SetName(string name)
            {
                this.name = name;
                return this;
            }

            public MonsterBuilder SetWeapon(string weapon)
            {
                this.weapon = weapon;
                return this;
            }

            public MonsterBuilder SetArmor(string armor)
            {
                this.armor = armor;
                return this;
            }
        }

        public class Monster
        {
            public string name;
            public string weapon;
            public string armor;
        }
    }
}
