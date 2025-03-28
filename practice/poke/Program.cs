using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poke
{
    class Program
    {
        class Trainer
        {
            public string name;
            public string[] monsterPocket = {};

            public void Add(Monster name)
            {
                for (int i = 0; i < monsterPocket.Length; i++)
                {
                    if (monsterPocket == null)
                    {
                        monsterPocket[i] = name;
                    }
                    else if (monsterPocket != null)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            public void Remove(Monster name)
            {
                for (int i = 0; i < monsterPocket.Length; i++)
                {
                    if (monsterPocket == name)
                    {
                        monsterPocket[i] = null;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            public void PrintAll()
            {
                for (int i = 0; i < monsterPocket.Length; i++)
                {
                    Console.WriteLine(i + "." + name);
                }
                
            }
        }
        class Monster
        {
            public string name = " ";
            public int level;

            public void Print()
            {
                Console.WriteLine(name);
                Console.WriteLine(level);
            }
        }
        static void Main(string[] args)
        {
            Trainer trainer = new Trainer();
            Monster monster = new Monster();
        }
    }
}
