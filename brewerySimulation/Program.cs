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
            FermentationVat kadzFermentacyjna2 = new FermentationVat(2000);
            FermentationVat kadzFermentacyjna3 = new FermentationVat(2000);
            Bottler rozlewnia = new Bottler(1000);
            Warehouse magazyn = new Warehouse(100);

        }
    }
}
