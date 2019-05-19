using System;
namespace brewerySimulation.Properties
{
    public abstract class Vat
    {
        public int volume; //wielkość w litrach
        bool upperTap = false;
        bool lowerTap = false;

        public void Process()
        {
            //gotowanie lub fermentacja
        }

        public void Cleaning()
        {
            //czyszczenie po zakonczonym procesie
        }

        public void Flow()
        {
            //Przelew dalej
        }
    }
}
