using System;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation.Properties
{
    public class SuperVisor : Interface
    {
        public int piwo = 0;
        private Bottler rozlewnia;
        private BrewingVat warzelnia;
        private FermentationVat fermentor;
        private Warehouse magazyn;
        private Filtration filter;


        public SuperVisor(Bottler bott, BrewingVat bv, FermentationVat fv, Warehouse wh, Filtration fil)
        {
            this.rozlewnia = bott;
            this.warzelnia = bv;
            this.fermentor = fv;
            this.magazyn = wh;
            this.filter = fil;
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
            if(filter.isWorking == false)
            {
                if(fermentor.isWorking == false)
                {
                    if(warzelnia.isWorking == false)
                    {
                        //ZAMAWIA PRODUKTY I CZEKA AZ ZAPELNI SIE KADŹ a potem pracuje
                        /*
                        if(warzelnia.isEnoughWater() == false)
                        {
                            //ZAMAWIAM WODE == 900 jednostek
                            WaterTruck wodnik1 = new WaterTruck(warzelnia);
                            wodnik1.Drive(warzelnia);

                        }
                        else if (warzelnia.isEnoughHop() == false)
                        {
                            //ZAMAWIAM WODE == 900 jednostek
                            HopTruck chmielnik1 = new HopTruck(warzelnia);
                            chmielnik1.Drive(warzelnia);
                        }
                        else if (warzelnia.isEnoughBarley() == false)
                        {
                            //ZAMAWIAM WODE == 900 jednostek

                            BarleyTruck jeczmienny1 = new BarleyTruck(warzelnia);
                            jeczmienny1.Drive(warzelnia);
                        }
                        else
                        {
                            while (piwo < 3000)
                            {
                                warzelnia.isWorking = true;
                                warzelnia.Brewing();
                                piwo = piwo + 1000;
                            }
                        }
                        */
                        WaterTruck wodnik1 = new WaterTruck(warzelnia);
                        HopTruck chmielnik1 = new HopTruck(warzelnia);
                        BarleyTruck jeczmienny1 = new BarleyTruck(warzelnia);

                        Thread fred2 = new Thread(new ThreadStart(wodnik1.Run));
                        fred2.Start();
                        Thread fred3 = new Thread(new ThreadStart(chmielnik1.Run));
                        fred3.Start();
                        Thread fred4 = new Thread(new ThreadStart(jeczmienny1.Run));
                        fred4.Start();
                        if(warzelnia.isEnoughWater() == true)
                        {
                            fred2.Abort();
                        }

                    }
                    else
                    {
                        //TUTAJ CZEKA AZ UWARZY I LECI DALEJ
                        if (piwo == 3000)
                        {
                            warzelnia.lowerTap = false;
                            warzelnia.upperTap = false;
                            warzelnia.isWorking = false;

                            fermentor.isWorking = true;
                            fermentor.Fermentation();
                        }
                        piwo = 0;
                    }
                }
                else
                {
                    //TUTAJ CZEKA AZ ZAFERMENTUJE I ROBI TO CO DALEJ
                    filter.isWorking = true;
                    filter.FiltrationWork();
                    fermentor.isWorking = false;
                }
            }
            else
            {
                //TUTAJ CZEKA I ROBI TO CO PO FILTRACJI
                rozlewnia.isWorking = true;
                for (int i = 1; i<=(3000/0.5); i++)
                {
                    magazyn.deliverBottle();
                    rozlewnia.Work();
                }
                Console.WriteLine("zostalo butelek: "+magazyn.HowManyBottles());
                filter.isWorking = false;
            }
        }
    }

}
