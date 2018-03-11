using System.ServiceProcess;

namespace Satelite.Service
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            ServicesToRun = new ServiceBase[] { new SateliteService() };

            ServiceBase.Run(ServicesToRun);
        }
    }
}