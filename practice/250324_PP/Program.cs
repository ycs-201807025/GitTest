using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_PP
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Monster monster = new Monster();

            player.Attack(monster);
        }
    }
}
