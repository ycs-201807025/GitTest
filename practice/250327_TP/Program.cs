using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250327_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Armor armor = new Armor();
            Player player = new Player();
            Accessories accessories = new Accessories();

            player.WearArmor += armor.DurInfo;

            player.Wearing();

            player.Att += accessories.Lightning;

            player.Attack();

            player.Damage += armor.TakeDamage;

            player.DamegeTaken();

            armor.Break += armor.BreakArmor;

            player.Undressing();
        }
        public class Player
        {
            public Armor armor;

            public event Action WearArmor;
            //public event Action UndreArmor;
            public event Action Damage;
            public event Action Att;

            public void Attack()
            {
                Console.WriteLine("플레이어가 적을 공격합니다");

                if (Att != null)
                {
                    Att();
                }
            }
            public void Wearing()
            {
                Console.WriteLine("갑옷을 착용했습니다");

                if (WearArmor != null)
                {
                    WearArmor();
                }
            }
            public void Undressing()
            {
                Console.WriteLine("갑옷을 탈의했습니다");

                //if (UndreArmor != null)
                //{
                //    UndreArmor();
                //}
            }
            public void DamegeTaken()
            {
                Console.WriteLine("플레이어가 대미지를 받았습니다");

                if (Damage != null)
                {
                    Damage();
                }
            }
                
        }
        public class Armor
        {
            public event Action Break;

            int Durability = 1;

            public void DurInfo()
            {
                Console.WriteLine("갑옷의 내구도는 {0}입니다", Durability);
            }
            public void TakeDamage()
            {
                Durability -= 1;
                Console.WriteLine("갑옷의 내구도는 {0}입니다", Durability);
            }
            public void BreakArmor()
            {
                if (Break != null)
                {
                    Break();
                }
                if (Durability == 0)
                {
                    Console.WriteLine("갑옷의 내구도는 {0}입니다", Durability);
                    Console.WriteLine("갑옷이 파괴되었습니다");
                }
            }
        }
        public class Accessories
        {
            public void Lightning()
            {
                Console.WriteLine("라이트닝 발사");
            }
        }
    }
}
