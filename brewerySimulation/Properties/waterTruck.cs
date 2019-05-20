using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class WaterTruck : Truck
    {
        private readonly BrewingVat vat;

        public WaterTruck(BrewingVat warzelnia)
        {
            this.volume = 300;
            this.time = 20;
            this.vat = warzelnia;
        }
        public int unload()
        {
            return this.volume;
        }

        public override void Process() => Drive(vat);

        public void Drive(BrewingVat warzelnia)
        {
            bool locked = false;
            try
            {
                Console.WriteLine("Wodny chce podjechac");
                locked = mut.WaitOne();
                Console.WriteLine("Wodny wchodzi i ładuje");
                // Zmieniam wartośc zmiennej Konta
                warzelnia.water += this.volume;
                Thread.Sleep(600); //symulacja czasu wykonania
                Console.WriteLine("Stan wody po wyladowaniu: " + warzelnia.water);
            }
            finally
            {
                if (locked)
                    Console.WriteLine("Wodny_wychodzi");

                // Zwalnianie dostępu
                mut.ReleaseMutex();
                Console.WriteLine("Wodny_zwalnia");
            }

        }
    }
}
