using System;
namespace brewerySimulation.Properties
{
    public interface Interface
    {
        void Run();
        bool HasFinished { get; set; }
    }
}
