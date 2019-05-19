using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class SuperVisor : Interface
    {
        private Bottler rozlewnia;
        private BrewingVat warzelnia;
        private FermentationVat fermentor;
        private Warehouse magazyn;

        public SuperVisor(Bottler bott, BrewingVat bv, FermentationVat fv, Warehouse wh)
        {
            this.rozlewnia = bott;
            this.warzelnia = bv;
            this.fermentor = fv;
            this.magazyn = wh;
        }

        public bool HasFinished { get; set; }
        public void Run()
        {
            while (!HasFinished)
            {
                Work();
                Thread.Sleep(2000);
            }
        }

        private void Work()
        {
            //Tutaj to co robi


        }
    }

}
