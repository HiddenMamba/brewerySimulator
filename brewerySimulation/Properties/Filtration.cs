using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class Filtration : Vat
    {
        public bool isWorking = false;

        public Filtration()
        {
        }
        public override void Process() => FiltrationWork();

        public override void Cleaning()
        {
            Console.WriteLine("Czyszczenie kadzi filtracyjnej");
            Thread.Sleep(1000);
        }

        public override void Flow()
        {
            this.lowerTap = true;
            Console.WriteLine("Podaje piwo do rozlewni");
            Thread.Sleep(500);
            this.lowerTap = false;
        }

        public void FiltrationWork()
        {
            //tutaj soczek filtracyjny
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //filtrowanie
                isWorking = true;
                Console.WriteLine("Filtruje piwko");
                this.Flow();
                this.Cleaning();
            }
        }
    }
}
