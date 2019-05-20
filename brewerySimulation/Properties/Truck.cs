using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public abstract class Truck : Interface
    {
        public int volume;
        public int time;

        public static Mutex mut = new Mutex();

        public Truck()
        {
        }

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
