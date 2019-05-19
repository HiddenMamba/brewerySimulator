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
                        Console.WriteLine("Zamawiam trucki");
                        //TUTAJ WARUNEK IF KTORY SPRAWDZA CZY MAMY WSZYSTKIE SKLADNIKI W KADZI I MOZNA WARZYC 
                        //PAMIETAJ O GORNYM KRANIE
                        while (piwo < 3)
                        {
                            warzelnia.isWorking = true;
                            warzelnia.Brewing();
                            piwo = piwo + 1;
                        }
                    }
                    else
                    {
                        //TUTAJ CZEKA AZ UWARZY I LECI DALEJ
                        if (piwo == 3)
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
                Console.WriteLine(magazyn.HowManyBottles());
                filter.isWorking = false;
            }
        }
    }

}
