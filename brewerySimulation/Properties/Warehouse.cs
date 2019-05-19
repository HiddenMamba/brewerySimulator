using System;
namespace brewerySimulation.Properties
{
    public class Warehouse
    {
        private int quanity; //ilosc dostepnych butelek

        public Warehouse(int qua)
        {
            quanity = qua;
        }

        public int howManyBottles()
        {
            return quanity;
        }

        public void deliverBottle()
        {

        }

        public void receiveBottle()
        {

        }
    }
}
