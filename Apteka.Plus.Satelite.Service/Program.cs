using System.ServiceProcess;

namespace Satelite.Service
{
    static class Program
    {
        static void Main()
        {
            var servicesToRun = new ServiceBase[] { new SateliteService() };

            ServiceBase.Run(servicesToRun);
        }
    }
}