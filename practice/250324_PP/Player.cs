using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_PP
{
    class Player
    {
        public int ap = 10;

        public void Attack(Monster monster)
        {
            monster.TakeHit(ap);
        }
    }
}
