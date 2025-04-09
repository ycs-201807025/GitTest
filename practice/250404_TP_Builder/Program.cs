using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250404_TP_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalBuilder sheepBuilder = new AnimalBuilder();
            sheepBuilder
                .SetName("양")
                .SetProd("양털")
                .SetSound("메에")
                .SetMeal("풀");
            AnimalBuilder cowBuilder = new AnimalBuilder();
            cowBuilder
                .SetName("소")
                .SetProd("소고기")
                .SetSound("음메")
                .SetMeal("건초");
            AnimalBuilder chickenBuilder = new AnimalBuilder();
            chickenBuilder
                .SetName("닭")
                .SetProd("닭고기")
                .SetSound("꼬끼오")
                .SetMeal("모이");
            AnimalBuilder dragonBuilder = new AnimalBuilder("용");
            chickenBuilder
                .SetName("용")
                .SetProd("비늘")
                .SetSound("크오오오")
                .SetMeal("먹을수있는건 아무거나")
                .SetRareProd("여의주");
        }
        public class AnimalBuilder
        {
            public string name;
            public string prod;
            public string sound;
            public string meal;
            public string rareprod;
            public AnimalBuilder()
            {
                name = "동물";
                prod = "생산품";
                sound = "울음소리";
                meal = "사료종류";
            }
            public AnimalBuilder(string rareprod)
            {
                name = "동물";
                prod = "생산품";
                sound = "울음소리";
                meal = "사료종류";
                rareprod = "특수생산품";
            }
            public AnimalBuilder SetName(string name)
            {
                this.name = name;
                return this;
            }
            public AnimalBuilder SetProd(string prod)
            {
                this.prod = prod;
                return this;
            }
            public AnimalBuilder SetSound(string sound)
            {
                this.sound = sound;
                return this;
            }
            public AnimalBuilder SetMeal(string meal)
            {
                this.meal = meal;
                return this;
            }
            public AnimalBuilder SetRareProd(string rareprod)
            {
                this.rareprod = rareprod;
                return this;
            }
        }
        public class Animal
        {
            public string name;
            public string prod;
            public string sound;
            public string meal;
            public string rareprod;
        }
    }
}
