using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class Bottler : Interface
    {
        int efficiency; //ilość butelek na godzine
        public bool isWorking = false;

        public Bottler(int eff)
        {
            efficiency = eff;
        }

        public bool HasFinished { get; set; }
        public void Work()
        {
            //TUTAJ BUTELKOWANIE
            isWorking = true;
            int time = (3000 / efficiency);

        }

        public void Run()
        {
            while (!HasFinished)
            {
                Work();
                Thread.Sleep(2000);
            }
        }
    }
}
