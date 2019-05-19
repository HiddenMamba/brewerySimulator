using System;
using System.Collections.Generic;
using brewerySimulation.Properties;
using System.Threading;
using System.Threading.Tasks;

namespace brewerySimulation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Thread> threadList = new List<Thread>();
            //Inicjalizacja warzelni
            BrewingVat kadzWarzelna1 = new BrewingVat(1000);
            FermentationVat kadzFermentacyjna1 = new FermentationVat(3000);
            Bottler rozlewnia = new Bottler(1000);
            Warehouse magazyn = new Warehouse(7000);
            Filtration kadzFiltracyjna = new Filtration();
            SuperVisor superVisor = new SuperVisor(rozlewnia, kadzWarzelna1, kadzFermentacyjna1, magazyn, kadzFiltracyjna);

            Thread fred1 = new Thread(new ThreadStart(superVisor.Run));
            fred1.Start();
        }
    }
}
