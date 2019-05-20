using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class BarleyTruck : Truck
    {
        private readonly BrewingVat vat;
        public BarleyTruck(BrewingVat warzelnia)
        {
            this.volume = 50;
            this.time = 30;
            this.vat = warzelnia;
        }

        public override void Process() => Drive(vat);

        public void Drive(BrewingVat warzelnia)
        {
            bool locked = false;
            try
            {
                Console.WriteLine("Jeczmienny chce podjechac");
                locked = mut.WaitOne();
                Console.WriteLine("Jeczmienny wchodzi i ładuje");
                // Zmieniam wartośc zmiennej Konta
                warzelnia.barley += this.volume;
                Thread.Sleep(100); //symulacja czasu wykonania
                Console.WriteLine("Stan jeczmienia po wyladowaniu: " + warzelnia.barley);
            }
            finally
            {
                if (locked)
                    Console.WriteLine("Jedzmienny wychodzi");

                // Zwalnianie dostępu
                mut.ReleaseMutex();
                Console.WriteLine("Jeczmienny zwalnia");
            }

        }
    }
}
