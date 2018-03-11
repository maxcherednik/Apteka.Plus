using System.ServiceProcess;
using Apteka.Plus.Satelite.Logic;
using log4net;

namespace Satelite.Service
{
    public partial class SateliteService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private WCFServer<SateliteServer> wcfServer = new WCFServer<SateliteServer>();

        public SateliteService()
        {
            InitializeComponent();
            SateliteServer.SateliteID = Properties.Settings.Default.SateliteID;
        }

        protected override void OnStart(string[] args)
        {
            log.InfoFormat("Service is starting. Store id={0}", SateliteServer.SateliteID);

            wcfServer.Start();

            log.Info("Service successfully started");
        }

        protected override void OnStop()
        {
            log.Info("Service is stopping");

            wcfServer.Stop();

            log.Info("Service stopped");
        }
    }
}
