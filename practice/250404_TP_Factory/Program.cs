using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250404_TP_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            WeaponFactory normalFactory = new WeaponFactory();
            normalFactory.rate = 0;

            Weapon weapon1 = normalFactory.Create("철검");
            Weapon weapon2 = normalFactory.Create("나무창");
            Weapon weapon3 = normalFactory.Create("쇠도끼");

            WeaponFactory rareFactory = new WeaponFactory();
            rareFactory.rate = 10;

            Weapon weapon4 = rareFactory.Create("철검");
            Weapon weapon5 = rareFactory.Create("나무창");
            Weapon weapon6 = rareFactory.Create("쇠도끼");

            WeaponFactory LegendFactory = new WeaponFactory();
            LegendFactory.rate = 20;

            Weapon weapon7 = LegendFactory.Create("철검");
            Weapon weapon8 = LegendFactory.Create("나무창");
            Weapon weapon9 = LegendFactory.Create("쇠도끼");
        }
    }
    public class WeaponFactory
    {
        public int rate;
        public Weapon Create(string name)
        { 
            Weapon weapon;
            switch(name)
            {
                case "철검" : weapon = new Weapon("철검", 10, 5, 0);
                    break;
                case "나무창" : weapon = new Weapon("나무창",7,15,0);
                    break;
                case "쇠도끼" : weapon = new Weapon("쇠도끼",13,3,0);
                    break;
                default: return null;
            }
            weapon.rarity = weapon.rarity + rate;
            if (weapon.rarity == 0)
            {
                Console.WriteLine("노말 등급");
            }
            else if (weapon.rarity >= 10 && weapon.rarity < 20)
            {
                Console.WriteLine("희귀 등급");
            }
            else if (weapon.rarity >= 20)
            {
                Console.WriteLine("전설 등급");
            }
            return weapon;
        }
    }
    public class Weapon
    {
        public string name;
        public int damage;
        public int ae;//AttackEffective
        public int rarity;

        public Weapon(string name, int damage, int ae, int rarity)
        {
            this.name = name;
            this.damage = damage;
            this.ae = ae;
            this.rarity = rarity;
            
        }
    }
}
