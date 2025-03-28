using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250326_TP
{
    class Program
    {
        static void Main(string[] args)
        {
            NPC npc = new NPC();
            Chest chest = new Chest();
            Portal portal = new Portal();
            Market market = new Market();

            npc.interaction();
            npc.talk();
            chest.interaction();
            chest.aquire();
            portal.interaction();
            portal.move();
            market.interaction();
            market.open();
        }
    }

    public interface IInteraction
    {
        void interaction();
    }
    public interface ITalk
    {
        void talk();
    }

    public interface IAquire
    {
        void aquire();
    }
    public interface IMove
    {
        void move();
    }
    public interface IMarketOpen
    {
        void open();
    }

    public class NPC : IInteraction,ITalk
    {
        string npc = "일반NPC";

        public void interaction()
        {
            Console.WriteLine("상호작용");
        }
        public void talk()
        {
            Console.WriteLine("대화 시작");
        }
    }
    public class Chest : IInteraction,IAquire
    {
        public void interaction()
        {
            Console.WriteLine("상호작용");
        }
        public void aquire()
        {
            Console.WriteLine("아이템 획득");
        }
    }
    public class Portal : IInteraction,IMove
    {
        public void interaction()
        {
            Console.WriteLine("상호작용");
        }
        public void move()
        {
            Console.WriteLine("다음 맵으로 이동");
        }
    }
    public class Market : IInteraction,IMarketOpen
    {
        public void interaction()
        {
            Console.WriteLine("상호작용");
        }
        public void open()
        {
            Console.WriteLine("상점 오픈");
        }
    }

}
