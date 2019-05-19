using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class BrewingVat : Vat
    {
        public bool isWorking = false;
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
