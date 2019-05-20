using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class HopTruck : Truck
    {
        private readonly BrewingVat vat;
        public HopTruck(BrewingVat warzelnia)
        {
            this.volume = 50;
            this.time = 50;
            this.vat = warzelnia;
        }

        public override void Process() => Drive(vat);

        public void Drive(BrewingVat warzelnia)
        {
            bool locked = false;
            try
            {
                Console.WriteLine("Chmielowy chce podjechac");
                locked = mut.WaitOne();
                Console.WriteLine("Chmielowy wchodzi i ładuje");
                // Zmieniam wartośc zmiennej Konta
                warzelnia.hop += this.volume;
                Thread.Sleep(300); //symulacja czasu wykonania
                Console.WriteLine("Stan chmielu po wyladowaniu: " + warzelnia.hop);
            }
            finally
            {
                if (locked)
                    Console.WriteLine("Chmielowy_wychodzi");

                // Zwalnianie dostępu
                mut.ReleaseMutex();
                Console.WriteLine("Chmielowy_zwalnia");
            }

        }
    }
}
