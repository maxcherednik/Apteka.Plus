using System.ServiceModel;
using log4net;

namespace Apteka.Plus.Satelite.Logic
{
    public class WCFServer<T>
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ServiceHost _customerServiceHost;

        public void Start()
        {
            _customerServiceHost = new ServiceHost(typeof(T));
            _customerServiceHost.Open();

            foreach (var item in _customerServiceHost.ChannelDispatchers)
            {
                Log.InfoFormat("Server address: {0}", item.Listener.Uri);
            }
        }

        public void Stop()
        {
            _customerServiceHost.Close();
        }
    }
}
