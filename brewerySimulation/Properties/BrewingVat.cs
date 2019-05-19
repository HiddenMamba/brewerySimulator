using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class BrewingVat : Vat
    {
        public BrewingVat(int vol)
        {
            this.volume = vol;
        }

        public override void Process() => Brewing();

        public override void Cleaning()
        {
        }
        public override void Flow()
        {
        }

        private void Brewing()
        {
            //TUTAJ dzieje sie soczek
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //warzenie
            }
        }

    }
}
