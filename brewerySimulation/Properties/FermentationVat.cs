using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class FermentationVat : Vat
    {
        public FermentationVat(int vol)
        {
            this.volume = vol;
        }

        public override void Process() => Fermentation();

        public override void Cleaning()
        {

        }

        public override void Flow()
        {

        }

        private void Fermentation()
        {
            //tutaj soczek fermentacyjny
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //fermentowanie
            }
        }
    }
}
