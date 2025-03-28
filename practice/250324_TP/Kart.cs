using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_TP
{
    class Kart
    {
        public string name;
        public bool choice;

        public void Updrage(Upgrade upgrade)
        {
            if (upgrade.UpgradeKart(choice) == true)
            {
                Console.WriteLine("업그레이드가 적용 되었습니다");
            }
            else
            {
                Console.WriteLine("업그레이드를 되돌렸습니다");
            }
        }
    }
}
