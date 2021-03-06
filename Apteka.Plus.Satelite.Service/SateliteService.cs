﻿using System.ServiceProcess;
using Apteka.Plus.Satelite.Logic;
using log4net;

namespace Satelite.Service
{
    public partial class SateliteService : ServiceBase
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly WCFServer<SateliteServer> _wcfServer = new WCFServer<SateliteServer>();

        public SateliteService()
        {
            InitializeComponent();
            SateliteServer.SateliteID = Properties.Settings.Default.SateliteID;
        }

        protected override void OnStart(string[] args)
        {
            Log.InfoFormat("Service is starting. Store id={0}", SateliteServer.SateliteID);

            _wcfServer.Start();

            Log.Info("Service successfully started");
        }

        protected override void OnStop()
        {
            Log.Info("Service is stopping");

            _wcfServer.Stop();

            Log.Info("Service stopped");
        }
    }
}
