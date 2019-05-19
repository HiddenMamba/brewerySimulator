using System;
using System.Collections.Generic;
using brewerySimulation.Properties;

namespace brewerySimulation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Inicjalizacja warzelni
            BrewingVat kadzWarzelna1 = new BrewingVat(1000);
            FermentationVat kadzFermentacyjna1 = new FermentationVat(3000);
            Bottler rozlewnia = new Bottler(1000);
            Warehouse magazyn = new Warehouse(100);
            SuperVisor superVisor = new SuperVisor(rozlewnia, kadzWarzelna1, kadzFermentacyjna1, magazyn);

        }
    }
}
