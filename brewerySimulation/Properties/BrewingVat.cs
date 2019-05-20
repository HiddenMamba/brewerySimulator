using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class BrewingVat : Vat
    {
        public bool isWorking = false;
        public int water = 0;
        public int hop = 0;
        public int barley = 0;

        private int recipeWater = 900;
        private int recipeHop = 50;
        private int recipeBarley = 100;


        public bool isEnoughWater()
        {
            if (this.water == recipeWater) return true;
            else
            {
                return false;
            }
        }
        public bool isEnoughHop()
        {
            if (this.hop == recipeHop) return true;
            else
            {
                return false;
            }
        }
        public bool isEnoughBarley()
        {
            if (this.barley == recipeBarley) return true;
            else
            {
                return false;
            }
        }

        public BrewingVat(int vol)
        {
            this.volume = vol;
        }

        public override void Process() => Brewing();

        public override void Cleaning()
        {
            Console.WriteLine("Czyszczenie kadzi warzelnej");
            Thread.Sleep(1000);
        }
        public override void Flow()
        {
            this.lowerTap = true;
            Console.WriteLine("Przelewam do kadzi fermentacyjnej");
            Thread.Sleep(500);
            this.lowerTap = false;
        }

        public void Brewing()
        {
            //TUTAJ dzieje sie soczek
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //warzenie
                this.water = 0;
                this.hop = 0;
                this.barley = 0;
                isWorking = true;
                Console.WriteLine("Warze piwko");
                Thread.Sleep(3000);
                this.Flow();
                this.Cleaning();
            }
            else
            {
                Console.WriteLine("Pozamykaj krany dzbanie");
            }
        }

    }
}
