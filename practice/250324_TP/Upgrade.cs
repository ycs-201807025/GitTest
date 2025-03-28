using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250324_TP
{
    class Upgrade
    {
        public int boosterAdd;
        public int driftAdd;
        public int boosterTime;
        public int boosterBattery;
        public int driftRetention;
        public int boosterProtect;
        public int startBooster;
        public int draftAdd;
        public bool choice;

        public bool UpgradeKart(bool choice)
        {
            if (choice == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
