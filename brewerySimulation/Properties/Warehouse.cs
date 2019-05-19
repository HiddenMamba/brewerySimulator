using System;
namespace brewerySimulation.Properties
{
    public class Warehouse
    {
        private int quantity; //ilosc dostepnych butelek

        public Warehouse(int qua)
        {
            quantity = qua;
        }

        public int HowManyBottles() => quantity;

        public void deliverBottle()
        {

        }

        public void receiveBottle()
        {

        }
    }
}
