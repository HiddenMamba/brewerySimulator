using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class FermentationVat : Vat
    {
        public bool isWorking = false;

        public FermentationVat(int vol)
        {
            this.volume = vol;
        }

        public override void Process() => Fermentation();

        public override void Cleaning()
        {
            Console.WriteLine("Czyszczenie kadzi fermentacyjnej");
            Thread.Sleep(1000);
        }

        public override void Flow()
        {
            this.lowerTap = true;
            Console.WriteLine("Przelewam do kadzi filtracyjnej");
            Thread.Sleep(500);
            this.lowerTap = false;
        }

        public void Fermentation()
        {
            //tutaj soczek fermentacyjny
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //fermentowanie
                isWorking = true;
                Console.WriteLine("Fermentuje piwko");
                this.Flow();
                this.Cleaning();
            }
        }
    }
}
