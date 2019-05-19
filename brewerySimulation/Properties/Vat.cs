using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public abstract class Vat : Interface
    {
        public int volume; //wielkość w litrach
        private bool upperTap = false;
        private bool lowerTap = false;

        public bool upperTapState() => upperTap;
        public bool lowerTapState() => lowerTap;

        public abstract void Cleaning();
        public abstract void Flow();

        public bool HasFinished { get; set; }
        public abstract void Process();

        public void Run()
        {
            while (!HasFinished)
            {
                Process();
                Thread.Sleep(2000);
            }
        }
    }
}
