using System;
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

        }

        public override void Flow()
        {

        }

        private void FiltrationWork()
        {
            //tutaj soczek filtracyjny
            if (this.lowerTapState() == false && this.upperTapState() == false)
            {
                //filtrowanie
                isWorking = true;
            }
        }
    }
}
